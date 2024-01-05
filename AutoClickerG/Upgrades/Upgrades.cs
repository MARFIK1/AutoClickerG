﻿using System;
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
        private Label[] upgradeLabels;
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

            string[] upgrades = new string[]
            {
                "Double Click - Podwaja moc kliknięcia",
                "Auto Clicker - Automatyczne kliknięcia co sekundę",
                "Click Multiplier - Mnoży punkty z kliknięcia przez 5",
                "Click Storm - Kliknięcia generują dodatkowe punkty przez 10 sekund",
                "Bonus Time - Podwaja wszystkie punkty przez 30 sekund",
                "Click Magnet - Automatycznie zbiera bonusy na ekranie",
                "Power Surge - Zwiększa moc kliknięcia o 200% przez 20 sekund",
                "Click Frenzy - Kliknięcia generują 10x punktów przez 10 sekund",
                "Golden Click - Kliknięcia generują złote monety",
                "Infinity Click - Kliknięcia generują nieskończoną ilość punktów przez 5 sekund"
            };
        }
        private void Upgrades_Load(object sender, EventArgs e)
        {
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
    }
}