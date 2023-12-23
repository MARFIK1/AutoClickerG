namespace AutoClickerG
{
    partial class Upgrades
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
            upg0 = new Label();
            SuspendLayout();
            // 
            // upg0
            // 
            upg0.AutoSize = true;
            upg0.Font = new Font("Bernard MT Condensed", 26.25F, FontStyle.Bold);
            upg0.Location = new Point(402, 455);
            upg0.Name = "upg0";
            upg0.Size = new Size(188, 41);
            upg0.TabIndex = 0;
            upg0.Text = "Ulepszenie I";
            // 
            // Upgrades
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Moccasin;
            ClientSize = new Size(1920, 1080);
            Controls.Add(upg0);
            Name = "Upgrades";
            Text = "Upgrades";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label upg0;
    }
}