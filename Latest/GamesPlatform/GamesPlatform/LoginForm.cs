using System;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GamesPlatform
{
    public partial class GamePlatform : Form
    {
        // 🔧 Fields
        private CancellationTokenSource cancellationTokenSource;
        private Task backgroundTask;
        string filePath = "C:\\Users\\Kelvin\\source\\repos\\GamesPlatform\\Assets\\Data\\UserInfo.txt";

        // 🎯 WinAPI Constants and Imports
        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HT_CAPTION = 0x2;

        [DllImport("user32.dll")]
        private static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        // 🔨 Constructor
        public GamePlatform()
        {
            InitializeComponent();
            InitializeCustomUI();
            EnsureFileExists(filePath);
            this.FormClosing += GamePlatform_FormClosing; 
            this.Load += GamePlatform_Load;
        }

        // 🎨 UI Initialization
        private void InitializeCustomUI()
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Size = new Size(800, 600);
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;

            if (this.Controls["Upper"] is Panel upperPanel)
            {
                upperPanel.MouseDown += Upper_MouseDown;
            }
            else
            {
                MessageBox.Show("Upper panel not found. Dragging will not be enabled.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ApplyRoundedCorners(int radius)
        {
            using (System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath())
            {
                path.AddArc(0, 0, radius, radius, 180, 90);
                path.AddArc(this.Width - radius, 0, radius, radius, 270, 90);
                path.AddArc(this.Width - radius, this.Height - radius, radius, radius, 0, 90);
                path.AddArc(0, this.Height - radius, radius, radius, 90, 90);
                this.Region = new Region(path);
            }
        }

        // 🧠 Lifecycle Events
        private void GamePlatform_Load(object sender, EventArgs e)
        {
            ApplyRoundedCorners(20);
            StartBackgroundTask();
        }

        private void GamePlatform_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (cancellationTokenSource != null)
            {
                cancellationTokenSource.Cancel();
                try
                {
                    backgroundTask?.Wait();
                }
                catch (AggregateException) { }
                cancellationTokenSource.Dispose();
            }
        }

        // ⏳ Background Task
        private void StartBackgroundTask()
        {
            cancellationTokenSource = new CancellationTokenSource();
            CancellationToken token = cancellationTokenSource.Token;

            backgroundTask = Task.Run(() =>
            {
                try
                {
                    while (!token.IsCancellationRequested)
                    {
                        Thread.Sleep(100);
                    }
                }
                catch (OperationCanceledException e)
                {
                    MessageBox.Show($"{e}", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }, token);
        }

        // 🧩 Event Handlers (UI Buttons & Links)
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Upper_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void linklblCreateAccount_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            using (CreateAccount createAccount = new CreateAccount())
            {
                createAccount.ShowDialog();
            }
            this.Show();
        }

        private void linklblForgotPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            using (UpdatePassword updatePassword = new UpdatePassword())
            {
                updatePassword.ShowDialog();
            }
            this.Show();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBoxUsername.Text) || string.IsNullOrWhiteSpace(txtboxPassword.Text))
            {
                MessageBox.Show("請輸入使用者名稱和密碼。", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!UserExists(txtBoxUsername.Text))
            {
                MessageBox.Show("使用者不存在。請先創建帳號。", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!IsPasswordCorrect(txtBoxUsername.Text, txtboxPassword.Text))
            {
                MessageBox.Show("帳號或密碼錯誤，請再試一次！", "登入失敗", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string[] lines = File.ReadAllLines(filePath);
            bool isAuthenticated = false;
            foreach (string line in lines)
            {
                var parts = line.Split(',');
                if (parts.Length >= 2 && parts[0] == txtBoxUsername.Text && parts[1] == txtboxPassword.Text)
                {
                    isAuthenticated = true;
                    break;
                }
            }

            if (isAuthenticated)
            {
                MessageBox.Show("登入成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                using (MainMenuForm mainmenuform = new MainMenuForm(txtBoxUsername.Text))
                {
                    mainmenuform.ShowDialog();
                }
                this.Show();
            }
            else
            {
                MessageBox.Show("使用者名稱或密碼錯誤。", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        // 🧾 File/Account Utilities
        private void EnsureFileExists(string path)
        {
            try
            {
                if (!File.Exists(path))
                {
                    using (StreamWriter sw = File.CreateText(path))
                    {
                        sw.WriteLine("Username,Password,Email");
                    }
                }
                return ; 
            }
            catch (Exception ex)
            {
                MessageBox.Show($"檔案路徑錯誤: {ex.Message}", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return ; 
            }
        }


        private bool UserExists(string username)
        {
            var lines = File.ReadAllLines(filePath);
            foreach (string line in lines)
            {
                var parts = line.Split(',');
                if (parts.Length >= 1 && parts[0] == username)
                {
                    return true;
                }
            }
            return false;
        }
        private bool IsPasswordCorrect(string username, string password)
        {
            try
            {
                var lines = File.ReadAllLines(filePath);
                foreach (var line in lines)
                {
                    var parts = line.Split(',');
                    if (parts.Length < 2) continue;

                    if (parts[0].Trim().ToLower() == username.Trim().ToLower())
                    {
                        return parts[1] == password;
                    }
                }
                return false; // 使用者名稱不存在
            }
            catch (Exception ex)
            {
                MessageBox.Show($"讀取帳號資料時發生錯誤: {ex.Message}", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false; // 發生例外錯誤時預設驗證失敗
            }
        }

    }
}
