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
        private System.Windows.Forms.Timer playTimeTimer;
        private DateTime playStartTime;
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
                GlobalVariables.TotalCoinsEarned += GlobalVariables.AutoClickerValue;
                Coins.Text = ": " + GlobalVariables.CoinBalance.ToString();

                for (int i = 0; i < 5; i++)
                {
                    var achievement = GlobalVariables.Achievements[i];
                    if (!achievement.IsCollected)
                    {
                        achievement.AddProgress(GlobalVariables.TotalCoinsEarned);
                    }
                }

                GlobalVariables.TotalCoinsEarned = 0;
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

            balanceDoublerCooldownTimer = new System.Windows.Forms.Timer();
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

            diamondRushCooldownTimer = new System.Windows.Forms.Timer();
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

            playTimeTimer = new System.Windows.Forms.Timer();
            playTimeTimer.Interval = 1000;
            playTimeTimer.Tick += (sender, e) =>
            {
                for (int i = 25; i < 28; i++)
                {
                    var achievement = GlobalVariables.Achievements[i];
                    if (!achievement.IsCollected)
                    {
                        achievement.AddProgress(1);
                    }
                }
            };
            playStartTime = DateTime.Now;
            playTimeTimer.Start();
        }

        private void CTEM_Click(object sender, EventArgs e)
        {   
            double coinsEarned = Math.Truncate(1 * GlobalVariables.ClickMultiplier * 10000) / 10000;
            int diamondsEarned;
            GlobalVariables.CoinBalance = Math.Truncate((GlobalVariables.CoinBalance + 1 * GlobalVariables.ClickMultiplier) * 10000) / 10000;
            GlobalVariables.ClickCounter++;
            GlobalVariables.TotalCoinsEarned += coinsEarned;

            double maxMultiplier = initialClickMultiplier * GlobalVariables.ClickComboMultiplier;

            if (BalanceDoublerButton.BackColor == Color.Green && GlobalVariables.ClickComboMultiplier > 1)
            {
                maxMultiplier *= 2;
            }
            if (GlobalVariables.ClickMultiplier < maxMultiplier)
            {
                double increment = (maxMultiplier - initialClickMultiplier) / 10;
                GlobalVariables.ClickMultiplier = Math.Min(maxMultiplier, Math.Truncate((GlobalVariables.ClickMultiplier + increment) * 10000) / 10000);
            }

            Coins.Text = ": " + GlobalVariables.CoinBalance.ToString();
            Diamonds.Text = ": " + GlobalVariables.DiamondBalance.ToString();
            Clicks.Text = ": " + GlobalVariables.ClickCounter.ToString();
            ClickMultiplier.Text = "Click Multiplier: " + GlobalVariables.ClickMultiplier.ToString() + "x";

            clickComboTimer.Stop();
            clickComboTimer.Start();

            if (GlobalVariables.IsDiamondRushActive || random.Next(100) < GlobalVariables.DiamondChance)
            {
                diamondsEarned = GlobalVariables.DiamondMultiplier;
                GlobalVariables.DiamondBalance += diamondsEarned;
                GlobalVariables.TotalDiamondsEarned += diamondsEarned;
                Diamonds.Text = ": " + GlobalVariables.DiamondBalance.ToString();
                for (int i = 5; i < 9; i++)
                {
                    var achievement = GlobalVariables.Achievements[i];
                    if (!achievement.IsCollected)
                    {
                        achievement.AddProgress(GlobalVariables.TotalDiamondsEarned);
                    }
                }
                GlobalVariables.TotalDiamondsEarned = 0;
            }

            for (int i = 0; i < 5; i++)
            {
                var achievement = GlobalVariables.Achievements[i];
                if (!achievement.IsCollected)
                {
                    achievement.AddProgress(GlobalVariables.TotalCoinsEarned);
                }
            }

            GlobalVariables.TotalCoinsEarned = 0;

            for (int i = 9; i < 13; i++)
            {
                var achievement = GlobalVariables.Achievements[i];
                if (!achievement.IsCollected)
                {
                    achievement.AddProgress(1);
                }
            }

            if (GlobalVariables.ClickMultiplier > GlobalVariables.HighestClickMultiplier)
            {
                GlobalVariables.HighestClickMultiplier = GlobalVariables.ClickMultiplier;
            }
            for (int i = 13; i < 16; i++)
            {
                var achievement = GlobalVariables.Achievements[i];
                if (!achievement.IsCollected)
                {
                    achievement.Progress = GlobalVariables.HighestClickMultiplier;
                }
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
                    for (int i = 16; i < 18; i++)
                    {
                        var achievement = GlobalVariables.Achievements[i];
                        if (!achievement.IsCollected)
                        {
                            achievement.AddProgress(1);
                        }
                    }
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
                    for (int i = 18; i < 20; i++)
                    {
                        var achievement = GlobalVariables.Achievements[i];
                        if (!achievement.IsCollected)
                        {
                            achievement.AddProgress(1);
                        }
                    }
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
            playTimeTimer.Stop();
        }
    }
}