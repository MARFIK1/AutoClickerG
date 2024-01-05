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
        private Dictionary<Button, int> upgradeCosts;
        private Dictionary<Button, bool> upgradesPurchased = new Dictionary<Button, bool>();

        public Upgrades()
        {
            InitializeComponent();
            this.Load += Upgrades_Load;
            this.Size = new Size(1920, 1080);
            this.WindowState = FormWindowState.Maximized;
            Panel draggablePanel = new Panel();
            draggablePanel.Size = new Size(1920, 1080);
            draggablePanel.AutoScroll = true;
            this.Controls.Add(draggablePanel);
            BackToMenu.Click += BackToMenu_Click;

            upgradeCosts = new Dictionary<Button, int>()
            {
                { ClickBoostI, 10 },
                { ClickBoostII, 200 },
                { ClickBoostIII, 500 },
                { ClickBoostIV, 1000 },
                { ClickBoostV, 5000 },
                { AutoClickerI, 500 },
                { AutoClickerII, 1000 },
                { AutoClickerIII, 2000 },
                { AutoClickerIV, 5000 },
                { AutoClickerV, 10000 },
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
                    else if (GlobalVariables.AccountBalance >= localUpgrade.Value)
                    {
                        DialogResult dialogResult = MessageBox.Show("Czy na pewno chcesz zakupić to ulepszenie?", "Potwierdzenie zakupu", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dialogResult == DialogResult.Yes)
                        {
                            GlobalVariables.AccountBalance -= localUpgrade.Value;
                            CoinBalance.Text = GlobalVariables.AccountBalance.ToString();
                            localUpgrade.Key.BackColor = Color.Green;
                            upgradesPurchased[localUpgrade.Key] = true;
                            localUpgrade.Key.Enabled = false;
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
            CoinBalance.Text = GlobalVariables.AccountBalance.ToString();

            foreach (var upgrade in upgradeCosts)
            {
                if (upgradesPurchased.ContainsKey(upgrade.Key) && upgradesPurchased[upgrade.Key])
                {
                    upgrade.Key.BackColor = Color.Green;
                }
                else if (GlobalVariables.AccountBalance >= upgrade.Value)
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