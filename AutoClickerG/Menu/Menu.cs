namespace AutoClickerG
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
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
            Upgrades upgrades = new Upgrades();
            upgrades.Show();
            this.Hide();
        }

        private void achievements_Click(object sender, EventArgs e)
        {
            Achievements achievements = new Achievements();
            achievements.Show();
            this.Hide();
        }

        private void options_Click(object sender, EventArgs e)
        {
            Options options = new Options();
            options.Show();
            this.Hide();
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
