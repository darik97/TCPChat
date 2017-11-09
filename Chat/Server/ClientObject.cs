//using Serializer;
using System;
using System.Collections.Generic;
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

        //public void Process()
        //{
        //    try
        //    {
        //        Stream = client.GetStream();
        //        Packet packet = getData();
        //        string message =  SerializeHelper.Deserialize<string>(packet.Data);

        //        UserName = message;

        //        message += " присоединился к чату";
        //        Console.WriteLine(message);
        //        packet = new Packet(Command.Message, UserName, SerializeHelper.Serialize(message));
        //        server.Broadcast(SerializeHelper.Serialize(packet));

        //        List<string> usersOnline = server.GetUsersOnline();
        //        byte[] users = SerializeHelper.Serialize(usersOnline);
        //        packet = new Packet(Command.List, null, users);
        //        server.Broadcast(SerializeHelper.Serialize(packet));

        //        while (true)
        //        {
        //            try
        //            {
        //                packet = getData();
        //                switch (packet.Command)
        //                {
        //                    case Command.Message:
        //                        message = DateTime.Now.ToShortTimeString() + " " + UserName + ": " + 
        //                            SerializeHelper.Deserialize<string>(packet.Data);
        //                        packet = new Packet(packet.Command, packet.Sender, SerializeHelper.Serialize(message));
        //                        server.Broadcast(SerializeHelper.Serialize(packet));
        //                        Console.WriteLine("{0}: {1}", packet.Sender, Encoding.UTF8.GetString(packet.Data));
        //                        break;
        //                    case Command.Image:
        //                        server.Broadcast(SerializeHelper.Serialize(packet));
        //                        break;
        //                }
        //            }
        //            catch (IOException e)
        //            {
        //                message = UserName + " покинул чат";
        //                Console.WriteLine(message);
        //                packet = new Packet(Command.Message, UserName, SerializeHelper.Serialize(message));
        //                server.Broadcast(SerializeHelper.Serialize(packet));

        //                usersOnline = server.GetUsersOnline();
        //                users = SerializeHelper.Serialize(usersOnline);
        //                packet = new Packet(Command.List, null, users);
        //                server.Broadcast(SerializeHelper.Serialize(packet));

        //                break;
        //            }
        //        }
        //    }
        //    catch (SocketException e)
        //    {
        //        Console.WriteLine(e.Message);
        //    }
        //    finally
        //    {
        //        server.RemoveClient(Id);
        //        Close();
        //    }
        //}

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

        //private Packet getData()
        //{
        //    try
        //    {
        //        byte[] data = new byte[512];
        //        StringBuilder builder = new StringBuilder();
        //        int bytes = 0;
        //        do
        //        {
        //            bytes = Stream.Read(data, 0, data.Length);
        //        }
        //        while (Stream.DataAvailable);
        //        Packet packet = SerializeHelper.Deserialize<Packet>(data);
        //        return packet;
        //    }
        //    catch (IOException e)
        //    {
        //        Console.WriteLine(e.Message);
        //        throw e;
        //    }
        //}

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
