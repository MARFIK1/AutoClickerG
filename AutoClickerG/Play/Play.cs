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
        private System.Windows.Forms.Timer clickComboTimer;
        private double initialClickMultiplier;
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
            DiamondMultiplier.Text = "Diamond Multiplier: " + GlobalVariables.DiamondMultiplier.ToString() + "x";
            DiamondChance.Text = "Diamond Chance: " + GlobalVariables.DiamondChance.ToString() + "%";

            autoClickerTimer = new System.Windows.Forms.Timer();
            autoClickerTimer.Interval = 5000;
            autoClickerTimer.Tick += (sender, e) =>
            {
                GlobalVariables.CoinBalance += GlobalVariables.AutoClickerValue;
                Coins.Text = ": " + GlobalVariables.CoinBalance.ToString();
            };
            autoClickerTimer.Start();

            initialClickMultiplier = GlobalVariables.ClickMultiplier;

            clickComboTimer = new System.Windows.Forms.Timer();
            clickComboTimer.Interval = 1000;
            clickComboTimer.Tick += (sender, e) =>
            {
                GlobalVariables.ClickMultiplier = initialClickMultiplier;
                ClickMultiplier.Text = "Click Multiplier: " + GlobalVariables.ClickMultiplier.ToString() + "x";
                clickComboTimer.Stop();
            };
        }

        private void CTEM_Click(object sender, EventArgs e)
        {
            GlobalVariables.CoinBalance = Math.Round(GlobalVariables.CoinBalance + 1 * GlobalVariables.ClickMultiplier, 3);
            GlobalVariables.ClickCounter++;

            double maxMultiplier = initialClickMultiplier * GlobalVariables.ClickComboMultiplier;

            if (GlobalVariables.ClickMultiplier < maxMultiplier)
            {
                double increment = (maxMultiplier - initialClickMultiplier) / 10;
                GlobalVariables.ClickMultiplier = Math.Min(maxMultiplier, Math.Round(GlobalVariables.ClickMultiplier + increment, 3));
            }

            Coins.Text = ": " + GlobalVariables.CoinBalance.ToString();
            Diamonds.Text = ": " + GlobalVariables.DiamondBalance.ToString();
            Clicks.Text = ": " + GlobalVariables.ClickCounter.ToString();
            ClickMultiplier.Text = "Click Multiplier: " + GlobalVariables.ClickMultiplier.ToString() + "x";

            clickComboTimer.Stop();
            clickComboTimer.Start();

            if (random.Next(100) < GlobalVariables.DiamondChance)
            {
                GlobalVariables.DiamondBalance += GlobalVariables.DiamondMultiplier;
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