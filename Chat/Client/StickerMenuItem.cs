using System.Drawing;
using System.Windows.Forms;

namespace Client
{
    class StickerMenuItem : MenuItem
    {
        private const int ICON_WIDTH = 70;
        private const int ICON_HEIGHT = 85;
        private const int ICON_MARGIN = 3;
        public Image Image { get; set; }

        public StickerMenuItem()
        {
            OwnerDraw = true;
        }

        public StickerMenuItem(Image image) : this() {
            Image = image;
        }

        protected override void OnMeasureItem(MeasureItemEventArgs args)
        {
            args.ItemWidth = ICON_WIDTH + ICON_MARGIN;
            args.ItemHeight = ICON_HEIGHT + 2 * ICON_MARGIN;
        }

        protected override void OnDrawItem(DrawItemEventArgs args)
        {
            Graphics graphics = args.Graphics;
            Rectangle bounds = args.Bounds;

            graphics.DrawImage(Image, bounds.X + ((bounds.Width - ICON_WIDTH) / 2), 
                bounds.Y + ((bounds.Height - ICON_HEIGHT) / 2));
        }
    }
}
