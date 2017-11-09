using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Client
{
    class ChatController
    {
        const int port = 8888;
        static TcpClient client;
        static NetworkStream stream;
        ChatForm chatView;
        

        public ChatController(ChatForm chatForm)
        {
            chatView = chatForm;
        }

        public void SendMessage(string messageToSend)
        {
            byte[] data = Encoding.Unicode.GetBytes(messageToSend);
            stream.Write(data, 0, data.Length);
            //Packet packet = new Packet(Command.Message, chatView.UserName, data);
            //stream.Write(SerializeHelper.Serialize(packet), 0, SerializeHelper.Serialize(packet).Length);
        }

        public void StartChat(TcpClient tcpClient)
        {
            client = tcpClient;

            try
            {
                client.Connect(chatView.Host, port);
                stream = client.GetStream();

                string message = chatView.UserName;
                SendMessage(message);

                Thread receiveThread = new Thread(new ThreadStart(receiveMessage));
                receiveThread.Start();

                message = "Добро пожаловать, " + chatView.UserName + "\n";
                chatView.Invoke(chatView.ChatDelegate, new object[] { message });
            }
            catch (SocketException e)
            {
                chatView.Invoke(chatView.ErrorDelegate, new object[] { e.Message, "Ошибка при подключении" });
            }
        }



        //private void receiveMessage()
        //{
        //    while (true)
        //    {
        //        try
        //        {
        //            byte[] data = new byte[512];
        //            StringBuilder builder = new StringBuilder();
        //            int bytes = 0;
        //            do
        //            {
        //                bytes = stream.Read(data, 0, data.Length);
        //            }
        //            while (stream.DataAvailable);
        //            Packet packet = SerializeHelper.Deserialize<Packet>(data);

        //            string message = null;
        //            List<string> users = new List<string>();
        //            switch (packet.Command)
        //            {
        //                case Command.Message:
        //                    message = SerializeHelper.Deserialize<string>(packet.Data);
        //                    chatView.Invoke(chatView.ChatDelegate, new object[] { message });
        //                break;

        //                case Command.List:
        //                    users = SerializeHelper.Deserialize<List<string>>(packet.Data);
        //                    chatView.Invoke(chatView.UsersDelegate, new object[] { users });
        //                    break;
        //            }   
        //        }
        //        catch (IOException e)
        //        {
        //            chatView.Invoke(chatView.ErrorDelegate, new object[] { e.Message, "Подключение прервано" });
        //            Disconnect();
        //        }
        //        catch (SocketException e)
        //        {
        //            chatView.Invoke(chatView.ErrorDelegate, new object[] { e.Message, "Подключение прервано" });
        //            Disconnect();
        //        }
        //    }
        //}

        private void receiveMessage()
        {
            while (true)
            {
                try
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

                    string message = builder.ToString();

                    List<string> messageList = new List<string>();
                    if (Parser.IsUsersList(message, out messageList))
                    {
                        message = messageList[0];
                        chatView.Invoke(chatView.UsersDelegate, new object[] { messageList });
                    }

                    chatView.Invoke(chatView.ChatDelegate, new object[] { message });

                }
                catch (IOException e)
                {
                    chatView.Invoke(chatView.ErrorDelegate, new object[] { e.Message, "Подключение прервано" });
                    Disconnect();
                }
                catch (SocketException e)
                {
                    chatView.Invoke(chatView.ErrorDelegate, new object[] { e.Message, "Подключение прервано" });
                    Disconnect();
                }
            }
        }

        public void Disconnect()
        {
            if (stream != null)
            {
                stream.Close();
            }
            if (client != null)
            {
                client.Close();
            }
            Environment.Exit(0);
        }
    }
}
