using System;
using System.IO;
using System.Net.Sockets;
using System.Text;

namespace Server
{
    class ClientObject
    {
        public string Id { get; private set; }
        public NetworkStream Stream { get; private set; }
        public string UserName;
        TcpClient client;
        ServerObject server;

        public ClientObject(TcpClient tcpClient, ServerObject serverObject)
        {
            Id = Guid.NewGuid().ToString();
            client = tcpClient;
            server = serverObject;
            serverObject.AddNewClient(this);
        }

        public void Process()
        {
            try
            {
                Stream = client.GetStream();
                string message = getMessage();
                UserName = message;

                message += " присоединился к чату";
                Console.WriteLine(message);
                message += server.GetUsersList();
                server.BroadcastMessage(message);

                while (true)
                {
                    try
                    {
                        message = getMessage();
                        message = DateTime.Now.ToShortTimeString() + " " + UserName + ": " + message;
                        server.BroadcastMessage(message);
                        Console.WriteLine(message);
                    }
                    catch (IOException e)
                    {
                        message = UserName + " покинул чат";
                        Console.WriteLine(message);
                        server.RemoveClient(Id);
                        message += server.GetUsersList();
                        server.BroadcastMessage(message);
                        break;
                    }
                }
            }
            catch (SocketException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                server.RemoveClient(Id);
                Close();
            }
        }

        private string getMessage()
        {
            try
            {
                byte[] data = new byte[512];
                StringBuilder builder = new StringBuilder();
                int bytes = 0;
                do
                {
                    bytes = Stream.Read(data, 0, data.Length);
                    builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                }
                while (Stream.DataAvailable);
                return builder.ToString();
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
                throw e;
            }
        }

        public void Close()
        {
            if (Stream != null)
            {
                Stream.Close();
            }
            if (client != null)
            {
                client.Close();
            }
        }
    }
}
