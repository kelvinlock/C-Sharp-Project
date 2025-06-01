using SuperSimpleTcp;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace TCP_Client
{
    public partial class TCPClient : Form
    {
        public TCPClient()
        {
            InitializeComponent();
        }

        SimpleTcpClient client;

        private void Form1_Load(object sender, EventArgs e)
        {
            btnSend.Enabled = false;
        }
        private void Connected(object sender, EventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                txtInfo.Text += $"Connected to server.{Environment.NewLine}";
            });
        }

        private void Disconnected(object sender, EventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                txtInfo.Text += $"Disconnected from server.{Environment.NewLine}";
            });
        }

        private void DataReceived(object sender, DataReceivedEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                string msg = Encoding.UTF8.GetString(e.Data.Array, e.Data.Offset, e.Data.Count);
                txtInfo.Text += $"[Server]: {msg}{Environment.NewLine}";
            });
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

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                string localIP = GetLocalIPAddress();
                client = new SimpleTcpClient($"{localIP}:9000");
                txtIP.Text = $"{localIP}";
                client.Events.Connected += Connected;
                client.Events.Disconnected += Disconnected;
                client.Events.DataReceived += DataReceived;

                client.Connect();
                btnSend.Enabled = true;
                btnConnect.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (client.IsConnected)
            {
                if (!string.IsNullOrEmpty(txtMessage.Text))
                {
                    client.Send(txtMessage.Text);
                    txtInfo.AppendText($"[You]: {txtMessage.Text}\n");
                    txtMessage.Clear();
                }
            }
        }
    }
}
