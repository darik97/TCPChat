//using Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;


namespace Server
{
    public class ServerObject
    {
        static TcpListener tcpListener;
        List<ClientObject> clients = new List<ClientObject>();

        internal void AddNewClient(ClientObject newClient)
        {
            clients.Add(newClient);
        }

        public void Listen()
        {
            try
            {
                tcpListener = new TcpListener(IPAddress.Any, 8888);
                tcpListener.Start();
#pragma warning disable CS0618 // Тип или член устарел
                IPHostEntry ipHostInfo = Dns.Resolve(Dns.GetHostName());
#pragma warning restore CS0618 // Тип или член устарел
                IPAddress localIpAddress = ipHostInfo.AddressList[0]; // choose the first of the list
                string clientUdp = localIpAddress.ToString();
                Console.WriteLine("Сервер запущен. Адрес: " + clientUdp);

                while (true)
                {
                    TcpClient client = tcpListener.AcceptTcpClient();
                    ClientObject clientObject = new ClientObject(client, this);
                    Thread clientThread = new Thread(new ThreadStart(clientObject.Process));
                    clientThread.Start();
                }
            }
            catch (SocketException ex)
            {
                Console.WriteLine(ex.Message);
                Disconnect();
            }
            catch (ThreadStartException e)
            {
                Console.WriteLine(e.Message);
                Disconnect();
            }
            catch (ThreadInterruptedException e)
            {
                Console.WriteLine(e.Message);
                Disconnect();
            }
        }

        public void Disconnect()
        {
            tcpListener.Stop();
            for (int i = 0; i < clients.Count; i++)
            {
                clients[i].Close();
            }
        }

        public void RemoveClient(string clientId)
        {
            ClientObject client = clients.FirstOrDefault(c => c.Id == clientId);
            if (client != null)
            {
                clients.Remove(client);
            }
        }

        public void BroadcastMessage(string message)
        {
            try
            {
                byte[] data = Encoding.Unicode.GetBytes(message);
                for (int i = 0; i < clients.Count; i++)
                {
                    clients[i].Stream.Write(data, 0, data.Length);
                }
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        //public void BroadcastMessage(MessageWithImage newMes)
        //{
        //    try
        //    {
        //        var data = Serialization.Serialization.Serialize(newMes);
        //        for (int i = 0; i < clients.Count; i++)
        //        {

        //            clients[i].Stream.Write(data, 0, data.Length);
        //        }
        //    }
        //    catch (IOException e)
        //    {
        //        Console.WriteLine(e.Message);
        //    }
        //}

        public string GetUsersList()
        {
            string users = ";";
            for (int i = 0; i < clients.Count; i++)
            {
                users += clients[i].UserName + ";";
            }
            return users;
        }
    }
}