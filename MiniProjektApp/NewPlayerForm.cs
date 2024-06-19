using MiniProjekt;
namespace MiniProjektApp
{
    public partial class NewPlayerForm : Form
    {
        public static string PlayerName = "";
        public static NewPlayerForm instance;
        public NewPlayerForm()
        {
            InitializeComponent();
            instance = this;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void AddNewPlayerButton_Click(object sender, EventArgs e)
        {
            PlayerName = NewPlayerNameTextBox.Text;
            var form = new MainForm();
            form.Show();
            this.Hide();
        }

        private void AddNewPlayer_Load(object sender, EventArgs e)
        {

        }
    }
}
