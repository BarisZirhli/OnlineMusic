using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMusicLibraryServer
{
    public class TCPconnectionServer
    {
        private TcpListener listener;

        public TCPconnectionServer()
        {
            listener = new TcpListener(IPAddress.Any, 8080);
        }

        public async Task StartConnect()
        {
            listener.Start();

            if (listener.Server.IsBound)
            {
                try
                {
                    while (true)
                    {
                        TcpClient client =  await listener.AcceptTcpClientAsync();
                        if (client != null)
                        {
                            await Task.Run(() => { _ = ClientHandler(client); });
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }

        public void Stop()
        {
            listener.Stop();
            Environment.Exit(0);
        }

        public async Task ClientHandler(TcpClient tcpClient)
        {
            try
            {
                sendSongList(tcpClient);

                await using  NetworkStream stream = tcpClient.GetStream();
                byte[] buffer = new byte[1024];
                int bytesRead = stream.Read(buffer, 0, buffer.Length);
                string message = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                string server1 = string.Join(" ", File.ReadAllLines("server1.txt"));
                string server2 = string.Join(" ", File.ReadAllLines("server2.txt"));

                if (server1.Contains(message))
                {
                    buffer = Encoding.ASCII.GetBytes("server1 yes");
                    stream.Write(buffer, 0, buffer.Length);
                }

                if (server2.Contains(message))
                {
                    buffer = Encoding.ASCII.GetBytes("server1 no");
                    stream.Write(buffer, 0, buffer.Length);
                }

                if (message.StartsWith("send4thisclient"))
                {
                    string[] list = message.Split(" ");
                    string sName = list[1];
                    string currentDirectory = Directory.GetCurrentDirectory();
                    string file = Path.Combine(currentDirectory, sName);

                    using (FileStream fileStream = new FileStream(file, FileMode.Open, FileAccess.Read))
                    {
                        long fileSize = fileStream.Length;
                        byte[] fileSizeBytes = BitConverter.GetBytes(fileSize);
                        stream.Write(fileSizeBytes, 0, fileSizeBytes.Length);

                        int bytesRead4send;
                        byte[] sendBuffer = new byte[1024];

                        while ((bytesRead4send = fileStream.Read(sendBuffer, 0, sendBuffer.Length)) > 0)
                        {
                            stream.Write(sendBuffer, 0, bytesRead4send);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public void  sendSongList(TcpClient client)
        {
            string lines = string.Join(" ", File.ReadAllLines("GlobalSongList.txt"));
            string message = "*song list*" + lines;
            byte[] buffer = Encoding.ASCII.GetBytes(message);
            NetworkStream stream = client.GetStream();
            stream.Write(buffer, 0, buffer.Length);
            stream.Flush();
        }
    }
}
