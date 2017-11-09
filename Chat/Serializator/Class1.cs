using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Serializator
{
    [Serializable]
    public class MessageWithImage
    {
        public List<string> Users { get; set; }
        public string Message { get; set; }
        public Image Image { get; set; }

        public MessageWithImage(string message, Image image = null, List<string> users = null)
        {
            Message = message;
            Image = image;
            Users = users;
        }
    }

    public static class Serialization
    {
        public static byte[] Serialize(MessageWithImage message)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            MemoryStream stream = new MemoryStream();
            formatter.Serialize(stream, message);
            return stream.ToArray();
        }
        public static MessageWithImage Deserialize(NetworkStream stream)
        {
            if (!stream.DataAvailable) return null;
            BinaryFormatter formatter = new BinaryFormatter();
            return (MessageWithImage)formatter.Deserialize(stream);
        }
    }
}
