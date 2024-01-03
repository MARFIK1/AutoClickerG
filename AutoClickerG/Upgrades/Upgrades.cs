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
        private Label[] upgradeLabels;
        public Upgrades()
        {
            InitializeComponent();
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

            int labelsPerColumn = 10;
            int labelHeight = 50;
            int labelWidth = 200;
            int labelMargin = 20;
            int columnMargin = 750;

            for (int i = 0; i < upgrades.Length; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Label upgradeLabel = new Label();
                    upgradeLabel.AutoSize = true;
                    upgradeLabel.Font = new Font("Bernard MT Condensed", 14F, FontStyle.Bold);
                    upgradeLabel.Location = new Point(
                        (i % 2) * (labelWidth + labelMargin + columnMargin), 
                        (i / 2) * (5 * (labelHeight + labelMargin)) + (j * (labelHeight + labelMargin))
                    );
                    upgradeLabel.Name = "upgradeLabel" + i + "_" + j;
                    upgradeLabel.Size = new Size(188, 41);
                    upgradeLabel.TabIndex = i;
                    upgradeLabel.Text = "Upgrade " + (i + 1) + " Level " + (j + 1) + ": " + upgrades[i] + " x" + (j + 1);
                    draggablePanel.Controls.Add(upgradeLabel);
                    upgradeLabel.BringToFront();
                }
            }
        }
    }
}