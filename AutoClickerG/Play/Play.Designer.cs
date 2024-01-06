using System.Drawing;

namespace AutoClickerG
{
    partial class Play
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
            CTEM = new PictureBox();
            CoinGif = new PictureBox();
            Coins = new Label();
            ClickMultiplier = new Label();
            DiamondGif = new PictureBox();
            Diamonds = new Label();
            DiamondChance = new Label();
            ClickGif = new PictureBox();
            Clicks = new Label();
            BackToMenu = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)CTEM).BeginInit();
            ((System.ComponentModel.ISupportInitialize)CoinGif).BeginInit();
            ((System.ComponentModel.ISupportInitialize)DiamondGif).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ClickGif).BeginInit();
            ((System.ComponentModel.ISupportInitialize)BackToMenu).BeginInit();
            SuspendLayout();
            // 
            // CTEM
            // 
            CTEM.Image = Properties.Resources.CoinToClick;
            CTEM.Location = new Point(783, 92);
            CTEM.Name = "CTEM";
            CTEM.Size = new Size(295, 311);
            CTEM.SizeMode = PictureBoxSizeMode.CenterImage;
            CTEM.TabIndex = 0;
            CTEM.TabStop = false;
            CTEM.Click += CTEM_Click;
            // 
            // CoinGif
            // 
            CoinGif.Image = Properties.Resources.Coin;
            CoinGif.Location = new Point(640, 420);
            CoinGif.Name = "CoinGif";
            CoinGif.Size = new Size(70, 70);
            CoinGif.SizeMode = PictureBoxSizeMode.Zoom;
            CoinGif.TabIndex = 76;
            CoinGif.TabStop = false;
            // 
            // Coins
            // 
            Coins.AutoSize = true;
            Coins.Font = new Font("Bernard MT Condensed", 26.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Coins.ForeColor = Color.Salmon;
            Coins.Location = new Point(716, 435);
            Coins.Name = "Coins";
            Coins.Size = new Size(18, 41);
            Coins.TabIndex = 78;
            Coins.Text = "\r\n";
            // 
            // ClickMultiplier
            // 
            ClickMultiplier.AutoSize = true;
            ClickMultiplier.Font = new Font("Bernard MT Condensed", 26.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ClickMultiplier.ForeColor = Color.Salmon;
            ClickMultiplier.Location = new Point(1050, 435);
            ClickMultiplier.Name = "ClickMultiplier";
            ClickMultiplier.Size = new Size(18, 41);
            ClickMultiplier.TabIndex = 5;
            ClickMultiplier.Text = "\r\n";
            // 
            // DiamondGif
            // 
            DiamondGif.Image = Properties.Resources.Diamond;
            DiamondGif.Location = new Point(640, 520);
            DiamondGif.Name = "DiamondGif";
            DiamondGif.Size = new Size(70, 70);
            DiamondGif.SizeMode = PictureBoxSizeMode.Zoom;
            DiamondGif.TabIndex = 80;
            DiamondGif.TabStop = false;
            // 
            // Diamonds
            // 
            Diamonds.AutoSize = true;
            Diamonds.Font = new Font("Bernard MT Condensed", 26.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Diamonds.ForeColor = Color.Salmon;
            Diamonds.Location = new Point(716, 535);
            Diamonds.Name = "Diamonds";
            Diamonds.Size = new Size(18, 41);
            Diamonds.TabIndex = 81;
            Diamonds.Text = "\r\n";
            // 
            // DiamondChance
            // 
            DiamondChance.AutoSize = true;
            DiamondChance.Font = new Font("Bernard MT Condensed", 26.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            DiamondChance.ForeColor = Color.Salmon;
            DiamondChance.Location = new Point(1050, 535);
            DiamondChance.Name = "DiamondChance";
            DiamondChance.Size = new Size(18, 41);
            DiamondChance.TabIndex = 82;
            DiamondChance.Text = "\r\n";
            // 
            // ClickGif
            // 
            ClickGif.Image = Properties.Resources.Click;
            ClickGif.Location = new Point(640, 620);
            ClickGif.Name = "ClickGif";
            ClickGif.Size = new Size(70, 70);
            ClickGif.SizeMode = PictureBoxSizeMode.Zoom;
            ClickGif.TabIndex = 77;
            ClickGif.TabStop = false;
            // 
            // Clicks
            // 
            Clicks.AutoSize = true;
            Clicks.Font = new Font("Bernard MT Condensed", 26.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Clicks.ForeColor = Color.Salmon;
            Clicks.Location = new Point(716, 635);
            Clicks.Name = "Clicks";
            Clicks.Size = new Size(18, 41);
            Clicks.TabIndex = 79;
            Clicks.Text = "\r\n";
            // 
            // BackToMenu
            // 
            BackToMenu.Image = Properties.Resources.BackToMenu;
            BackToMenu.Location = new Point(480, 720);
            BackToMenu.Name = "BackToMenu";
            BackToMenu.Size = new Size(960, 112);
            BackToMenu.SizeMode = PictureBoxSizeMode.CenterImage;
            BackToMenu.TabIndex = 4;
            BackToMenu.TabStop = false;
            BackToMenu.Click += BackToMenu_Click;
            // 
            // Play
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Moccasin;
            ClientSize = new Size(1920, 1061);
            Controls.Add(CTEM);
            Controls.Add(CoinGif);
            Controls.Add(Coins);
            Controls.Add(ClickMultiplier);
            Controls.Add(DiamondGif);
            Controls.Add(Diamonds);
            Controls.Add(DiamondChance);
            Controls.Add(ClickGif);
            Controls.Add(Clicks);
            Controls.Add(BackToMenu);
            Name = "Play";
            Text = "Play";
            ((System.ComponentModel.ISupportInitialize)CTEM).EndInit();
            ((System.ComponentModel.ISupportInitialize)CoinGif).EndInit();
            ((System.ComponentModel.ISupportInitialize)DiamondGif).EndInit();
            ((System.ComponentModel.ISupportInitialize)ClickGif).EndInit();
            ((System.ComponentModel.ISupportInitialize)BackToMenu).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private PictureBox CTEM;
        private PictureBox CoinGif;
        private Label Coins;
        private Label ClickMultiplier;
        private PictureBox DiamondGif;
        private Label Diamonds;
        private Label DiamondChance;
        private PictureBox ClickGif;
        private Label Clicks;
        private PictureBox BackToMenu;
    }
}