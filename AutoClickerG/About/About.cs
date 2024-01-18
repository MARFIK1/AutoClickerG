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
    public partial class About : Form
    {
        private static About _instance;

        public static About Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new About();
                }
                return _instance;
            }
        }
        public About()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.None;
            BackToMenu.Click += BackToMenu_Click;
        }

        private void BackToMenu_Click(object sender, EventArgs e)
        {
            Menu menu = new Menu();
            menu.Show();
            this.Hide();
        }
    }
}
