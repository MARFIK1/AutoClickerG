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
            about = new PictureBox();
            exit = new PictureBox();
            shop = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)AutoClicker).BeginInit();
            ((System.ComponentModel.ISupportInitialize)play).BeginInit();
            ((System.ComponentModel.ISupportInitialize)upgrades).BeginInit();
            ((System.ComponentModel.ISupportInitialize)achievements).BeginInit();
            ((System.ComponentModel.ISupportInitialize)about).BeginInit();
            ((System.ComponentModel.ISupportInitialize)exit).BeginInit();
            ((System.ComponentModel.ISupportInitialize)shop).BeginInit();
            SuspendLayout();
            // 
            // AutoClicker
            // 
            AutoClicker.Image = Properties.Resources.AutoClicker;
            AutoClicker.Location = new Point(480, 280);
            AutoClicker.Name = "AutoClicker";
            AutoClicker.Size = new Size(960, 122);
            AutoClicker.SizeMode = PictureBoxSizeMode.CenterImage;
            AutoClicker.TabIndex = 0;
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
            // about
            // 
            about.Image = Properties.Resources.ABOUT;
            about.Location = new Point(480, 676);
            about.Name = "about";
            about.Size = new Size(960, 61);
            about.SizeMode = PictureBoxSizeMode.CenterImage;
            about.TabIndex = 4;
            about.TabStop = false;
            about.Click += about_Click;
            // 
            // exit
            // 
            exit.Image = Properties.Resources.EXIT;
            exit.Location = new Point(480, 743);
            exit.Name = "exit";
            exit.Size = new Size(960, 61);
            exit.SizeMode = PictureBoxSizeMode.CenterImage;
            exit.TabIndex = 5;
            exit.TabStop = false;
            exit.Click += exit_Click;
            // 
            // shop
            // 
            shop.Image = Properties.Resources.Shop;
            shop.Location = new Point(480, 609);
            shop.Name = "shop";
            shop.Size = new Size(960, 61);
            shop.SizeMode = PictureBoxSizeMode.CenterImage;
            shop.TabIndex = 6;
            shop.TabStop = false;
            shop.Click += shop_Click;
            // 
            // Menu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Moccasin;
            ClientSize = new Size(1904, 1041);
            Controls.Add(shop);
            Controls.Add(exit);
            Controls.Add(about);
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
            ((System.ComponentModel.ISupportInitialize)about).EndInit();
            ((System.ComponentModel.ISupportInitialize)exit).EndInit();
            ((System.ComponentModel.ISupportInitialize)shop).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox AutoClicker;
        private PictureBox play;
        private PictureBox upgrades;
        private PictureBox achievements;
        private PictureBox about;
        private PictureBox exit;
        private PictureBox shop;
    }
}
