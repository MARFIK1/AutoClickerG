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
        private System.Windows.Forms.Timer autoClickerTimer;
        private Random random = new Random();
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

            autoClickerTimer = new System.Windows.Forms.Timer();
            autoClickerTimer.Interval = 5000;
            autoClickerTimer.Tick += (sender, e) =>
            {
                GlobalVariables.CoinBalance += GlobalVariables.AutoClickerValue;
                Coins.Text = ": " + GlobalVariables.CoinBalance.ToString();
            };
            autoClickerTimer.Start();
        }

        private void CTEM_Click(object sender, EventArgs e)
        {
            GlobalVariables.CoinBalance += GlobalVariables.ClickMultiplier;
            GlobalVariables.ClickCounter++;
            Coins.Text = ": " + GlobalVariables.CoinBalance.ToString();
            Diamonds.Text = ": " + GlobalVariables.DiamondBalance.ToString();
            Clicks.Text = ": " + GlobalVariables.ClickCounter.ToString();

            if (random.Next(100) < GlobalVariables.DiamondChance)
            {
                GlobalVariables.DiamondBalance++;
                Diamonds.Text = ": " + GlobalVariables.DiamondBalance.ToString();
            }
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