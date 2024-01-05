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
            Coin = new PictureBox();
            CTEM = new PictureBox();
            CoinGif = new PictureBox();
            Coins = new Label();
            ClickGif = new PictureBox();
            Clicks = new Label();
            ClickMultiplier = new Label();
            BackToMenu = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)Coin).BeginInit();
            ((System.ComponentModel.ISupportInitialize)CTEM).BeginInit();
            ((System.ComponentModel.ISupportInitialize)CoinGif).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ClickGif).BeginInit();
            ((System.ComponentModel.ISupportInitialize)BackToMenu).BeginInit();
            SuspendLayout();
            // 
            // Coin
            // 
            Coin.Cursor = Cursors.No;
            Coin.Image = Properties.Resources.Coin;
            Coin.Location = new Point(12, 12);
            Coin.Name = "Coin";
            Coin.Size = new Size(364, 306);
            Coin.SizeMode = PictureBoxSizeMode.CenterImage;
            Coin.TabIndex = 3;
            Coin.TabStop = false;
            Coin.Visible = false;
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
            CoinGif.Location = new Point(636, 409);
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
            Coins.Location = new Point(712, 422);
            Coins.Name = "Coins";
            Coins.Size = new Size(18, 41);
            Coins.TabIndex = 78;
            Coins.Text = "\r\n";
            // 
            // ClickGif
            // 
            ClickGif.Image = Properties.Resources.Click;
            ClickGif.Location = new Point(1077, 409);
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
            Clicks.Location = new Point(1153, 422);
            Clicks.Name = "Clicks";
            Clicks.Size = new Size(18, 41);
            Clicks.TabIndex = 79;
            Clicks.Text = "\r\n";
            // 
            // ClickMultiplier
            // 
            ClickMultiplier.AutoSize = true;
            ClickMultiplier.Font = new Font("Bernard MT Condensed", 26.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ClickMultiplier.ForeColor = Color.Salmon;
            ClickMultiplier.Location = new Point(636, 496);
            ClickMultiplier.Name = "ClickMultiplier";
            ClickMultiplier.Size = new Size(18, 41);
            ClickMultiplier.TabIndex = 5;
            ClickMultiplier.Text = "\r\n";
            // 
            // BackToMenu
            // 
            BackToMenu.Image = Properties.Resources.BackToMenu;
            BackToMenu.Location = new Point(480, 550);
            BackToMenu.Name = "BackToMenu";
            BackToMenu.Size = new Size(960, 112);
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
            Controls.Add(Coin);
            Controls.Add(CTEM);
            Controls.Add(CoinGif);
            Controls.Add(Coins);
            Controls.Add(ClickGif);
            Controls.Add(Clicks);
            Controls.Add(ClickMultiplier);
            Controls.Add(BackToMenu);
            Name = "Play";
            Text = "Play";
            ((System.ComponentModel.ISupportInitialize)Coin).EndInit();
            ((System.ComponentModel.ISupportInitialize)CTEM).EndInit();
            ((System.ComponentModel.ISupportInitialize)CoinGif).EndInit();
            ((System.ComponentModel.ISupportInitialize)ClickGif).EndInit();
            ((System.ComponentModel.ISupportInitialize)BackToMenu).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox Coin;
        private PictureBox CTEM;
        private PictureBox CoinGif;
        private Label Coins;
        private PictureBox ClickGif;
        private Label Clicks;
        private Label ClickMultiplier;
        private PictureBox BackToMenu;
    }
}