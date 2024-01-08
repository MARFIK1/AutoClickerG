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

            Image img1 = new Bitmap(UpgradeArrow1.Image);
            img1.RotateFlip(RotateFlipType.RotateNoneFlipX);
            UpgradeArrow1.Image = img1;

            Image img2 = new Bitmap(UpgradeArrow2.Image);
            img2.RotateFlip(RotateFlipType.RotateNoneFlipX);
            UpgradeArrow2.Image = img2;

            Image img3 = new Bitmap(UpgradeArrow3.Image);
            img3.RotateFlip(RotateFlipType.RotateNoneFlipX);
            UpgradeArrow3.Image = img3;

            Image img4 = new Bitmap(UpgradeArrow4.Image);
            img4.RotateFlip(RotateFlipType.Rotate270FlipNone);
            UpgradeArrow4.Image = img4;

            Image img5 = new Bitmap(UpgradeArrow5.Image);
            img5.RotateFlip(RotateFlipType.Rotate270FlipNone);
            UpgradeArrow5.Image = img5;

            Image img6 = new Bitmap(UpgradeArrow6.Image);
            img6.RotateFlip(RotateFlipType.Rotate270FlipNone);
            UpgradeArrow6.Image = img6;

            Image img7 = new Bitmap(UpgradeArrow7.Image);
            img7.RotateFlip(RotateFlipType.RotateNoneFlipX);
            UpgradeArrow7.Image = img7;

            Image img8 = new Bitmap(UpgradeArrow8.Image);
            img8.RotateFlip(RotateFlipType.RotateNoneFlipX);
            UpgradeArrow8.Image = img8;

            Image img9 = new Bitmap(UpgradeArrow9.Image);
            img9.RotateFlip(RotateFlipType.Rotate270FlipNone);
            UpgradeArrow9.Image = img9;

            Image img11 = new Bitmap(UpgradeArrow11.Image);
            img11.RotateFlip(RotateFlipType.Rotate270FlipNone);
            UpgradeArrow11.Image = img11;

            Image img12 = new Bitmap(UpgradeArrow12.Image);
            img12.RotateFlip(RotateFlipType.Rotate270FlipNone);
            UpgradeArrow12.Image = img12;

            Image img17 = new Bitmap(UpgradeArrow17.Image);
            img17.RotateFlip(RotateFlipType.Rotate270FlipNone);
            UpgradeArrow17.Image = img17;

            Image img18 = new Bitmap(UpgradeArrow18.Image);
            img18.RotateFlip(RotateFlipType.RotateNoneFlipX);
            UpgradeArrow18.Image = img18;

            Image img22 = new Bitmap(UpgradeArrow22.Image);
            img22.RotateFlip(RotateFlipType.Rotate90FlipNone);
            UpgradeArrow22.Image = img22;

            Image img23 = new Bitmap(UpgradeArrow23.Image);
            img23.RotateFlip(RotateFlipType.Rotate90FlipNone);
            UpgradeArrow23.Image = img23;

            Image img26 = new Bitmap(UpgradeArrow26.Image);
            img26.RotateFlip(RotateFlipType.RotateNoneFlipX);
            UpgradeArrow26.Image = img26;

            Image img27 = new Bitmap(UpgradeArrow27.Image);
            img27.RotateFlip(RotateFlipType.RotateNoneFlipX);
            UpgradeArrow27.Image = img27;

            Image img28 = new Bitmap(UpgradeArrow28.Image);
            img28.RotateFlip(RotateFlipType.Rotate90FlipNone);
            UpgradeArrow28.Image = img28;

            Image img29 = new Bitmap(UpgradeArrow29.Image);
            img29.RotateFlip(RotateFlipType.RotateNoneFlipX);
            UpgradeArrow29.Image = img29;
        }
        private void BackToMenu_Click(object sender, EventArgs e)
        {
            Menu menu = new Menu();
            menu.Show();
            this.Hide();
        }
    }
}