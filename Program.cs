using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
namespace SC2000
{
    class Program
    {
       
        static void Main(string[] args)
        {
            String IP;
            string Port;
            Console.Write("Enter IP: ");
            IP = Console.ReadLine();
            Console.Write("Enter Port: ");
            Port = Console.ReadLine();
        while (true)
        {
            IPEndPoint ip = new IPEndPoint(IPAddress.Parse(IP), Int32.Parse(Port));

            Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                server.Connect(ip);
            }
            catch (SocketException e)
            {
                Console.WriteLine("Unable to connect to server.");
                return;
            }

            byte[] data = new byte[1024];
            int receivedDataLength = server.Receive(data);
            string stringData = Encoding.ASCII.GetString(data, 0, receivedDataLength);
            Console.WriteLine(stringData); 
            server.Shutdown(SocketShutdown.Both);
            server.Close(); 
            Thread.Sleep(1000);
        }
           

            
        }
    }
}