using System;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Windows.Forms;
using OnlineMusicLibraryServer;

namespace OnlineMusicLibraryServer
{


    public partial class Server1 : Form
    {
        private TCPconnectionServer server;

        public Server1()
        {
            InitializeComponent();
            server = new TCPconnectionServer();
        }

        private async void ConnectButton_Click(object sender, EventArgs e)
        {
            try
            {
                connectButton.Enabled = false;
                MessageBox.Show("Server Connected");
                await server.StartConnect();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            try
            {
                server.Stop();
                MessageBox.Show("Server Stopped");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}

