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
            CoinBalance = new Label();
            BackToMenu = new PictureBox();
            ClickCounter = new Label();
            CTEM = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)Coin).BeginInit();
            ((System.ComponentModel.ISupportInitialize)BackToMenu).BeginInit();
            ((System.ComponentModel.ISupportInitialize)CTEM).BeginInit();
            SuspendLayout();
            // 
            // CTEM
            // 
            CTEM.Image = Properties.Resources.Coin;
            CTEM.Location = new Point(872, 76);
            CTEM.Name = "CTEM";
            CTEM.Size = new Size(157, 158);
            CTEM.SizeMode = PictureBoxSizeMode.CenterImage;
            CTEM.TabIndex = 0;
            CTEM.TabStop = false;
            CTEM.Click += CTEM_Click;
            // 
            // CoinBalance
            // 
            CoinBalance.AutoSize = true;
            CoinBalance.Font = new Font("Bernard MT Condensed", 26.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            CoinBalance.ForeColor = Color.Salmon;
            CoinBalance.Location = new Point(636, 237);
            CoinBalance.Name = "CoinBalance";
            CoinBalance.Size = new Size(273, 41);
            CoinBalance.TabIndex = 1;
            CoinBalance.Text = "Account Balance: ";
            // 
            // ClickCounter
            // 
            ClickCounter.AutoSize = true;
            ClickCounter.Font = new Font("Bernard MT Condensed", 26.25F, FontStyle.Bold);
            ClickCounter.ForeColor = Color.Salmon;
            ClickCounter.Location = new Point(999, 237);
            ClickCounter.Name = "ClickCounter";
            ClickCounter.Size = new Size(215, 41);
            ClickCounter.TabIndex = 2;
            ClickCounter.Text = "Click Counter:";
            // 
            // Coin
            // 
            Coin.Image = Properties.Resources.Coin;
            Coin.Location = new Point(311, 135);
            Coin.Name = "Coin";
            Coin.Size = new Size(416, 386);
            Coin.SizeMode = PictureBoxSizeMode.Zoom;
            Coin.TabIndex = 3;
            Coin.TabStop = false;
            // 
            // BackToMenu
            // 
            BackToMenu.Image = Properties.Resources.BackToMenu;
            BackToMenu.Location = new Point(480, 281);
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
            ClientSize = new Size(1920, 1080);
            Controls.Add(CTEM);
            Controls.Add(ClickCounter);
            Controls.Add(BackToMenu);
            Controls.Add(CoinBalance);
            Controls.Add(Coin);
            Name = "Play";
            Text = "Play";
            ((System.ComponentModel.ISupportInitialize)Coin).EndInit();
            ((System.ComponentModel.ISupportInitialize)BackToMenu).EndInit();
            ((System.ComponentModel.ISupportInitialize)CTEM).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox Coin;
        private Label CoinBalance;
        private PictureBox BackToMenu;
        private Label ClickCounter;
        private PictureBox CTEM;
    }
}