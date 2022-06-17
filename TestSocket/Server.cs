using System;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace TestSocket
{
    public class Server
    {
        List<Socket> listClient = new List<Socket>();
        public void CreateServer()
        {
            IPEndPoint IP = new IPEndPoint(IPAddress.Any, 1995);
            Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            server.Bind(IP);
            Thread listenThread = new Thread(() =>
            {
                try
                {
                    while (true)
                    {
                        server.Listen(100);
                        Socket client = server.Accept();
                        listClient.Add(client);
                        Thread receiveThread = new Thread(TCPServerProc);
                        receiveThread.IsBackground = true;
                        receiveThread.Start(client);
                        Console.WriteLine("Co client ket noi");
                    }
                }
                catch
                {
                    Console.WriteLine("Loi tao server");
                }

            });
            listenThread.IsBackground = true;
            listenThread.Start();


            UdpClient udpServer = new UdpClient(1995);
            var udpThread = new Thread(UDPServerProc);
            udpThread.IsBackground = true;
            udpThread.Name = "UDP server thread";
            udpThread.Start(udpServer);

        }
        public void TCPServerProc(Object obj)
        {
            Socket client = obj as Socket;
            try
            {
                Console.WriteLine("TCP server thread started");
                while (true)
                {
                    byte[] data = new byte[1024];
                    client.Receive(data);
                    MessageContent message = (MessageContent)data.Deserialize();
                    SendToAllClient(message);
                    AddMessage(message);
                }
            }
            catch
            {
                listClient.Remove(client);
                client.Close();
                Console.WriteLine("co client ngat ket noi");
            }
        }

        private void UDPServerProc(object arg)
        {
            Console.WriteLine("UDP server thread started");
            try
            {
                UdpClient server = (UdpClient)arg;
                IPEndPoint remoteEP;
                byte[] buffer;
                while (true)
                {
                    remoteEP = null;
                    buffer = server.Receive(ref remoteEP);
                    MessageContent message = (MessageContent)buffer.Deserialize();
                    SendToAllClient(message);
                    AddMessage(message);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("UDPServerProc exception: " + ex);
                Console.WriteLine("UDP server thread finished");
            }

        }

        public void SendToAllClient(MessageContent message)
        {
            foreach (Socket client in listClient)
            {
                Send(client, message);
            }
        }

        public void Send(Socket client, MessageContent message)
        {
            if (message.Content != String.Empty)
                client.Send(message.Serialize());
        }

        public void AddMessage(MessageContent message)
        {
            Console.WriteLine(message.Name + " : " + message.Content);
        }
    }
}
