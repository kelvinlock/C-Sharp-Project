using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;

namespace GamesPlatform
{
    public class GameForm : Form
    {
        private Deck deck;
        private Player player, cpu;
        private int playerWins, cpuWins;
        private readonly string playerName;

        private Label lblScore;
        private FlowLayoutPanel pnlPlayer, pnlCpu;
        private Button btnHit, btnStand, btnSurrender;


        public GameForm(string name)
        {
            playerName = name;
            Text = $"Blackjack 21 - {playerName}";
            ClientSize = new Size(800, 600);
            BackColor = Color.Black;
            ForeColor = Color.White;
            InitializeComponent();
            StartDeck();
        }

        private void InitializeComponent()
        {
            lblScore = new Label { Location = new Point(10, 10), AutoSize = true, ForeColor = Color.White };
            pnlCpu = new FlowLayoutPanel { Location = new Point(50, 50), Size = new Size(700, 150), BackColor = Color.Gray, Padding = new Padding(10) };
            pnlPlayer = new FlowLayoutPanel { Location = new Point(50, 400), Size = new Size(700, 150), BackColor = Color.Gray, Padding = new Padding(10) };
            btnHit = new Button { Text = "Hit", Location = new Point(200, 275), Size = new Size(80, 40) };
            btnStand = new Button { Text = "Stand", Location = new Point(300, 275), Size = new Size(80, 40) };
            btnSurrender = new Button { Text = "Surrender", Location = new Point(400, 275), Size = new Size(100, 40) };

            foreach (var b in new[] { btnHit, btnStand, btnSurrender })
            {
                b.BackColor = Color.DimGray;
                b.ForeColor = Color.White;
            }

            btnHit.Click += (s, e) => { player.AddCard(deck.DrawCard()); CpuPlay(); RefreshUI(); CheckRound(false); };
            btnStand.Click += (s, e) => CheckRound(true);
            btnSurrender.Click += (s, e) => { cpuWins++; RefreshUI(); RevealAndNext("Player surrendered"); };

            Controls.AddRange(new Control[] { lblScore, pnlCpu, pnlPlayer, btnHit, btnStand, btnSurrender });
        }

        private void StartDeck()
        {
            deck = new Deck();
            playerWins = cpuWins = 0;
            NextRound();
        }

        private void NextRound()
        {
            if (deck.CardsRemaining < 2)
            {
                File.AppendAllText("history.txt", $"{playerName}:{playerWins}-{cpuWins}");
                MessageBox.Show($"Game Over{playerName}: {playerWins} vs CPU: {cpuWins}", "Game Over");
                Close();
                return;
            }
            player = new Player();
            cpu = new Player();
            player.AddCard(deck.DrawCard());
            cpu.AddCard(deck.DrawCard());
            RefreshUI();
        }

        private void RefreshUI()
        {
            pnlPlayer.Controls.Clear();
            foreach (var c in player.Hand) pnlPlayer.Controls.Add(CreatePic(c, false));
            pnlCpu.Controls.Clear();
            foreach (var c in cpu.Hand) pnlCpu.Controls.Add(CreatePic(c, true));
            lblScore.Text = $"{playerName} Score: {playerWins} vs CPU: {cpuWins}";
        }

        private PictureBox CreatePic(Card c, bool back)
        {
            string fname = back ? "back.png" : c.GetImageFileName();
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", fname);
            var pb = new PictureBox { Size = new Size(80, 120), SizeMode = PictureBoxSizeMode.Zoom, Margin = new Padding(5) };
            if (File.Exists(path)) pb.Image = Image.FromFile(path);
            return pb;
        }

        private void CpuPlay()
        {
            int cs = cpu.GetScore();
            var vals = deck.GetRemainingValues();
            if (vals.Count > 0 && vals.Count(v => v + cs <= 21) > vals.Count / 2 && deck.CardsRemaining > 0)
                cpu.AddCard(deck.DrawCard());
        }

        private void CheckRound(bool final)
        {
            int ps = player.GetScore(), cs = cpu.GetScore();
            if (ps > 21)
            {
                cpuWins++; RefreshUI(); RevealAndNext("Player bust");
                return;
            }
            if (cs > 21)
            {
                playerWins++; RefreshUI(); RevealAndNext("CPU bust");
                return;
            }
            if (final)
            {
                if (ps > cs) playerWins++;
                else if (cs > ps) cpuWins++;
                RefreshUI(); RevealAndNext(ps > cs ? "Player wins" : ps < cs ? "CPU wins" : "Draw");
            }
        }

        private void RevealAndNext(string reason)
        {
            pnlPlayer.Controls.Clear();
            foreach (var c in player.Hand) pnlPlayer.Controls.Add(CreatePic(c, false));
            pnlCpu.Controls.Clear();
            foreach (var c in cpu.Hand) pnlCpu.Controls.Add(CreatePic(c, false));

            string msg = $"{reason}{playerName}: {player.GetScore()} vs CPU: {cpu.GetScore()}";
            MessageBox.Show(msg, "Round Over");

            if (reason == "Player surrendered")
            {
                File.AppendAllText("history.txt", $"{playerName}:{playerWins}-{cpuWins}");
                Close();
            }
            else
            {
                NextRound();
            }
        }
    }
}
