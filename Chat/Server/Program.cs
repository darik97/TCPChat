using System;
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
                listenThread = new Thread(new ThreadStart(server.listen));
                listenThread.Start(); 
            }
            catch (Exception ex)
            {
                server.disconnect();
                Console.WriteLine(ex.Message);
            }
        }
    }
}
