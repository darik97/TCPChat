using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace rtf
{
    public class ExRichTextBox : RichTextBox
    {
        private const int MM_ANISOTROPIC = 8;
        private const int HMM_PER_INCH = 2540;
        private const int TWIPS_PER_INCH = 1440;
        
        private float xDpi;
        private float yDpi;

        private const string RTF_HEADER = @"{\rtf1\ansi\ansicpg1252\deff0\deflang1033";        
        private const string RTF_DOCUMENT_PRE = @"\viewkind4\uc1\pard\cf1\f0\fs20";
        private const string RTF_DOCUMENT_POST = @"\cf0\fs17}";
        private string RTF_IMAGE_POST = @"}";

        public ExRichTextBox() : base()
        {
            using (Graphics _graphics = this.CreateGraphics())
            {
                xDpi = _graphics.DpiX;
                yDpi = _graphics.DpiY;
            }
        }
        
        public void InsertRtf(string _rtf)
        {
            SelectedRtf = _rtf;
        }

        public void AppendTextAsRtf(string _text)
        {
            InsertTextAsRtf(_text);
        }

        public void InsertTextAsRtf(string _text)
        {
            StringBuilder _rtf = new StringBuilder();
            _rtf.Append(RTF_HEADER);
            _rtf.Append(GetDocumentArea(_text));
            SelectedRtf = _rtf.ToString();
        }

        private string GetDocumentArea(string _text)
        {
            StringBuilder _doc = new StringBuilder();
            _doc.Append(_text.Replace("\n", @"\par "));
            return _doc.ToString();
        }

        #region Insert Image
        
        public void InsertImage(Image _image)
        {
            StringBuilder _rtf = new StringBuilder();
            
            _rtf.Append(RTF_HEADER);
            _rtf.Append(GetImagePrefix(_image));
            _rtf.Append(GetRtfImage(_image));
            _rtf.Append(RTF_IMAGE_POST);

            SelectedRtf = _rtf.ToString();
        }

        private string GetImagePrefix(Image _image)
        {
            StringBuilder _rtf = new StringBuilder();

            int picw = (int)Math.Round((_image.Width / xDpi) * HMM_PER_INCH);
            int pich = (int)Math.Round((_image.Height / yDpi) * HMM_PER_INCH);
            int picwgoal = (int)Math.Round((_image.Width / xDpi) * TWIPS_PER_INCH);
            int pichgoal = (int)Math.Round((_image.Height / yDpi) * TWIPS_PER_INCH);
            // Append values to RTF string
            _rtf.Append(@"{\pict\wmetafile8");
            _rtf.Append(@"\picw");
            _rtf.Append(picw);
            _rtf.Append(@"\pich");
            _rtf.Append(pich);
            _rtf.Append(@"\picwgoal");
            _rtf.Append(picwgoal);
            _rtf.Append(@"\pichgoal");
            _rtf.Append(pichgoal);
            _rtf.Append(" ");

            return _rtf.ToString();
        }
        
        [DllImport("gdiplus.dll")]
        private static extern uint GdipEmfToWmfBits(IntPtr _hEmf, uint _bufferSize,
            byte[] _buffer, int _mappingMode);

        
        private string GetRtfImage(Image _image)
        {

            StringBuilder _rtf = null;
            MemoryStream _stream = null;
            Graphics _graphics = null;
            Metafile _metaFile = null;
            IntPtr _hdc;

            try
            {
                _rtf = new StringBuilder();
                _stream = new MemoryStream();
                
                using (_graphics = this.CreateGraphics())
                {
                    _hdc = _graphics.GetHdc();
                    _metaFile = new Metafile(_stream, _hdc);
                    _graphics.ReleaseHdc(_hdc);
                }

                using (_graphics = Graphics.FromImage(_metaFile))
                {
                    _graphics.DrawImage(_image, new Rectangle(0, 0, _image.Width, _image.Height));

                }

                IntPtr _hEmf = _metaFile.GetHenhmetafile();
                uint _bufferSize = GdipEmfToWmfBits(_hEmf, 0, null, MM_ANISOTROPIC);

                byte[] _buffer = new byte[_bufferSize];
                uint _convertedSize = GdipEmfToWmfBits(_hEmf, _bufferSize, _buffer, MM_ANISOTROPIC);

                for (int i = 0; i < _buffer.Length; ++i)
                {
                    _rtf.Append(string.Format("{0:X2}", _buffer[i]));
                }

                return _rtf.ToString();
            }
            finally
            {
                if (_graphics != null)
                    _graphics.Dispose();
                if (_metaFile != null)
                    _metaFile.Dispose();
                if (_stream != null)
                    _stream.Close();
            }
        }
        #endregion
    }
}
