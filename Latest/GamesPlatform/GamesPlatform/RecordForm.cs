using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace GamesPlatform
{
    public class RecordForm : Form
    {
        public string filePath = Path.Combine(Application.StartupPath, "Assets", "Data", "UserInfo.txt");
        public string username;

        public RecordForm(string playerName)
        {
            Text = "History";
            ClientSize = new Size(300, 400);
            StartPosition = FormStartPosition.CenterScreen;
            BackColor = Color.Black;
            ForeColor = Color.White;

            var lb = new ListBox { Dock = DockStyle.Fill, BackColor = Color.Black, ForeColor = Color.White };
            Controls.Add(lb);

            var folder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Records");
            var path = Path.Combine(folder, $"{playerName}_records.txt");

            if (File.Exists(path))
            {
                string[] allLines = File.ReadAllLines(path);
                List<string> filteredLines = new List<string>();

                foreach (string line in allLines)
                {
                    if (line.StartsWith(playerName + ":"))
                    {
                        filteredLines.Add(line);
                    }
                }

                lb.Items.AddRange(filteredLines.ToArray());

                // ✅ 傳給 Email 的內容
                string emailContent = string.Join("\r\n", filteredLines);
                SendEmail(emailContent); // 要先實作這個方法
            }
        }
        private string GetEmail(string username)
        {
            try
            {
                if (!File.Exists(filePath))
                    return null;

                var lines = File.ReadAllLines(filePath);
                foreach (string line in lines)
                {
                    var parts = line.Split(',');
                    if (parts.Length >= 3 && parts[0].Trim().ToLower() == username.Trim().ToLower())
                    {
                        return parts[2].Trim();
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"讀取 Email 時發生錯誤：{ex.Message}");
                return null;
            }
        }

        private void SendEmail(string content)
        {
            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("kelvinlock0714@gmail.com");

                string email = GetEmail(username);
                if (string.IsNullOrEmpty(email))
                {
                    MessageBox.Show("找不到使用者的 Email。");
                    return;
                }

                mail.To.Add(email);
                mail.Subject = "對戰紀錄";
                mail.Body = content;

                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.Credentials = new System.Net.NetworkCredential("kelvinlock0714@gmail.com", "jggxldhhevgoctcf");
                smtp.EnableSsl = true;
                smtp.Send(mail);

                MessageBox.Show("紀錄已透過 Email 發送！");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Email 發送失敗：{ex.Message}", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
