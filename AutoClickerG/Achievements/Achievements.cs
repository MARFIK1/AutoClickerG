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
    public partial class Achievements : Form
    {
        private List<Achievement> achievements;
        public Achievements()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.None;
            BackToMenu.Click += BackToMenu_Click;

            achievements = new List<Achievement>
            {
                new Achievement("First Step - Earn your first coin.", 1),
                new Achievement("Gold Stream - Earn 10 coins.", 10),
                new Achievement("Gold Rain - Earn 100 coins.", 100),
                new Achievement("Gold Tsunami - Earn 500 coins.", 500),
                new Achievement("Midas Wealth - Earn 1000 coins.", 1000),
                new Achievement("First Diamond - Earn your first diamond.", 1),
                new Achievement("Diamond Rain - Earn 10 diamonds.", 10),
                new Achievement("Diamond Avalanche - Earn 50 diamonds.", 50),
                new Achievement("Diamond Crown - Earn 100 diamonds.", 100),
                new Achievement("First Click - Make your first click.", 1),
                new Achievement("Engaged Player - Make 50 clicks.", 50),
                new Achievement("Click Master - Make 100 clicks.", 100),
                new Achievement("Fortuna Goddess - Make 500 clicks.", 500),
                new Achievement("Combo Beginner - Achieve 3x combo multiplier.", 3),
                new Achievement("Combo Master - Achieve 5x combo multiplier.", 5),
                new Achievement("Combo God - Achieve 10x combo multiplier.", 10),
                new Achievement("Balance Doubler - Use Balance Doubler for the first time.", 1),
                new Achievement("Balance Multiplier - Use Balance Doubler 3 times.", 3),
                new Achievement("Diamond Rush - Use Diamond Rush for the first time.", 1),
                new Achievement("Diamond Multiplier - Use Diamond Rush 3 times.", 3),
                new Achievement("Upgrade Enthusiast - Purchase 5 upgrades.", 5),
                new Achievement("Upgrade Collector - Purchase 10 upgrades.", 10),
                new Achievement("Upgrade Hoarder - Purchase 20 upgrades.", 20),
                new Achievement("Category Master - Fully upgrade a category.", 1),
                new Achievement("Category God - Fully upgrade 3 categories.", 3),
                new Achievement("Time Tracker - Play for 1 hour.", 1),
                new Achievement("Time Lord - Play for 5 hours.", 5),
                new Achievement("Time God - Play for 10 hours.", 10),
                new Achievement("Achievement Collector - Collect all other achievements.", 1)
            };

            for (int i = 0; i < achievements.Count; i++)
            {
                Label label = new Label();
                label.Font = new Font("Bernard MT Condensed", 15.25F);
                label.Text = $"{achievements[i].Name} [{achievements[i].Progress}/{achievements[i].Goal}]";
                label.Location = new Point(10, AchievementsText.Height + 30 + i * 30); 
                label.Size = new Size(this.ClientSize.Width, 30);
                label.TextAlign = ContentAlignment.MiddleCenter;
                label.AutoSize = false;

                if (!achievements[i].IsCollected)
                {
                    if (achievements[i].Progress >= achievements[i].Goal)
                    {
                        label.ForeColor = Color.Orange;
                    }
                    else
                    {
                        label.ForeColor = Color.LightCoral;
                    }
                }
                else
                {
                    label.ForeColor = Color.Green;
                }

                this.Controls.Add(label);
            }
        }

        private void BackToMenu_Click(object sender, EventArgs e)
        {
            Menu menu = new Menu();
            menu.Show();
            this.Hide();
        }
    }
    public class Achievement
    {
        public string Name { get; set; }
        public int Progress { get; set; }
        public int Goal { get; set; }
        public bool IsCollected { get; set; }

        public Achievement(string name, int goal)
        {
            Name = name;
            Goal = goal;
            Progress = 0;
            IsCollected = false;
        }
    }
}
