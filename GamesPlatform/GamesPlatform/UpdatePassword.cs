using System;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Windows.Forms;
using System.IO;
using System.ComponentModel.Design;

namespace GamesPlatform
{
    public partial class UpdatePassword : Form
    {
        private string Path = "C:\\Users\\Kelvin\\source\\repos\\GamesPlatform\\Assets\\Data\\UserInfo.txt";
        CheckAssets chk;
        public UpdatePassword()
        {
            InitializeComponent();
            chk = new CheckAssets(Path);
            SetPlaceholder(txtboxUsername,"請輸入使用者名稱");
            SetPlaceholder(txtboxPassword, "請輸入新密碼");
            SetPlaceholder(txtboxReEnterPassword, "請從新輸入新密碼");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        { 
            Update_Password(txtboxUsername.Text, txtboxPassword.Text, txtboxReEnterPassword.Text);
        }
        private void Update_Password(string username, string newpassword, string rnewpassword)
        {
            if(!chk.UserExists(username))
            {
                MessageBox.Show("使用者不存在。", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (newpassword != rnewpassword)
            {
                MessageBox.Show("新密碼與確認密碼不一致，請重新輸入。", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!chk.IsStrongPassword(newpassword))
            {
                MessageBox.Show("密碼至少需包含 8 個字元，並包含大寫、小寫、數字與特殊符號。", "密碼太弱", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var lines = File.ReadAllLines(Path);
            for (int i = 0; i < lines.Length; i++)
            {
                var parts = lines[i].Split(',');
                if (parts[0].ToLower() == username.ToLower())
                {
                    parts[1] = newpassword;
                    lines[i] = string.Join(",", parts);
                    break;
                }
            }
            File.WriteAllLines(Path, lines);
            MessageBox.Show("密碼已更新！");
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
