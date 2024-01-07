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
        private System.Windows.Forms.Timer balanceDoublerTimer;
        private System.Windows.Forms.Timer balanceDoublerCooldownTimer;
        private DateTime balanceDoublerCooldownStartTime;
        private System.Windows.Forms.Timer diamondRushTimer;
        private System.Windows.Forms.Timer diamondRushCooldownTimer;
        private DateTime diamondRushCooldownStartTime;
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
                if (BalanceDoublerButton.BackColor == Color.Green)
                {
                    GlobalVariables.ClickMultiplier = initialClickMultiplier * 2;
                }
                else
                {
                    GlobalVariables.ClickMultiplier = initialClickMultiplier;
                }
                ClickMultiplier.Text = "Click Multiplier: " + GlobalVariables.ClickMultiplier.ToString() + "x";
                clickComboTimer.Stop();
            };

            System.Windows.Forms.Timer balanceDoublerCooldownTimer = new System.Windows.Forms.Timer();
            balanceDoublerCooldownTimer.Interval = 10000;
            balanceDoublerCooldownTimer.Tick += (s, args) =>
            {
                if (BalanceDoublerButton.BackColor == Color.LightCoral)
                {
                    if (GlobalVariables.IsBalanceDoublerBought == 1)
                    {
                        BalanceDoublerButton.BackColor = Color.Orange;
                    }
                }
                balanceDoublerCooldownTimer.Stop();
            };

            if (GlobalVariables.IsBalanceDoublerBought == 1)
            {
                BalanceDoublerButton.BackColor = Color.Orange;
            }
            BalanceDoublerButton.Click += BalanceDoublerButton_Click;
            balanceDoublerTimer = new System.Windows.Forms.Timer();
            if (GlobalVariables.BalanceDoublerTimer > 0)
            {
                balanceDoublerTimer.Interval = GlobalVariables.BalanceDoublerTimer;
                balanceDoublerTimer.Tick += (sender, e) =>
                {
                    GlobalVariables.ClickMultiplier = initialClickMultiplier;
                    GlobalVariables.DiamondMultiplier /= 2;

                    ClickMultiplier.Text = "Click Multiplier: " + GlobalVariables.ClickMultiplier.ToString() + "x";
                    DiamondMultiplier.Text = "Diamond Multiplier: " + GlobalVariables.DiamondMultiplier.ToString() + "x";

                    BalanceDoublerButton.BackColor = Color.LightCoral;
                    balanceDoublerCooldownStartTime = DateTime.Now;

                    balanceDoublerTimer.Stop();
                    balanceDoublerCooldownTimer.Start();
                };
            }

            System.Windows.Forms.Timer diamondRushCooldownTimer = new System.Windows.Forms.Timer();
            diamondRushCooldownTimer.Interval = 10000;
            diamondRushCooldownTimer.Tick += (s, args) =>
            {
                if (DiamondRushButton.BackColor == Color.LightCoral)
                {
                    if (GlobalVariables.IsDiamondRushBought == 1)
                    {
                        DiamondRushButton.BackColor = Color.Orange;
                    }
                }
                diamondRushCooldownTimer.Stop();
            };

            if (GlobalVariables.IsDiamondRushBought == 1)
            {
                DiamondRushButton.BackColor = Color.Orange;
            }
            DiamondRushButton.Click += DiamondRushButton_Click;
            diamondRushTimer = new System.Windows.Forms.Timer();
            if (GlobalVariables.DiamondRushTimer > 0)
            {
                diamondRushTimer.Interval = GlobalVariables.DiamondRushTimer;
                diamondRushTimer.Tick += (sender, e) =>
                {
                    GlobalVariables.IsDiamondRushActive = false;
                    DiamondChance.Text = "Diamond Chance: " + GlobalVariables.DiamondChance.ToString() + "%";
                    DiamondRushButton.BackColor = Color.LightCoral;
                    diamondRushCooldownStartTime = DateTime.Now;

                    diamondRushTimer.Stop();
                    diamondRushCooldownTimer.Start();
                };
            }
        }

        private void CTEM_Click(object sender, EventArgs e)
        {
            GlobalVariables.CoinBalance = Math.Round(GlobalVariables.CoinBalance + 1 * GlobalVariables.ClickMultiplier, 3);
            GlobalVariables.ClickCounter++;

            double maxMultiplier = initialClickMultiplier * GlobalVariables.ClickComboMultiplier;

            if (BalanceDoublerButton.BackColor == Color.Green && GlobalVariables.ClickComboMultiplier > 1)
            {
                maxMultiplier *= 2;
            }
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

            if (GlobalVariables.IsDiamondRushActive || random.Next(100) < GlobalVariables.DiamondChance)
            {
                GlobalVariables.DiamondBalance += GlobalVariables.DiamondMultiplier;
                Diamonds.Text = ": " + GlobalVariables.DiamondBalance.ToString();
            }
        }

        private void BalanceDoublerButton_Click(object sender, EventArgs e)
        {
            if (BalanceDoublerButton.BackColor == Color.Orange)
            {
                DialogResult result = MessageBox.Show("Do you want to use Balance Doubler?", "Confirmation", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    BalanceDoublerButton.BackColor = Color.Green;
                    initialClickMultiplier = GlobalVariables.ClickMultiplier;
                    GlobalVariables.ClickMultiplier *= 2;
                    GlobalVariables.DiamondMultiplier *= 2;
                    ClickMultiplier.Text = "Click Multiplier: " + GlobalVariables.ClickMultiplier.ToString() + "x";
                    DiamondMultiplier.Text = "Diamond Multiplier: " + GlobalVariables.DiamondMultiplier.ToString() + "x";
                    balanceDoublerTimer.Start();
                }
            }
            else if (BalanceDoublerButton.BackColor == Color.Green)
            {
                MessageBox.Show("You need to wait for the current Balance Doubler to finish...", "Information", MessageBoxButtons.OK);
            }
            else if (BalanceDoublerButton.BackColor == Color.LightCoral)
            {
                if (GlobalVariables.IsBalanceDoublerBought == 1)
                {
                    var remainingTime = Math.Round((balanceDoublerCooldownTimer.Interval / 1000) - (DateTime.Now - balanceDoublerCooldownStartTime).TotalSeconds);
                    if (remainingTime < 0)
                    {
                        remainingTime = 0;
                    }
                    MessageBox.Show($"You need to wait for {remainingTime} seconds...", "Information", MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show("Firstly you need to buy this upgrade", "Information", MessageBoxButtons.OK);
                }
            }
        }

        private void DiamondRushButton_Click(object sender, EventArgs e)
        {
            if (DiamondRushButton.BackColor == Color.Orange)
            {
                DialogResult result = MessageBox.Show("Do you want to use Diamond Rush?", "Confirmation", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    DiamondRushButton.BackColor = Color.Green;
                    GlobalVariables.IsDiamondRushActive = true;
                    DiamondChance.Text = "Diamond Chance: 100%";
                    diamondRushTimer.Start();
                }
            }
            else if (DiamondRushButton.BackColor == Color.Green)
            {
                MessageBox.Show("You need to wait for the current Diamond Rush to finish...", "Information", MessageBoxButtons.OK);
            }
            else if (DiamondRushButton.BackColor == Color.LightCoral)
            {
                if (GlobalVariables.IsDiamondRushBought == 1)
                {
                    var remainingTime = Math.Round((diamondRushCooldownTimer.Interval / 1000) - (DateTime.Now - diamondRushCooldownStartTime).TotalSeconds);
                    MessageBox.Show($"You need to wait for {remainingTime} seconds...", "Information", MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show("Firstly you need to buy this upgrade", "Information", MessageBoxButtons.OK);
                }
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