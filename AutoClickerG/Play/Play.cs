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
        public Play()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            CoinBalance.Text = "Account Balance: " + GlobalVariables.AccountBalance.ToString();
            ClickCounter.Text = "Click Counter: " + GlobalVariables.ClickCounter.ToString();

            coinTimer = new System.Windows.Forms.Timer();
            coinTimer.Interval = 3000;
            coinTimer.Tick += CoinTimer_Tick;
        }

        private void CTEM_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            int x, y;
            do
            {
                x = random.Next(0, this.Width - Coin.Width);
                y = random.Next(0, this.Height - Coin.Height);
            }
            while (IsCoinInPictureBox(x, y, CTEM) || IsCoinInPictureBox(x, y, BackToMenu));
            Coin.Location = new Point(x, y);
            Coin.Size = new Size(300, 300);
            Coin.Visible = true;
            GlobalVariables.AccountBalance++;
            GlobalVariables.ClickCounter++;
            CoinBalance.Text = "Account Balance: " + GlobalVariables.AccountBalance.ToString();
            ClickCounter.Text = "Click Counter: " + GlobalVariables.ClickCounter.ToString();
            coinTimer.Stop();
            coinTimer.Start();
        }

        private void CoinTimer_Tick(object sender, EventArgs e)
        {
            Coin.Visible = false;
            coinTimer.Stop();
        }

        private bool IsCoinInPictureBox(int x, int y, PictureBox pictureBox)
        {
            Rectangle coinRect = new Rectangle(x, y, Coin.Width, Coin.Height);
            Rectangle pictureBoxRect = new Rectangle(pictureBox.Location, pictureBox.Size);
            return coinRect.IntersectsWith(pictureBoxRect);
        }

        private void BackToMenu_Click(object sender, EventArgs e)
        {
            Menu menu = new Menu();
            menu.Show();
            this.Hide();
        }
    }
}