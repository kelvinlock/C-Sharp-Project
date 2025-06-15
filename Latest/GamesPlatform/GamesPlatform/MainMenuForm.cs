using System;
using System.Drawing;
using System.Windows.Forms;

namespace GamesPlatform
{
    public class MainMenuForm : Form
    {
        private readonly string playerName;
        public MainMenuForm(string name)
        {
            playerName = name;
            Text = "Main Menu";
            ClientSize = new Size(300, 200);
            StartPosition = FormStartPosition.CenterScreen;
            BackColor = Color.Black;
            ForeColor = Color.White;

            var btnPlay = new Button { Text = "Play Game", Location = new Point(80, 30), Size = new Size(140, 40) };
            var btnHistory = new Button { Text = "History", Location = new Point(80, 80), Size = new Size(140, 40) };
            var btnExit = new Button { Text = "Exit", Location = new Point(80, 130), Size = new Size(140, 40) };

            foreach (var b in new[] { btnPlay, btnHistory, btnExit })
            {
                b.BackColor = Color.DimGray;
                b.ForeColor = Color.White;
            }

            btnPlay.Click += (s, e) => { Hide(); new GameForm(playerName).ShowDialog(); Show(); };
            btnHistory.Click += (s, e) => { Hide(); new RecordForm(playerName).ShowDialog(); Show(); };
            btnExit.Click += (s, e) => Close();

            Controls.AddRange(new Control[] { btnPlay, btnHistory, btnExit });
        }
    }
}
