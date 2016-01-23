using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            //start websocketa
            WebsocketServer websocketServer = new WebsocketServer();
            websocketServer.Start("http://localhost:9000/websocket/");
            Console.WriteLine("Naciśnij, żeby wyjść...");
            Console.ReadKey();
        }
    }
}
