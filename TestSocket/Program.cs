using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TestSocket;
using TestSocket.TestSocket;


#region Server
Server server = new Server();
server.CreateServer();
Console.WriteLine("Enter to end");
Console.ReadLine();
#endregion


//#region ClientTCP
//Client client = new Client();
//client.Connect();
//Console.WriteLine("Enter Name Client");
//String user = Console.ReadLine();
//while (true)
//{
//    Console.WriteLine("Enter content");
//    String content = Console.ReadLine();
//    MessageContent message = new MessageContent(user, content);
//    client.Send(message);
//}
//#endregion
#region ClientUDP
//ClientUDP client = new ClientUDP();
//client.Connect();
//Console.WriteLine("Enter Name ClientUDP");
//String user = Console.ReadLine();
//while (true)
//{
//    Console.WriteLine("Enter content");
//    String content = Console.ReadLine();
//    MessageContent message = new MessageContent(user, content);
//    client.Send(message);
//}
#endregion