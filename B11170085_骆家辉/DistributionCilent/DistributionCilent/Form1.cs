using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace DistributionCilent
{
    public partial class frmDistributionCilent : Form
    {
        // 变量宣告
        string strHostname; // 本机名称字符串
        string strHostIP; // 本机IP字符串
        IPAddress ipaHostIP; // 本机IPAddress型态IP
        private Thread thrReceive;  // 接收讯息之线程
        public Socket sktClientSocket; // 客戶端Socket
        string strGuest; // 客戶总数
        string strSend; // 传送字符串
        string strRich = ""; // RichTextBox 字符串
        public frmDistributionCilent()
        {
            InitializeComponent();
        }

        private void frmDistributionCilent_Load(object sender, EventArgs e)
        {
            // 取得本机的識別名稱及IP
            strHostname = Dns.GetHostName();
            ipaHostIP = Dns.Resolve(strHostname).AddressList[0];
            strHostIP = ipaHostIP.ToString();
            lblCilentIPAddress.Text = "Clinet IP Address:" + strHostIP;
            lblServerIPAddress.Text = "Server IP Address:" + strHostIP;
            // 设定按钮致能
            btnConnect.Enabled = true;
            btnDisconnect.Enabled = false;
            btnSend.Enabled = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                // 產生客戶端Socket
                sktClientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                // 產生服务器IPEndPoint型态变量
                IPEndPoint hostEP = new IPEndPoint(IPAddress.Parse(strHostIP), int.Parse(txtServerPort.Text));

                // 要求连線
                sktClientSocket.Connect(hostEP);
                btnConnect.Enabled = false;
                btnDisconnect.Enabled = true;
                btnSend.Enabled = true;
                Thread.Sleep(200);

                // 产生接收讯息之线程
                thrReceive = new Thread(new ThreadStart(Receive));
                thrReceive.Start();
                Thread.Sleep(200);
            }
            catch
            {
                ;
            }
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            byte[] byteSend = new byte[1024]; // 傳送用字节

            try
            {
                byteSend = Encoding.Unicode.GetBytes("#disconnect".ToCharArray());
                sktClientSocket.Send(byteSend, 0, byteSend.Length, SocketFlags.None);
                Thread.Sleep(50);
                sktClientSocket.Shutdown(SocketShutdown.Both);
                sktClientSocket.Close();
                btnConnect.Enabled = true;
                btnDisconnect.Enabled = false;
                btnSend.Enabled = false;
                // 结束接收线程，将客戶总数及传送次數做初始设定。
                thrReceive.Abort();
                Thread.Sleep(50);
            }
            catch
            {
                ;
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            byte[] byteSend = new byte[1024]; // 传送用字节

            try
            {
                strSend = txtSend.Text; // 数据封装
                byteSend = Encoding.Unicode.GetBytes(strSend.ToCharArray());
                sktClientSocket.Send(byteSend, 0, byteSend.Length, SocketFlags.None);
                Thread.Sleep(200);
            }
            catch
            {
                ;
            }
        }
        // Receive the message from Server
        private void Receive()
        {
            int ii; // length of received message
            byte[] byteReceieve = new byte[1024]; // byte array of received message
            EndPoint epRemote = sktClientSocket.RemoteEndPoint;

            while (true)
            {
                try
                {
                    ii = sktClientSocket.ReceiveFrom(byteReceieve, 0, byteReceieve.Length, SocketFlags.None, ref epRemote);
                    strRich = Encoding.Unicode.GetString(byteReceieve, 0, ii);
                    Show_Rich();
                }
                catch
                {
                }
            }
        }
        private void Show_Rich()//此副程式為了避免跨執行緒錯誤
        {
            if (rtbMessage.InvokeRequired)
            {
                rtbMessage.Invoke(new MethodInvoker(Show_Rich));
            }
            else
            {
                rtbMessage.Text = rtbMessage.Text + strRich + "\r\n";
            }
        }
    }
}
