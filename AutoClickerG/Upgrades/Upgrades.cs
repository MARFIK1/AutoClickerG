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
    public partial class Upgrades : Form
    {
        private static Upgrades _instance;

        public static Upgrades Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Upgrades();
                }
                return _instance;
            }
        }

        private Dictionary<Button, int> upgradeCosts;
        private Dictionary<Button, bool> upgradesPurchased = new Dictionary<Button, bool>();

        public Upgrades()
        {
            InitializeComponent();
            this.Load += Upgrades_Load;
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.None;
            BackToMenu.Click += BackToMenu_Click;

            upgradeCosts = new Dictionary<Button, int>()
            {
                { ClickBoostI, 10 },
                { ClickBoostII, 20 },
                { ClickBoostIII, 30 },
                { ClickBoostIV, 40 },
                { ClickBoostV, 50 },
                { AutoClickerI, 10 },
                { AutoClickerII, 20 },
                { AutoClickerIII, 30 },
                { AutoClickerIV, 40 },
                { AutoClickerV, 50 },
                { ClickComboI, 10 },
                { ClickComboII, 20 },
                { ClickComboIII, 30 },
                { LuckyDiamondsI, 10 },
                { LuckyDiamondsII, 20 },
                { LuckyDiamondsIII, 30 },
                { LuckyDiamondsIV, 40 },
                { LuckyDiamondsV, 50 },
                { DiamondBoostI, 10 },
                { DiamondBoostII, 20 },
                { DiamondBoostIII, 30 },
                { DiamondBoostIV, 40 },
                { BalanceDoublerI, 10 },
                { BalanceDoublerII, 20 },
                { BalanceDoublerIII, 30 },
                { DiamondRushI, 10 },
                { DiamondRushII, 20 },
                { DiamondRushIII, 30 },
                { DiamondRushIV, 40 },
            };

            foreach (var upgrade in upgradeCosts)
            {
                var button = upgrade.Key;
                var cost = upgrade.Value;
                var lines = button.Text.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
                if (lines.Length >= 2 && lines[1].StartsWith("Cost:"))
                {
                    lines[1] = $"Cost: {cost}";
                }
                button.Text = string.Join("\r\n", lines);
            }

            Dictionary<Button, (Button nextButton, PictureBox nextArrow)> nextUpgrade = new Dictionary<Button, (Button, PictureBox)>
            {
                { ClickBoostI, (ClickBoostII, UpgradeArrow2) },
                { ClickBoostII, (ClickBoostIII, UpgradeArrow3 )},
                { ClickBoostIII, (ClickBoostIV, UpgradeArrow4 )},
                { ClickBoostIV, (ClickBoostV, UpgradeArrow5 )},
                { AutoClickerI, (AutoClickerII, UpgradeArrow7 )},
                { AutoClickerII, (AutoClickerIII, UpgradeArrow8 )},
                { AutoClickerIII, (AutoClickerIV, UpgradeArrow9 )},
                { AutoClickerIV, (AutoClickerV, UpgradeArrow10 )},
                { ClickComboI, (ClickComboII, UpgradeArrow12 )},
                { ClickComboII, (ClickComboIII, UpgradeArrow13 )},
                { LuckyDiamondsI, (LuckyDiamondsII, UpgradeArrow15 )},
                { LuckyDiamondsII, (LuckyDiamondsIII, UpgradeArrow16 )},
                { LuckyDiamondsIII, (LuckyDiamondsIV, UpgradeArrow17 )},
                { LuckyDiamondsIV, (LuckyDiamondsV, UpgradeArrow18 )},
                { DiamondBoostI, (DiamondBoostII, UpgradeArrow20 )},
                { DiamondBoostII, (DiamondBoostIII, UpgradeArrow21 )},
                { DiamondBoostIII, (DiamondBoostIV, UpgradeArrow22 )},
                { BalanceDoublerI, (BalanceDoublerII, UpgradeArrow24 )},
                { BalanceDoublerII, (BalanceDoublerIII, UpgradeArrow25 )},
                { DiamondRushI, (DiamondRushII, UpgradeArrow27 )},
                { DiamondRushII, (DiamondRushIII, UpgradeArrow28 )},
                { DiamondRushIII, (DiamondRushIV, UpgradeArrow29 )},
            };
            
            Dictionary<Button, double> upgradeRewards = new Dictionary<Button, double>()
            {
                { ClickBoostI, 1.25 },
                { ClickBoostII, 1.5 },
                { ClickBoostIII, 2 },
                { ClickBoostIV, 3 },
                { ClickBoostV, 4 },
                { AutoClickerI, 1 },
                { AutoClickerII, 5 },
                { AutoClickerIII, 10 },
                { AutoClickerIV, 25 },
                { AutoClickerV, 50 },
                { ClickComboI, 1.5},
                { ClickComboII, 2},
                { ClickComboIII, 3},
                { LuckyDiamondsI, 2 },
                { LuckyDiamondsII, 3 },
                { LuckyDiamondsIII, 4 },
                { LuckyDiamondsIV, 5 },
                { LuckyDiamondsV, 10 },
                { DiamondBoostI, 2 },
                { DiamondBoostII, 3 },
                { DiamondBoostIII, 4 },
                { DiamondBoostIV, 5 },
                { BalanceDoublerI, 5000 },
                { BalanceDoublerII, 5000 },
                { BalanceDoublerIII, 7000 },
                { DiamondRushI, 3000 },
                { DiamondRushII, 5000 },
                { DiamondRushIII, 7000 },
                { DiamondRushIV, 10000 },
            };

            Dictionary<List<Button>, bool> categoryProgressAdded = new Dictionary<List<Button>, bool>
            {
                { new List<Button> { ClickBoostI, ClickBoostII, ClickBoostIII, ClickBoostIV, ClickBoostV }, false },
                { new List<Button> { AutoClickerI, AutoClickerII, AutoClickerIII, AutoClickerIV, AutoClickerV }, false },
                { new List<Button> { ClickComboI, ClickComboII, ClickComboIII }, false },
                { new List<Button> { LuckyDiamondsI, LuckyDiamondsII, LuckyDiamondsIII, LuckyDiamondsIV, LuckyDiamondsV }, false },
                { new List<Button> { DiamondBoostI, DiamondBoostII, DiamondBoostIII, DiamondBoostIV }, false },
                { new List<Button> { BalanceDoublerI, BalanceDoublerII, BalanceDoublerIII }, false },
                { new List<Button> { DiamondRushI, DiamondRushII, DiamondRushIII, DiamondRushIV }, false }
            };

            foreach (var upgrade in upgradeCosts)
            {
                upgradesPurchased.Add(upgrade.Key, false);
                var localUpgrade = upgrade;
                localUpgrade.Key.Click += (sender, e) =>
                {
                    if (upgradesPurchased.ContainsKey(localUpgrade.Key) && upgradesPurchased[localUpgrade.Key])
                    {
                        MessageBox.Show("Już kupiłeś te ulepszenie.", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (GlobalVariables.CoinBalance >= localUpgrade.Value)
                    {
                        DialogResult dialogResult = MessageBox.Show("Czy na pewno chcesz zakupić to ulepszenie?", "Potwierdzenie zakupu", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dialogResult == DialogResult.Yes)
                        {
                            GlobalVariables.CoinBalance -= localUpgrade.Value;
                            CoinBalance.Text = ": " + GlobalVariables.CoinBalance.ToString();
                            localUpgrade.Key.BackColor = Color.Green;
                            upgradesPurchased[localUpgrade.Key] = true;
                            localUpgrade.Key.Enabled = false;
                            if (nextUpgrade.ContainsKey(localUpgrade.Key))
                            {
                                nextUpgrade[localUpgrade.Key].nextButton.Visible = true;
                                nextUpgrade[localUpgrade.Key].nextArrow.Visible = true;
                            }
                            if (upgradeRewards.ContainsKey(localUpgrade.Key))
                            {
                                if (localUpgrade.Key == ClickBoostI || localUpgrade.Key == ClickBoostII || localUpgrade.Key == ClickBoostIII || localUpgrade.Key == ClickBoostIV || localUpgrade.Key == ClickBoostV)
                                {
                                    GlobalVariables.ClickMultiplier = upgradeRewards[localUpgrade.Key];
                                }
                                if (localUpgrade.Key == AutoClickerI || localUpgrade.Key == AutoClickerII || localUpgrade.Key == AutoClickerIII || localUpgrade.Key == AutoClickerIV || localUpgrade.Key == AutoClickerV)
                                {
                                    GlobalVariables.AutoClickerValue = upgradeRewards[localUpgrade.Key];
                                }
                                if (localUpgrade.Key == ClickComboI || localUpgrade.Key == ClickComboII || localUpgrade.Key == ClickComboIII)
                                {
                                    GlobalVariables.ClickComboMultiplier = upgradeRewards[localUpgrade.Key];
                                }
                                if (localUpgrade.Key == LuckyDiamondsI || localUpgrade.Key == LuckyDiamondsII || localUpgrade.Key == LuckyDiamondsIII || localUpgrade.Key == LuckyDiamondsIV || localUpgrade.Key == LuckyDiamondsV)
                                {
                                    GlobalVariables.DiamondChance = upgradeRewards[localUpgrade.Key];
                                }  
                                if (localUpgrade.Key == DiamondBoostI || localUpgrade.Key == DiamondBoostII || localUpgrade.Key == DiamondBoostIII || localUpgrade.Key == DiamondBoostIV)
                                {
                                    GlobalVariables.DiamondMultiplier = (int)upgradeRewards[localUpgrade.Key];
                                }
                                if (localUpgrade.Key == BalanceDoublerI || localUpgrade.Key == BalanceDoublerII || localUpgrade.Key == BalanceDoublerIII)
                                {
                                    GlobalVariables.BalanceDoublerTimer = (int)upgradeRewards[localUpgrade.Key];
                                    GlobalVariables.IsBalanceDoublerBought = 1;
                                }
                                if (localUpgrade.Key == DiamondRushI || localUpgrade.Key == DiamondRushII || localUpgrade.Key == DiamondRushIII || localUpgrade.Key == DiamondRushIV)
                                {
                                    GlobalVariables.DiamondRushTimer = (int)upgradeRewards[localUpgrade.Key];
                                    GlobalVariables.IsDiamondRushBought = 1;
                                }
                            }

                            for (int i = 20; i < 23; i++)
                            {
                                var achievement = GlobalVariables.Achievements[i];
                                if (!achievement.IsCollected)
                                {
                                    achievement.AddProgress(1);
                                }
                            }

                            foreach (var category in categoryProgressAdded.Keys.ToList())
                            {
                                bool allUpgradesPurchased = category.All(b => upgradesPurchased.ContainsKey(b) && upgradesPurchased[b]);

                                if (allUpgradesPurchased && !categoryProgressAdded[category])
                                {
                                    for (int i = 23; i < 25; i++)
                                    {
                                        var achievement = GlobalVariables.Achievements[i];
                                        if (!achievement.IsCollected)
                                        {
                                            achievement.AddProgress(1);
                                        }
                                    }
                                    categoryProgressAdded[category] = true;
                                }
                                else if (!allUpgradesPurchased && categoryProgressAdded[category])
                                {
                                    categoryProgressAdded[category] = false;
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Nie masz wystarczającej liczby monet na zakup tego ulepszenia.", "Odmowa zakupu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                };
            }
        }
        private void Upgrades_Load(object sender, EventArgs e)
        {
            CoinBalance.Text = ": " + GlobalVariables.CoinBalance.ToString();
            DiamondBalance.Text = ": " + GlobalVariables.DiamondBalance.ToString();

            GlobalVariables.OnCoinBalanceChanged += balance =>
            {
                CoinBalance.Text = ": " + balance.ToString();

                foreach (var upgrade in upgradeCosts)
                {
                    if (!upgradesPurchased.ContainsKey(upgrade.Key) || !upgradesPurchased[upgrade.Key])
                    {
                        if (balance >= upgrade.Value)
                        {
                            upgrade.Key.BackColor = Color.Orange;
                        }
                        else
                        {
                            upgrade.Key.BackColor = Color.LightCoral;
                        }
                    }
                }
            };

            GlobalVariables.OnDiamondBalanceChanged += balance =>
            {
                DiamondBalance.Text = ": " + balance.ToString();
            };

            foreach (var upgrade in upgradeCosts)
            {
                if (upgradesPurchased.ContainsKey(upgrade.Key) && upgradesPurchased[upgrade.Key])
                {
                    upgrade.Key.BackColor = Color.Green;
                }
                else if (GlobalVariables.CoinBalance >= upgrade.Value)
                {
                    upgrade.Key.BackColor = Color.Orange;
                }
                else
                {
                    upgrade.Key.BackColor = Color.LightCoral;
                }
            }

            PictureBox[] upgradeArrows = new PictureBox[]
            {
                UpgradeArrow1, UpgradeArrow2, UpgradeArrow3, UpgradeArrow7, UpgradeArrow8, UpgradeArrow18, UpgradeArrow26, UpgradeArrow27, UpgradeArrow29
            };

            foreach (var arrow in upgradeArrows)
            {
                Image img = new Bitmap(arrow.Image);
                img.RotateFlip(RotateFlipType.RotateNoneFlipX);
                arrow.Image = img;
            }

            PictureBox[] upgradeArrows270 = new PictureBox[]
            {
                UpgradeArrow4, UpgradeArrow5, UpgradeArrow6, UpgradeArrow9, UpgradeArrow11, UpgradeArrow12, UpgradeArrow17
            };

            foreach (var arrow in upgradeArrows270)
            {
                Image img = new Bitmap(arrow.Image);
                img.RotateFlip(RotateFlipType.Rotate270FlipNone);
                arrow.Image = img;
            }

            PictureBox[] upgradeArrows90 = new PictureBox[]
            {
                UpgradeArrow22, UpgradeArrow23, UpgradeArrow28
            };

            foreach (var arrow in upgradeArrows90)
            {
                Image img = new Bitmap(arrow.Image);
                img.RotateFlip(RotateFlipType.Rotate90FlipNone);
                arrow.Image = img;
            }
        }
        private void BackToMenu_Click(object sender, EventArgs e)
        {
            Menu menu = new Menu();
            menu.Show();
            this.Hide();
        }
    }
}