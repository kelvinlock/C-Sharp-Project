using SuperSimpleTcp;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace TCP_Server
{
    public partial class TCPServer : Form
    {
        public TCPServer()
        {
            InitializeComponent();
        }

        SimpleTcpServer server;
        public string localIP;
        public int port = 9000;
        private void Form1_Load(object sender, EventArgs e)
        {
            btnSend.Enabled = false;
        }

        private void Events_DataReceived(object sender, DataReceivedEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                string message = Encoding.UTF8.GetString(e.Data.Array, e.Data.Offset, e.Data.Count);
                txtInfo.Text += $"{e.IpPort}: {message}{Environment.NewLine}";
            });
        }

        private void Events_ClientConnected(object sender, ConnectionEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                txtInfo.Text += $"{e.IpPort} Connected.{Environment.NewLine}";
                lstClientIP.Items.Add(e.IpPort);
            });
        }
        private void Events_ClientDisconnected(object sender, ConnectionEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                txtInfo.Text += $"{e.IpPort} Disconnected.{Environment.NewLine}";
                lstClientIP.Items.Remove(e.IpPort);
            });
        }


        private void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
                localIP = GetLocalIPAddress();
                server = new SimpleTcpServer($"0.0.0.0:{port}");
                txtIP.Text = $"{localIP}:{server.Port}";
                server.Events.ClientConnected += Events_ClientConnected;
                server.Events.ClientDisconnected += Events_ClientDisconnected;
                server.Events.DataReceived += Events_DataReceived;

                server.Start();
                if (server.IsListening)
                {
                    txtInfo.Text += $"Starting...{Environment.NewLine}";
                    txtInfo.Text += $"Server started at {localIP}:{port}{Environment.NewLine}";
                    btnStart.Enabled = false;
                    btnSend.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Connection error");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString(); // 通常是 192.168.x.x 或 10.x.x.x
                }
            }
            return "127.0.0.1";
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (server.IsListening)
            {
                if (lstClientIP.SelectedItem != null && !string.IsNullOrEmpty(txtMessage.Text))
                {
                    string target = lstClientIP.SelectedItem.ToString();
                    server.Send(target, txtMessage.Text);
                    txtInfo.AppendText($"[You to {target}]: {txtMessage.Text}\n");
                    txtMessage.Clear();
                }
            }
        }
    }
}
