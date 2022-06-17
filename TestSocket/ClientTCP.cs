namespace TestSocket
{
    using System;
    using System.IO;
    using System.Net;
    using System.Net.Sockets;
    using System.Runtime.Serialization.Formatters.Binary;
    using System.Threading;

    namespace TestSocket
    {
        public class ClientTCP
        {
            IPEndPoint IP;
            Socket client;
            public void Connect()
            {
                IP = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 1995);
                client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
                try
                {
                    client.Connect(IP);
                    Thread receiveThread = new Thread(Receive);
                    receiveThread.IsBackground = true;
                    receiveThread.Start();
                    Console.WriteLine("Kết nối sv thành công");
                }
                catch
                {
                    Console.WriteLine("khong the ket noi sv");
                }
            }
            public void Receive()
            {
                try
                {
                    while (true)
                    {
                        byte[] data = new byte[1024];
                        client.Receive(data);
                        MessageContent message = (MessageContent)data.Deserialize();
                        AddMessage(message);
                    }
                }
                catch(Exception e)
                {
                    Console.WriteLine("Loi nhan du lieu");
                    Console.WriteLine(e.Message);
                }

            }


            public void Send(MessageContent message)
            {
                if (message.Content != String.Empty)
                    client.Send(message.Serialize());
                AddMessage(message);
            }
            public void AddMessage(MessageContent message)
            {
                Console.WriteLine(message.Name + " : " + message.Content);
            }
        }
    }
}


