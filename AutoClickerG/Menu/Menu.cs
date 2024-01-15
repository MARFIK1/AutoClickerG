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

        }

        private void play_Click(object sender, EventArgs e)
        {
            Play game = new Play();
            game.Show();
            this.Hide();
        }

        private void upgrades_Click(object sender, EventArgs e)
        {
            Upgrades.Instance.Show();
            this.Hide();
        }

        private void achievements_Click(object sender, EventArgs e)
        {
            Achievements achievements = new Achievements();
            achievements.Show();
            this.Hide();
        }

        private void shop_Click(object sender, EventArgs e)
        {
            Shop.Instance.Show();
            this.Hide();
        }

        private void about_Click(object sender, EventArgs e)
        {
            About about = new About();
            about.Show();
            this.Hide();
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
