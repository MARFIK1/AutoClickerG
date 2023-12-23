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
    public partial class Upgrades : Form
    {
        private Point panelLocation;

        public Upgrades()
        {
            InitializeComponent();
            this.Size = new Size(1920, 1080);
            this.WindowState = FormWindowState.Maximized;
            Panel draggablePanel = new Panel();
            draggablePanel.Size = new Size(2920, 2080);
            ScrollableControl scrollableControl = new ScrollableControl();
            scrollableControl.Dock = DockStyle.Fill;
            scrollableControl.AutoScroll = true;
            scrollableControl.Controls.Add(draggablePanel);
            this.Controls.Add(scrollableControl);
            draggablePanel.MouseDown += new MouseEventHandler(Panel_MouseDown);
            draggablePanel.MouseMove += new MouseEventHandler(Panel_MouseMove);
            this.Controls.Remove(upg0);
            scrollableControl.Controls.Add(upg0);
            upg0.BringToFront();
        }

        private void Panel_MouseDown(object sender, MouseEventArgs e)
        {
            panelLocation = e.Location;
        }

        private void Panel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Panel panel = (Panel)sender;
                Point newLocation = panel.Location + new Size(e.Location) - new Size(panelLocation);
                
                if (newLocation.X >= 0 && newLocation.X <= 5000 - panel.Width)
                {
                    panel.Left = newLocation.X;
                }
                if (newLocation.Y >= 0 && newLocation.Y <= 3000 - panel.Height)
                {
                    panel.Top = newLocation.Y;
                }
            }
        }
    }
}