namespace AutoClickerG
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.None;
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            /*
            if (File.Exists("Data.txt"))
            {
                using (StreamReader reader = new StreamReader("Data.txt"))
                {
                    GlobalVariables.CoinBalance = int.Parse(reader.ReadLine());
                    GlobalVariables.DiamondBalance = int.Parse(reader.ReadLine());
                    GlobalVariables.ClickCounter = int.Parse(reader.ReadLine());
                    GlobalVariables.ClickMultiplier = double.Parse(reader.ReadLine());
                    GlobalVariables.DiamondMultiplier = int.Parse(reader.ReadLine());
                    GlobalVariables.DiamondChance = double.Parse(reader.ReadLine());
                }
            }
            */
        }

        private void play_Click(object sender, EventArgs e)
        {
            Play play = new Play();
            play.Show();
            this.Hide();
        }

        private void upgrades_Click(object sender, EventArgs e)
        {
            Upgrades.Instance.Show();
            this.Hide();
        }

        private void achievements_Click(object sender, EventArgs e)
        {
            Achievements.Instance.Show();
            this.Hide();
        }

        private void shop_Click(object sender, EventArgs e)
        {
            Shop.Instance.Show();
            this.Hide();
        }

        private void about_Click(object sender, EventArgs e)
        {
            About.Instance.Show();
            this.Hide();
        }

        private void exit_Click(object sender, EventArgs e)
        {
            /*
            using (StreamWriter writer = new StreamWriter("Data.txt"))
            {
                writer.WriteLine(GlobalVariables.CoinBalance);
                writer.WriteLine(GlobalVariables.DiamondBalance);
                writer.WriteLine(GlobalVariables.ClickCounter);
                writer.WriteLine(GlobalVariables.ClickMultiplier);
                writer.WriteLine(GlobalVariables.DiamondMultiplier);
                writer.WriteLine(GlobalVariables.DiamondChance);
            }
            */

            Environment.Exit(0);
        }
    }
}
