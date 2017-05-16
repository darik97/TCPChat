using System;
using System.Net.Sockets;
using System.Text;

namespace Server
{
    class ClientObject
    {
        protected internal string id { get; private set; }
        protected internal NetworkStream stream { get; private set; }
        protected internal string userName;
        TcpClient client;
        ServerObject server;

        public ClientObject(TcpClient tcpClient, ServerObject serverObject)
        {
            id = Guid.NewGuid().ToString();
            client = tcpClient;
            server = serverObject;
            serverObject.AddConnection(this);
        }

        public void Process()
        {
            try
            {
                stream = client.GetStream();
                string message = getMessage();
                userName = message;

                message += " присоединился к чату";
                Console.WriteLine(message);
                message += server.GetUsersList();
                server.broadcastMessage(message);

                while (true)
                {
                    try
                    {
                        message = getMessage();
                        message = DateTime.Now.ToShortTimeString() + " " + userName + ": " + message;
                        Console.WriteLine(message);
                        server.broadcastMessage(message);
                    }
                    catch
                    {
                        message = userName + " покинул чат";
                        Console.WriteLine(message);
                        server.removeConnection(id);
                        message += server.GetUsersList();
                        server.broadcastMessage(message);
                        break;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Ошибка в работе чата:" + e.Message);
            }
            finally
            {
                //server.removeConnection(id);
                close();
            }
        }
        private string getMessage()
        {
            byte[] data = new byte[512];
            StringBuilder builder = new StringBuilder();
            int bytes = 0;
            do
            {
                bytes = stream.Read(data, 0, data.Length);
                builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
            }
            while (stream.DataAvailable);

            return builder.ToString();
        }

        protected internal void close()
        {
            if (stream != null)
            {
                stream.Close();
            }
            if (client != null)
            {
                client.Close();
            }
        }
    }
}
