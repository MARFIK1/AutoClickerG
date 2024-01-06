using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoClickerG
{
    public partial class Play : Form
    {
        private System.Windows.Forms.Timer coinTimer;
        private System.Windows.Forms.Timer diamondTimer;
        private System.Windows.Forms.Timer autoClickerTimer;
        private Random random;
        private List<PictureBox> pictureBoxes;
        private List<Label> labels;
        public Play()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.None;
            Coins.Text = ": " + GlobalVariables.CoinBalance.ToString();
            Diamonds.Text = ": " + GlobalVariables.DiamondBalance.ToString();
            Clicks.Text = ": " + GlobalVariables.ClickCounter.ToString();
            ClickMultiplier.Text = "Click Multiplier: " + GlobalVariables.ClickMultiplier.ToString() + "x";
            DiamondChance.Text = "Diamond Chance: " + GlobalVariables.DiamondChance.ToString() + "%";

            coinTimer = new System.Windows.Forms.Timer();
            coinTimer.Interval = 3000;
            coinTimer.Tick += CoinTimer_Tick;

            diamondTimer = new System.Windows.Forms.Timer();
            diamondTimer.Interval = 3000;
            diamondTimer.Tick += DiamondTimer_Tick;

            autoClickerTimer = new System.Windows.Forms.Timer();
            autoClickerTimer.Interval = 5000;
            autoClickerTimer.Tick += (sender, e) =>
            {
                GlobalVariables.CoinBalance += GlobalVariables.AutoClickerValue;
                Coins.Text = ": " + GlobalVariables.CoinBalance.ToString();
            };
            autoClickerTimer.Start();
            
            pictureBoxes = new List<PictureBox> { CTEM, CoinGif, DiamondGif, ClickGif, BackToMenu };
            labels = new List<Label> { Coins, Diamonds, Clicks, ClickMultiplier, DiamondChance };

            random = new Random();
        }

        private void CTEM_Click(object sender, EventArgs e)
        {
            var (x, y) = GenerateNewCoordinates();
            Coin.Location = new Point(x, y);
            Coin.Size = new Size(140, 140);
            Coin.Visible = true;
            GlobalVariables.CoinBalance += GlobalVariables.ClickMultiplier;
            GlobalVariables.ClickCounter++;
            Coins.Text = ": " + GlobalVariables.CoinBalance.ToString();
            Diamonds.Text = ": " + GlobalVariables.DiamondBalance.ToString();
            Clicks.Text = ": " + GlobalVariables.ClickCounter.ToString();
            coinTimer.Stop();
            coinTimer.Start();

            if (random.Next(100) < GlobalVariables.DiamondChance)
            {
                GlobalVariables.DiamondBalance++;
                Diamonds.Text = ": " + GlobalVariables.DiamondBalance.ToString();
                (x, y) = GenerateNewCoordinates();
                Diamond.Location = new Point(x, y);
                Diamond.Size = new Size(140, 140);
                Diamond.Visible = true;
                diamondTimer.Stop();
                diamondTimer.Start();
            }
        }

        private void CoinTimer_Tick(object sender, EventArgs e)
        {
            Coin.Visible = false;
            coinTimer.Stop();
        }

        private void DiamondTimer_Tick(object sender, EventArgs e)
        {
            Diamond.Visible = false;
            diamondTimer.Stop();
        }

        private bool IsInAnyPictureBox(int x, int y)
        {
            Rectangle rectNewPos = new Rectangle(x, y, Coin.Width, Coin.Height);
            return pictureBoxes.Any(pictureBox => rectNewPos.IntersectsWith(new Rectangle(pictureBox.Location, pictureBox.Size)));
        }

        private bool IsInAnyLabel(int x, int y)
        {
            Rectangle rectNewPos = new Rectangle(x, y, Coin.Width, Coin.Height);
            return labels.Any(label => rectNewPos.IntersectsWith(new Rectangle(label.Location, label.Size)));
        }

        private bool IsColliding(PictureBox a, PictureBox b)
        {
            Rectangle rectA = new Rectangle(a.Location, a.Size);
            Rectangle rectB = new Rectangle(b.Location, b.Size);
            return rectA.IntersectsWith(rectB);
        }

        private (int, int) GenerateNewCoordinates()
        {
            int x, y;
            do
            {
                x = random.Next(0, this.Width - Coin.Width);
                y = random.Next(0, this.Height - Coin.Height);
            }
            while (IsInAnyPictureBox(x, y) || IsInAnyLabel(x, y) || IsColliding(Coin, Diamond));
            return (x, y);
        }

        private void BackToMenu_Click(object sender, EventArgs e)
        {
            Menu menu = new Menu();
            menu.Show();
            this.Hide();
            autoClickerTimer.Stop();
        }
    }
}