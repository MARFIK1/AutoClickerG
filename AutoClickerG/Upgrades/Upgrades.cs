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
            this.Size = new Size(1920, 1080);
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.None;
            Panel draggablePanel = new Panel();
            draggablePanel.Size = new Size(1920, 1080);
            draggablePanel.AutoScroll = true;
            this.Controls.Add(draggablePanel);
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
                { ClickComboI, 750 },
                { ClickComboII, 1250 },
                { ClickComboIII, 5000 },
                { LuckyDiamondsI, 750 },
                { LuckyDiamondsII, 1750 },
                { LuckyDiamondsIII, 3000 },
                { LuckyDiamondsIV, 5000 },
                { LuckyDiamondsV, 7500 },
                { DiamondBoostI, 250 },
                { DiamondBoostII, 600 },
                { DiamondBoostIII, 1000 },
                { DiamondBoostIV, 3000 },
                { BalanceDoublerI, 3000 },
                { BalanceDoublerII, 5000 },
                { BalanceDoublerIII, 7000 },
                { DiamondRushI, 1500 },
                { DiamondRushII, 3000 },
                { DiamondRushIII, 5000 },
                { DiamondRushIV, 10000 },
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
                { ClickBoostIII, 1.75 },
                { ClickBoostIV, 3 },
                { ClickBoostV, 4 },
                { AutoClickerI , 1 },
                { AutoClickerII , 5 },
                { AutoClickerIII , 10 },
                { AutoClickerIV , 25 },
                { AutoClickerV , 50 },
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
                            CoinBalance.Text = GlobalVariables.CoinBalance.ToString();
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
                                GlobalVariables.ClickMultiplier = upgradeRewards[localUpgrade.Key];
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
            CoinBalance.Text = GlobalVariables.CoinBalance.ToString();

            GlobalVariables.OnCoinBalanceChanged += balance =>
            {
                CoinBalance.Text = balance.ToString();

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