using System;
using System.Net.Sockets;
using System.Threading;

namespace Server
{
    class Program
    {
        static ServerObject server;
        static Thread listenThread;

        static void Main(string[] args)
        {
            try
            {
                server = new ServerObject();
                listenThread = new Thread(new ThreadStart(server.Listen));
                listenThread.Start(); 
            }
            catch (SocketException ex)
            {
                server.Disconnect();
                Console.WriteLine(ex.Message);
            }
            catch (ThreadStartException ex)
            {
                server.Disconnect();
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                server.Disconnect();
                Console.WriteLine(ex.Message);
            }
        }
    }
}
