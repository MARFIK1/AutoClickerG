namespace AutoClickerG
{
    partial class About
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(About));
            BackToMenu = new PictureBox();
            InformationAboutGame = new Label();
            AboutText = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)BackToMenu).BeginInit();
            ((System.ComponentModel.ISupportInitialize)AboutText).BeginInit();
            SuspendLayout();
            // 
            // BackToMenu
            // 
            BackToMenu.Image = Properties.Resources.BackToMenu;
            BackToMenu.Location = new Point(744, 825);
            BackToMenu.Name = "BackToMenu";
            BackToMenu.Size = new Size(432, 50);
            BackToMenu.SizeMode = PictureBoxSizeMode.Zoom;
            BackToMenu.TabIndex = 5;
            BackToMenu.TabStop = false;
            // 
            // InformationAboutGame
            // 
            InformationAboutGame.AutoSize = true;
            InformationAboutGame.Font = new Font("Bernard MT Condensed", 26.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            InformationAboutGame.ForeColor = Color.Salmon;
            InformationAboutGame.Location = new Point(64, 200);
            InformationAboutGame.Name = "InformationAboutGame";
            InformationAboutGame.Size = new Size(1796, 615);
            InformationAboutGame.TabIndex = 79;
            InformationAboutGame.Text = resources.GetString("InformationAboutGame.Text");
            InformationAboutGame.TextAlign = ContentAlignment.TopCenter;
            // 
            // AboutText
            // 
            AboutText.Image = Properties.Resources.ABOUT;
            AboutText.Location = new Point(765, 60);
            AboutText.Name = "AboutText";
            AboutText.Size = new Size(390, 125);
            AboutText.SizeMode = PictureBoxSizeMode.Zoom;
            AboutText.TabIndex = 80;
            AboutText.TabStop = false;
            // 
            // About
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Moccasin;
            ClientSize = new Size(1904, 1041);
            Controls.Add(AboutText);
            Controls.Add(InformationAboutGame);
            Controls.Add(BackToMenu);
            Name = "About";
            Text = "About";
            ((System.ComponentModel.ISupportInitialize)BackToMenu).EndInit();
            ((System.ComponentModel.ISupportInitialize)AboutText).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox BackToMenu;
        private Label InformationAboutGame;
        private PictureBox AboutText;
    }
}