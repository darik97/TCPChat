using System;
using System.Collections.Generic;
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

        internal void AddConnection(ClientObject newClient)
        {
            clients.Add(newClient);
        }

        protected internal void listen()
        {
            try
            {
                tcpListener = new TcpListener(IPAddress.Any, 8000);
                tcpListener.Start();
                Console.WriteLine("Сервер запущен");

                while (true)
                {
                    TcpClient client = tcpListener.AcceptTcpClient();
                    ClientObject clientObject = new ClientObject(client, this);
                    Thread clientThread = new Thread(new ThreadStart(clientObject.Process));
                    clientThread.Start();
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Ошибка в работе сервера: " + ex.Message);
                disconnect();
            }
        }

        protected internal void disconnect()
        {
            tcpListener.Stop();
            for (int i = 0; i < clients.Count; i++)
            {
                clients[i].close();
            }
        }

        internal void broadcastMessage(string message)
        {
            byte[] data = Encoding.Unicode.GetBytes(message);
            for (int i = 0; i < clients.Count; i++)
            {
                clients[i].stream.Write(data, 0, data.Length);
            }
        }

        internal void removeConnection(string clientId)
        {
            ClientObject client = clients.FirstOrDefault(c => c.id == clientId);
            if (client != null)
            {
                clients.Remove(client);
            }
        }

        public string GetUsersList()
        {
            string users = ";";
            for (int i = 0; i < clients.Count; i++)
            {
                users += clients[i].userName + ";";
            }
            return users;
        }
    }
}