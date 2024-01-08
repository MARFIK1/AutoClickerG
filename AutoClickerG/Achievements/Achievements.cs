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
        public Achievements()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.None;
            BackToMenu.Click += BackToMenu_Click;

            for (int i = 0; i < GlobalVariables.Achievements.Count; i++)
            {
                Achievement currentAchievement = GlobalVariables.Achievements[i];
                Button button = new Button();
                button.Font = new Font("Bernard MT Condensed", 13.25F);
                button.Text = $"{GlobalVariables.Achievements[i].Name} [{GlobalVariables.Achievements[i].Progress}/{GlobalVariables.Achievements[i].Goal}]";
                button.Location = new Point(10, AchievementsText.Height + 30 + i * 30); 
                button.Size = new Size(this.ClientSize.Width, 30);
                button.TextAlign = ContentAlignment.MiddleCenter;
                button.AutoSize = false;
                button.FlatStyle = FlatStyle.Flat;
                button.FlatAppearance.BorderSize = 0;
                button.BackColor = Color.Transparent;
                button.Cursor = Cursors.Default;
                currentAchievement.Button = button;

                if (!GlobalVariables.Achievements[i].IsCollected)
                {
                    if (GlobalVariables.Achievements[i].Progress >= GlobalVariables.Achievements[i].Goal)
                    {
                        button.ForeColor = Color.Orange;
                    }
                    else
                    {
                        button.ForeColor = Color.LightCoral;
                    }
                }
                else
                {
                    button.ForeColor = Color.Green;
                }

                button.Click += (s, args) =>
                {
                    if (currentAchievement.Progress >= currentAchievement.Goal && !currentAchievement.IsCollected)
                    {
                        int reward = currentAchievement.ClaimReward();
                        button.ForeColor = Color.Green;
                        MessageBox.Show($"You have claimed {reward} diamonds for this achievement!");
                    }
                    else if (currentAchievement.IsCollected)
                    {
                        MessageBox.Show("You have already claimed the reward for this achievement.");
                    }
                    else
                    {
                        MessageBox.Show("You have not yet completed this achievement.");
                    }
                };

                this.Controls.Add(button);
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
        public Button Button { get; set; }
        public string Name { get; set; }
        public double Progress { get; set; }
        public int Goal { get; set; }
        public bool IsCollected { get; set; }
        public int Reward { get; set; }

        public Achievement(string name, int goal, int reward, double initialProgress = 0)
        {
            Name = name;
            Goal = goal;
            Reward = reward;
            Progress = initialProgress;
            IsCollected = false;
        }
        public int ClaimReward()
        {
            if (Progress >= Goal && !IsCollected)
            {
                IsCollected = true;
                UpdateAchievementCollectorProgress();
                return Reward;
            }
            return 0;
        }

        public void AddProgress(double amount)
        {
            Progress = Math.Truncate((Progress + amount) * 10000) / 10000;
            Progress = Math.Min(Progress, Goal);
            UpdateButton();
        }

        private void UpdateButton()
        {
            if (Button != null)
            {
                Button.Text = $"{Name} [{Progress}/{Goal}]";
                if (!IsCollected)
                {
                    if (Progress >= Goal)
                    {
                        Button.ForeColor = Color.Orange;
                    }
                    else
                    {
                        Button.ForeColor = Color.LightCoral;
                    }
                }
                else
                {
                    Button.ForeColor = Color.Green;
                }
            }
        }

        public void UpdateAchievementCollectorProgress()
        {
            var achievementCollector = GlobalVariables.Achievements[28];
            if (!achievementCollector.IsCollected)
            {
                int collectedAchievementsCount = GlobalVariables.Achievements.Count(a => a.IsCollected && a != achievementCollector);
                achievementCollector.AddProgress(collectedAchievementsCount - achievementCollector.Progress);
            }
        }
    }
}
