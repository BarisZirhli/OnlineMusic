using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnlineMusicLibraryClient
{
    public partial class Client : Form
    {
        private TcpClient server;

        public Client()
        {
            InitializeComponent();
            server = new TcpClient();
        }

        public async void connectBtn_Click(object sender, EventArgs e)
        {
            try
            {
                await server.ConnectAsync(IPAddress.Loopback, 8080);
                if (server.Connected)
                {
                    MessageBox.Show("Connected");
                    connectBtn.Enabled = false;

                    await PerformServerOperationsAsync();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public async void searchBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (!server.Connected)
                {
                    MessageBox.Show("Not connected to the server.");
                    
                }

                NetworkStream stream = server.GetStream();
                string songName = searchBar.Text;
                byte[] buffer = Encoding.ASCII.GetBytes(songName);
                await stream.WriteAsync(buffer, 0, buffer.Length);
                await stream.FlushAsync();

                await PerformServerOperationsAsync();
                searchBar.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public async void server1Download_Click(object sender, EventArgs e)
        {
            try
            {
                if (!server.Connected)
                {
                    MessageBox.Show("Not connected to the server.");
                    return;
                }

                string download_song = searchBar.Text;
                await downloadMusic(download_song);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public async Task PerformServerOperationsAsync()
        {
            try
            {
                NetworkStream stream = server.GetStream();
                byte[] buffer = new byte[1024];

                int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
                if (bytesRead > 0)
                {
                    string message = Encoding.UTF8.GetString(buffer, 0, bytesRead);

                    if (!string.IsNullOrEmpty(message))
                    {
                        if (message.Equals("server1 yes"))
                        {
                            server2Download.Enabled = false;
                            MessageBox.Show("This song is available on our server.");
                        }
                        else if (message.Contains("server1 no"))
                        {
                            MessageBox.Show("This song is not available on our server.");
                            server1Download.Enabled = false;
                        }
                        else if (message.StartsWith("*song list*"))
                        {
                            string[] songs = message.Split("*song list*");
                            string[] labels = songs[1].Split(" ");

                            songList.BeginInvoke((MethodInvoker)delegate
                            {
                                foreach (string s in labels)
                                {
                                    songList.Items.Add(s);
                                }
                            });
                        }
                    }
                }
                else
                {
                    MessageBox.Show("No data received from the server.");
                }
            }
            catch (IOException ex)
            {
                MessageBox.Show("IO error reading data from the server: " + ex.Message);
            }
            catch (ObjectDisposedException ex)
            {
                MessageBox.Show("The underlying network stream has been closed: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error performing server operations: " + ex.Message);
            }
        }


        private async Task downloadMusic(string download_song)
        {
            try
            {
                NetworkStream stream = server.GetStream();

                // Send request to server
                string request = "send4thisclient " + download_song;
                byte[] requestBytes = Encoding.UTF8.GetBytes(request);
                await stream.WriteAsync(requestBytes, 0, requestBytes.Length);
                await stream.FlushAsync();

                // Receive file size
                byte[] fileSizeBytes = new byte[8];
                int bytesRead = await stream.ReadAsync(fileSizeBytes, 0, fileSizeBytes.Length);
                long fileSize = BitConverter.ToInt64(fileSizeBytes, 0);

                if (bytesRead != fileSizeBytes.Length)
                {
                    MessageBox.Show("Error reading file size.");
                    return;
                }

                // Receive file data
                string currentFolder = Environment.CurrentDirectory;
                string filePath = Path.Combine(currentFolder, download_song);

                using (FileStream fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                {
                    byte[] buffer = new byte[fileSize];
                    int bytesReadData;
                    long totalBytesRead = 0;

                    while (totalBytesRead < fileSize && (bytesReadData = await stream.ReadAsync(buffer, 0, (int)Math.Min(buffer.Length, fileSize - totalBytesRead))) > 0)
                    {
                        await fileStream.WriteAsync(buffer, 0, bytesReadData);
                        totalBytesRead += bytesReadData;
                    }
                }

                MessageBox.Show("Downloaded");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error downloading file: " + ex.Message);
            }
        }

        private void stopBtn_Click(object sender, EventArgs e)
        {
            if (server != null)
            {
                server.Close();
            }
            Application.Exit();
        }
    }
}
