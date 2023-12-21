namespace AutoClickerG
{
    partial class Menu
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            AutoClicker = new PictureBox();
            play = new PictureBox();
            upgrades = new PictureBox();
            achievements = new PictureBox();
            options = new PictureBox();
            exit = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)AutoClicker).BeginInit();
            ((System.ComponentModel.ISupportInitialize)play).BeginInit();
            ((System.ComponentModel.ISupportInitialize)upgrades).BeginInit();
            ((System.ComponentModel.ISupportInitialize)achievements).BeginInit();
            ((System.ComponentModel.ISupportInitialize)options).BeginInit();
            ((System.ComponentModel.ISupportInitialize)exit).BeginInit();
            SuspendLayout();
            // 
            // AutoClicker
            // 
            AutoClicker.Image = Properties.Resources.AutoClicker;
            AutoClicker.Location = new Point(480, 280);
            AutoClicker.Name = "AutoClicker";
            AutoClicker.Size = new Size(960, 122);
            AutoClicker.SizeMode = PictureBoxSizeMode.CenterImage;
            AutoClicker.TabIndex = 6;
            AutoClicker.TabStop = false;
            // 
            // play
            // 
            play.Image = Properties.Resources.PLAY;
            play.Location = new Point(480, 408);
            play.Name = "play";
            play.Size = new Size(960, 61);
            play.SizeMode = PictureBoxSizeMode.CenterImage;
            play.TabIndex = 1;
            play.TabStop = false;
            play.Click += play_Click;
            // 
            // upgrades
            // 
            upgrades.Image = Properties.Resources.UPGRADES;
            upgrades.Location = new Point(480, 475);
            upgrades.Name = "upgrades";
            upgrades.Size = new Size(960, 61);
            upgrades.SizeMode = PictureBoxSizeMode.CenterImage;
            upgrades.TabIndex = 2;
            upgrades.TabStop = false;
            upgrades.Click += upgrades_Click;
            // 
            // achievements
            // 
            achievements.Image = Properties.Resources.ACHIEVEMENTS;
            achievements.Location = new Point(480, 542);
            achievements.Name = "achievements";
            achievements.Size = new Size(960, 61);
            achievements.SizeMode = PictureBoxSizeMode.CenterImage;
            achievements.TabIndex = 3;
            achievements.TabStop = false;
            achievements.Click += achievements_Click;
            // 
            // options
            // 
            options.Image = Properties.Resources.OPTIONS;
            options.Location = new Point(480, 609);
            options.Name = "options";
            options.Size = new Size(960, 61);
            options.SizeMode = PictureBoxSizeMode.CenterImage;
            options.TabIndex = 4;
            options.TabStop = false;
            options.Click += options_Click;
            // 
            // exit
            // 
            exit.Image = Properties.Resources.EXIT;
            exit.Location = new Point(480, 676);
            exit.Name = "exit";
            exit.Size = new Size(960, 61);
            exit.SizeMode = PictureBoxSizeMode.CenterImage;
            exit.TabIndex = 5;
            exit.TabStop = false;
            exit.Click += exit_Click;
            // 
            // Menu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Moccasin;
            ClientSize = new Size(1920, 1061);
            Controls.Add(exit);
            Controls.Add(options);
            Controls.Add(achievements);
            Controls.Add(upgrades);
            Controls.Add(play);
            Controls.Add(AutoClicker);
            Name = "Menu";
            Text = "Menu";
            Load += Menu_Load;
            ((System.ComponentModel.ISupportInitialize)AutoClicker).EndInit();
            ((System.ComponentModel.ISupportInitialize)play).EndInit();
            ((System.ComponentModel.ISupportInitialize)upgrades).EndInit();
            ((System.ComponentModel.ISupportInitialize)achievements).EndInit();
            ((System.ComponentModel.ISupportInitialize)options).EndInit();
            ((System.ComponentModel.ISupportInitialize)exit).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox AutoClicker;
        private PictureBox play;
        private PictureBox upgrades;
        private PictureBox achievements;
        private PictureBox options;
        private PictureBox exit;
    }
}
