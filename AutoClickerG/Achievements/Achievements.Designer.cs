namespace AutoClickerG
{
    partial class Achievements
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            BackToMenu = new PictureBox();
            AchievementsText = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)AchievementsText).BeginInit();
            ((System.ComponentModel.ISupportInitialize)BackToMenu).BeginInit();
            SuspendLayout();
            // 
            // AchievementsText
            // 
            AchievementsText.Image = Properties.Resources.ACHIEVEMENTS;
            AchievementsText.Location = new Point(636, 20);
            AchievementsText.Name = "AchievementsText";
            AchievementsText.Size = new Size(648, 75);
            AchievementsText.SizeMode = PictureBoxSizeMode.Zoom;
            AchievementsText.TabIndex = 76;
            AchievementsText.TabStop = false;
            // 
            // BackToMenu
            // 
            BackToMenu.Image = Properties.Resources.BackToMenu;
            BackToMenu.Location = new Point(744, 990);
            BackToMenu.Name = "BackToMenu";
            BackToMenu.Size = new Size(432, 50);
            BackToMenu.SizeMode = PictureBoxSizeMode.Zoom;
            BackToMenu.TabIndex = 75;
            BackToMenu.TabStop = false;
            // 
            // Achievements
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Moccasin;
            ClientSize = new Size(1904, 1041);
            Controls.Add(AchievementsText);
            Controls.Add(BackToMenu);
            Name = "Achievements";
            Text = "Achievements";
            ((System.ComponentModel.ISupportInitialize)AchievementsText).EndInit();
            ((System.ComponentModel.ISupportInitialize)BackToMenu).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox AchievementsText;
        private PictureBox BackToMenu;
    }
}