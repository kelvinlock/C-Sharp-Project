using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace GamesPlatform
{
    public partial class CreateAccount : Form
    {
        private string Path = "C:\\Users\\Kelvin\\source\\repos\\GamesPlatform\\Assets\\Data\\UserInfo.txt";
        CheckAssets chk;
        public CreateAccount()
        {
            InitializeComponent();
            chk = new CheckAssets(Path);
            SetPlaceholder(txtUsername, "請輸入使用者名稱");
            SetPlaceholder(txtPassword, "請輸入密碼");
            SetPlaceholder(txtEmail, "請輸入電子郵件地址");
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                if (!File.Exists(Path))
                {
                    using (StreamWriter sw = File.CreateText(Path))
                    {
                        sw.WriteLine("Username,Password,Email");
                    }
                }
                Register_User(txtUsername.Text, txtPassword.Text, txtEmail.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }   
        }
        // 註冊：新增使用者
        private void Register_User(string username, string password, string Email)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                MessageBox.Show("請輸入使用者名稱。", "欄位未填寫", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!chk.IsStrongPassword(password))
            {
                MessageBox.Show("密碼至少需包含 8 個字元，並包含大寫、小寫、數字與特殊符號。", "密碼太弱", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!chk.IsValidEmail(Email))
            {
                MessageBox.Show("請輸入電子郵件地址。", "欄位未填寫", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!chk.UserExists(username))
            {
                string newUser = $"{username.ToLower()},{password},{Email}";
                File.AppendAllLines(Path, new[] { newUser });
                MessageBox.Show("註冊成功！");

                txtUsername.Text = "請輸入使用者名稱";
                txtPassword.Text = "請輸入密碼";
                txtEmail.Text = "請輸入電子郵件地址";

                txtUsername.ForeColor = Color.Gray;
                txtPassword.ForeColor = Color.Gray;
                txtEmail.ForeColor = Color.Gray;
                return;
            }
            else
            {
                MessageBox.Show("此使用者名稱已被註冊，請選擇其他名稱。", "註冊失敗", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Text = "請輸入使用者名稱";
                txtPassword.Text = "請輸入密碼";
                txtEmail.Text = "請輸入電子郵件地址";

                txtUsername.ForeColor = Color.Gray;
                txtPassword.ForeColor = Color.Gray;
                txtEmail.ForeColor = Color.Gray;
            }
        }
        public class CheckAssets 
        {
            private string Path;
            public CheckAssets(string path)
            {
                this.Path = path;
            }
            public bool IsStrongPassword(string password)
            {
                return password.Length >= 8 &&
                       password.Any(char.IsDigit) &&
                       password.Any(char.IsUpper) &&
                       password.Any(char.IsLower) &&
                       password.Any(ch => "!@#$%^&*".Contains(ch));
            }
                // 檢查使用者是否存在
            public bool UserExists(string username)
            {
                if (!File.Exists(Path))
                    return false;

                var lines = File.ReadAllLines(Path);
                foreach (string line in lines)
                {
                    var parts = line.Split(',');
                    if (parts.Length >= 1 && parts[0] == username.ToLower())
                    {
                        return true;
                    }
                }
                return false;
            }
            public bool IsValidEmail(string email)
            {
                try
                {
                    var addr = new MailAddress(email);
                    return addr.Address == email;
                }
                catch
                {
                    return false;
                }
            }
        }


        // PlaceHolder
        private void SetPlaceholder(TextBox textBox, string placeholder)
        {
            textBox.ForeColor = Color.Gray;
            textBox.Text = placeholder;

            textBox.GotFocus += (s, e) =>
            {
                if (textBox.Text == placeholder)
                {
                    textBox.Text = "";
                    textBox.ForeColor = Color.Black;
                }
            };

            textBox.LostFocus += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(textBox.Text))
                {
                    textBox.Text = placeholder;
                    textBox.ForeColor = Color.Gray;
                }
            };
        }
    }
}
