using System;
using System.Net.Sockets;
using System.Text;

namespace TCPClientLibNetFramework
{
    public class Client
    {
        private string _server = "";
        private int _port = 0;

        public Client(string server, int port)
        {
            _server = server;
            _port = port;
        }

        public string SendMessage(string message)
        {
            string result = "";

            System.Net.Sockets.TcpClient client = new TcpClient(_server, _port);

            byte[] data = Encoding.ASCII.GetBytes(message);
            NetworkStream stream = client.GetStream();

            stream.Write(data, 0, data.Length);

            data = new Byte[256];

            // String to store the response ASCII representation.
            String responseData = String.Empty;

            // Read the first batch of the TcpServer response bytes.
            Int32 bytes = stream.Read(data, 0, data.Length);
            result = System.Text.Encoding.ASCII.GetString(data, 0, bytes);
            Console.WriteLine("Received: {0}", responseData);

            // Close everything.
            stream.Close();
            client.Close();

            return result;
        }
    }
}
