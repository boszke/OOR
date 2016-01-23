﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Client
{
    class Program
    {
        private static UTF8Encoding encoding = new UTF8Encoding();
        public static int dlugosc = 0;

        static void Main(string[] args)
        {
            Connect("ws://localhost:9000/websocket").Wait();
            Console.WriteLine("Naciśnij, żeby wyjść...");
            Console.ReadKey();
        }

        public static async Task Connect(string uri)
        {
            Thread.Sleep(1000);

            ClientWebSocket webSocket = null;
            try
            {
                webSocket = new ClientWebSocket();
                await webSocket.ConnectAsync(new Uri(uri), CancellationToken.None);
                await Task.WhenAll(Receive(webSocket), Send(webSocket));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Błąd: {0}", ex);
            }
            finally
            {
                if (webSocket != null)
                    webSocket.Dispose();
                Console.WriteLine();
                Console.WriteLine("WebSocket został zamknięty.");
            }
        }

        private static async Task Send(ClientWebSocket webSocket)
        {
            while (webSocket.State == WebSocketState.Open)
            {
                Console.WriteLine("Napisz wiadomość do serwera.");
                string stringtoSend = Console.ReadLine();

                dlugosc = (int)stringtoSend.Length;

                byte[] buffer = encoding.GetBytes(stringtoSend);
                

                await webSocket.SendAsync(new ArraySegment<byte>(buffer), WebSocketMessageType.Binary, false, CancellationToken.None);
                Console.WriteLine("Wysłano: " + stringtoSend);

                await Task.Delay(1000);
            }
        }

        private static async Task Receive(ClientWebSocket webSocket)
        {
            byte[] buffer = new byte[1024];

            while (webSocket.State == WebSocketState.Open)
            {
                var result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
                var message = "";
                message = Encoding.UTF8.GetString(buffer).TrimEnd('\0').Substring(0, dlugosc);
                if (result.MessageType == WebSocketMessageType.Close)
                {
                    await webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, string.Empty, CancellationToken.None);
                }
                else
                {
                    if (message == "hi")
                    {
                        Console.WriteLine("Odpowiedź: " + "Cześć tu WebSocket");
                    }
                    else
                    {
                        Console.WriteLine("Odpowiedź: " + message);
                    }
                }
            }
        }
    }
}
