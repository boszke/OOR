using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.WebSockets;
using System.Threading;

namespace Server
{
    class WebsocketServer
    {
       
        // Ustawienie httpListener i uruchomienie pętli, która odbiera i przetwarza przychodzące połączenia websocket. 
        //Każda iteracja pętli "asynchronicznie czeka" na następny wniosek przychodzący przy użyciu GetContextAsync
        //Jeżeli przychodzi wniosek dla połączenia websocket przenois go na ProcessRequest - inaczej ustawić kod statusu do 400 (Bad Request).
        public async void Start(string httpListenerPrefix)
        {
            HttpListener httpListener = new HttpListener();
            httpListener.Prefixes.Add(httpListenerPrefix);
            httpListener.Start();
            Console.WriteLine("Nasłuchiwanie...");

            while (true)
            {
                HttpListenerContext httpListenerContext = await httpListener.GetContextAsync();
                if (httpListenerContext.Request.IsWebSocketRequest)
                {
                    ProcessRequest(httpListenerContext);
                }
                else
                {
                    httpListenerContext.Response.StatusCode = 400;
                    httpListenerContext.Response.Close();
                }
            }
        }


        //Akceptacja połączenia websocket, zwraca instancję WebSocketContext 
        private async void ProcessRequest(HttpListenerContext httpListenerContext)
        {
            WebSocketContext webSocketContext = null;
            try
            {
                webSocketContext = await httpListenerContext.AcceptWebSocketAsync(subProtocol: null);
                string ipAddress = httpListenerContext.Request.RemoteEndPoint.Address.ToString();
                Console.WriteLine("Połączono: IPAddress {0}", ipAddress);
            }
            catch (Exception e)
            {
                httpListenerContext.Response.StatusCode = 500;
                httpListenerContext.Response.Close();
                Console.WriteLine("Błąd: {0}", e);
                return;
            }

            WebSocket webSocket = webSocketContext.WebSocket;
            try
            {
                //bufor otrzymywania danych
                byte[] receiveBuffer = new byte[1024];
            

                //pętla odbiera dane i wysyła je z powrotem
                while (webSocket.State == WebSocketState.Open)
                {
                    //odbieranie danych, do nowego ArraySegment
                    WebSocketReceiveResult receiveResult = await webSocket.ReceiveAsync(new ArraySegment<byte>(receiveBuffer), CancellationToken.None);
                    if (receiveResult.MessageType == WebSocketMessageType.Close)
                        await webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "", CancellationToken.None);
                    else
                    {
                        //wysyłanie danych
                        await webSocket.SendAsync(new ArraySegment<byte>(receiveBuffer, 0, receiveResult.Count), WebSocketMessageType.Binary, receiveResult.EndOfMessage, CancellationToken.None);
                        
                        string ipAddress = httpListenerContext.Request.RemoteEndPoint.Address.ToString();
                        Console.WriteLine(ipAddress + " : " + Encoding.UTF8.GetString(receiveBuffer).TrimEnd('\0'));
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Błąd: {0}", e);
            }
            finally
            {
                if (webSocket != null)
                    webSocket.Dispose();
            }
        }
    }
}
