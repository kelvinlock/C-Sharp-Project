/*
 * 名字：骆家辉
 * 学号：B11170085
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using System.Collections;

namespace DistributionServer
{
    public partial class frmDistributionServer : Form
    {
        // 全域变量宣告
        string strHostname; // 本机名称
        IPAddress ipaServerIP; // 本机IP地址
        private Socket sktServerSocket; // 服务器之Socket
        private Socket sktClientSocket; // 處理客戶端之Socket
        private IPEndPoint ipeServerHost; // 本机之IPEndPoint型态变量
        string strCilentInformation; // 客戶端IP地址及埠號
        string strCilentStatus; // 客戶端連線狀态
        string strCilentMessage; // 客戶端傳送之訊息
        string strSend; // 传送字符串
        string strRich = ""; // RichTextBox 字符串
        int iGuestTotal = 0; // 线上訪客总数
        string strGuestTotal = ""; // 线上訪客总数字符串
        private Thread thrMainService;  // MainService()之Thread
        private Thread thrCilentService;  // ClientService()之Thread
        private Hashtable htCilentSock = new Hashtable(); // 记录客戶端socket
        public frmDistributionServer()
        {
            InitializeComponent();
        }

        private void lblGuestTotal_Click(object sender, EventArgs e)
        {

        }

        private void frmDistributionServer_Load(object sender, EventArgs e)
        {
            strHostname = Dns.GetHostName();
            ipaServerIP = Dns.Resolve(strHostname).AddressList[0];
            lblServerIPAddress.Text = "Server IP Address:" + ipaServerIP.ToString();
            rtbMessage.Clear();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnListen_Click(object sender, EventArgs e)
        {
            thrMainService = new Thread(new ThreadStart(MainService));
            thrMainService.Start();
            btnListen.Enabled = false;
        }
        // 啟动Listen並偵測是否有Client端用戶要求連線
        private void MainService()
        {
            try
            {
                // Bind & Listen
                ipeServerHost = new IPEndPoint(ipaServerIP, int.Parse(txtServerPort.Text));
                sktServerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                sktServerSocket.Bind(ipeServerHost);
                sktServerSocket.Listen(50); //設定暫止連接佇列的長度為50

                while (true)  //無限迴圈等候服务要求
                {
                    // 接收服务要求後產生新的Socket
                    sktClientSocket = sktServerSocket.Accept();
                    // 建立執行緒來處理客戶端
                    // 不同客戶端連線進入者都會開啟一個thread
                    thrCilentService = new Thread(new ThreadStart(CilentService));
                    thrCilentService.Start();
                    Thread.Sleep(200); //等待傳值給thread中的變數，防止多用戶造成衝突	
                }
            }
            catch
            {
                ;
            }
        }
        //這個副程式，乃是無限迴圈中偵測是否有Client傳送訊息
        // *********************************************
        // *******關鍵步驟*****************************
        //   因為下面while()....裡面在會一直偵測client端所傳來的訊息
        //   如果寫成sktClientSocket.ReceiveFrom(...), 那麼只會有一組最後連線上的sktClientSocket可以保持暢通連線，那麼其它的client都無法使用這個被使用中的sktClientSocket了
        // 所以正確的寫法是先在while()外面先宣告Socket sktLocal = sktClientSocket，然後在while(..)內完全使用這個暫時的變數sktLocal，那麼就不會有被佔用的sktClientSocket這個問題了
        private void CilentService()
        {
            byte[] byteReceieve = new byte[1024]; // 儲存接收之訊息
            int iReceieveLength = 0; // 接收到訊息長度
            byte[] byteSend = new byte[1024]; // 儲存传送之訊息
            string strRemote = ""; // 客戶端位址字符串
            int iLocationColon = 0; // 客戶端位址字符串中冒号位置
            string strAll = ""; // 接收到之訊息字串
            string strClientPort = ""; // 客戶端埠号字符串
            // 建立專用的Socket, Thread
            Socket sktLocal = sktClientSocket;
            Thread thrClientThread = thrCilentService;

            // 顯示客戶端之相關訊息
            EndPoint epRemote = sktLocal.RemoteEndPoint;
            strRemote = epRemote.ToString();
            iLocationColon = strRemote.IndexOf(":");
            strClientPort = strRemote.Substring(iLocationColon + 1);
            strCilentInformation = "Client Information: " + strRemote;
            Show_lblCilentInformation();
            strCilentStatus = "Client Status: Connected";
            Show_lblClientStatus();
            strRich = "(" + strClientPort + "): Connected";
            Show_Rich();
            Broadcast(strRich);

            // 访客总数加一並记录客戶端讯息
            iGuestTotal++;
            strGuestTotal = "Guest Total: " + iGuestTotal.ToString();
            Show_lblGuestTotal();
            htCilentSock.Add(strClientPort, sktLocal);

            // 接收客戶端讯息並做相对应处理
            while (true)
            {
                iReceieveLength = sktLocal.ReceiveFrom(byteReceieve, 0, byteReceieve.Length, SocketFlags.None, ref epRemote);
                strAll = Encoding.Unicode.GetString(byteReceieve, 0, iReceieveLength);

                if (strAll == "#disconnect") // 客戶端要求斷線
                {
                    strCilentStatus = "Client Status: Disconnected";
                    Show_lblClientStatus();
                    iGuestTotal--;
                    strGuestTotal = "Guest Total: " + iGuestTotal.ToString();
                    Show_lblGuestTotal();
                    htCilentSock.Remove(strClientPort);
                    strRich = "(" + strClientPort + "): Disconnected";
                    Show_Rich();
                    Broadcast(strRich);
                    sktLocal.Shutdown(SocketShutdown.Both);
                    sktLocal.Close();
                    Thread.Sleep(200);
                    thrClientThread.Abort();
                }
                else  // 客戶端傳送資料
                {
                    strCilentStatus = "Client Status: Sending";
                    Show_lblClientStatus();
                    strRich = "(" + strClientPort + "):" + strAll;
                    Show_Rich();
                    Broadcast(strRich);
                }
            }
        }
        private void Broadcast(string strBroadcast) // 将讯息广播给所有客戶端
        {
            Socket sktBroadcast; // 广播用socket
            byte[] byteSend = new byte[1024]; // 儲存传送之訊息

            byteSend = Encoding.Unicode.GetBytes(strBroadcast.ToCharArray());
            // 將訊息傳給所有其它連線者
            foreach (DictionaryEntry deBroadcast in htCilentSock)
            {
                sktBroadcast = (Socket)deBroadcast.Value;  //客戶端的socket 
                sktBroadcast.Send(byteSend, 0, byteSend.Length, SocketFlags.None);
            }
        }

        private void Show_lblCilentInformation()//此副程式為了避免跨執行緒錯誤
        {
            if (lblCilentInformation.InvokeRequired)
            {
                lblCilentInformation.Invoke(new MethodInvoker(Show_lblCilentInformation));
            }
            else
            {
                lblCilentInformation.Text = strCilentInformation;
            }
        }

        private void Show_lblClientStatus()//此副程式為了避免跨執行緒錯誤
        {
            if (lblCilentStatus.InvokeRequired)
            {
                lblCilentStatus.Invoke(new MethodInvoker(Show_lblClientStatus));
            }
            else
            {
                lblCilentStatus.Text = strCilentStatus;
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

        private void Show_lblGuestTotal()//此副程式為了避免跨執行緒錯誤
        {
            if (lblGuestTotal.InvokeRequired)
            {
                lblGuestTotal.Invoke(new MethodInvoker(Show_lblGuestTotal));
            }
            else
            {
                lblGuestTotal.Text = strGuestTotal;
            }
        }

        private void lblCilentInformation_Click(object sender, EventArgs e)
        {

        }
    }
}
