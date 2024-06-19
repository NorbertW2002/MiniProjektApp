using MiniProjekt;
using System.Diagnostics.Eventing.Reader;
using System.Windows.Forms;
using System.Xml.Linq;
namespace MiniProjektApp
{
    public partial class MainForm : Form
    {
        Player player;
        private System.Windows.Forms.Timer timer;
        public MainForm()
        {
            InitializeComponent();
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            string newPlayer = NewPlayerForm.PlayerName;
            player = new Player(newPlayer);
            PlayerName.Text = player.Name;
            PlayerLevel.Text = player.Level.ToString();
            GoldAmount.Text = player.Resources.Find(r => r.Name == "Gold").Amount.ToString();
            WoodAmount.Text = player.Resources.Find(r => r.Name == "Wood").Amount.ToString();
            IronAmount.Text = player.Resources.Find(r => r.Name == "Iron").Amount.ToString();
            StoneAmount.Text = player.Resources.Find(r => r.Name == "Stone").Amount.ToString();
            WheatAmount.Text = player.Resources.Find(r => r.Name == "Wheat").Amount.ToString();
            Villages.Text = player.Villages[0].Name;
            ExpToLevel.Text = player.CurrentExperience + "/" + player.CalculateRequiredExperience(player.Level).ToString();
            foreach (Building building in player.Villages[0].Buildings)
            {
                BuildingsList.Items.Add(building.Name);
            }
            Buildings.Items.Add("Armory");
            Buildings.Items.Add("Barracks");
            Buildings.Items.Add("Defensive Walls");
            Buildings.Items.Add("Grain Farm");
            Buildings.Items.Add("Horse Stable");
            Buildings.Items.Add("Iron Mine");
            Buildings.Items.Add("Sawmill");
            Buildings.Items.Add("Silo");
            Buildings.Items.Add("Stone Mine");
            TownHall ratusz = (TownHall)player.Villages[0].Buildings.Find(b => b.Name == "Ratusz");
            int interval = ratusz.Time * 10;
            timer = new System.Windows.Forms.Timer();
            timer.Interval = interval;
            timer.Enabled = true;
            timer.Tick += generateGold;

        }
        private void generateGold(object sender, EventArgs e)
        {
            TownHall ratusz = (TownHall)player.Villages[0].Buildings.Find(b => b.Name == "Ratusz");
            player.Resources.Find(r => r.Name == "Gold").Amount += ratusz.GenerateGoldPerTime;
            GoldAmount.Text = player.Resources.Find(r => r.Name == "Gold").Amount.ToString();
        }
        public void showBuildingProperties(string name)
        {
            BuildingProperty.Items.Clear();
            Building building = player.Villages[0].Buildings.Find(b => b.Name == name);
            string[] properties = building.ToString().Split(';');
            foreach (string property in properties)
            {
                BuildingProperty.Items.Add(property);
            }
        }
        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void GoldAmount_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void VillageName_Click(object sender, EventArgs e)
        {

        }

        private void VillageName_Enter(object sender, EventArgs e)
        {

        }

        private void TownHall_Click(object sender, EventArgs e)
        {
            showBuildingProperties("Ratusz");
        }

        private void BuildingsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            BuildingProperty.Items.Clear();
            string selectedItem = BuildingsList.SelectedItem?.ToString();
            Building building = player.Villages[0].Buildings.Find(b => b.Name == selectedItem);
            string[] properties = building.ToString().Split(';');
            foreach (string property in properties)
            {
                BuildingProperty.Items.Add(property);
            }
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {

        }

        private void BuildButton_Click(object sender, EventArgs e)
        {
            string selectedItem = Buildings.SelectedItem?.ToString();
            ResourcesNeeded resourcesNeeded = new ResourcesNeeded();
            List<Resource> resources = resourcesNeeded.ResourcesForBuilding(selectedItem);
            bool enoughResources = player.HasEnoughResources(resources);
            if (enoughResources)
            {
                player.afterBuildingBought(resources);
                switch (selectedItem)
                {
                    case "Armory":
                        player.Villages[0].AddBuilding(new Armory("Armory", 1));
                        break;
                    case "Barracks":
                        player.Villages[0].AddBuilding(new Barracks("Barracks", 1));
                        break;
                    case "Defensive Walls":
                        player.Villages[0].AddBuilding(new DefensiveWalls("Defensive Walls", 1));
                        break;
                    case "Grain Farm":
                        player.Villages[0].AddBuilding(new GrainFarm("Grain Farm", 1));
                        break;
                    case "Horse Stable":
                        player.Villages[0].AddBuilding(new HorseStable("Horse Stable", 1));
                        break;
                    case "Iron Mine":
                        player.Villages[0].AddBuilding(new IronMine("Iron Mine", 1));
                        break;
                    case "Sawmill":
                        player.Villages[0].AddBuilding(new Sawmill("Sawmill", 1));
                        player.AddExp(10);
                        PlayerExp.Step = 10;
                        PlayerExp.PerformStep();
                        SawMill.Visible = true;
                        break;
                    case "Silo":
                        player.Villages[0].AddBuilding(new Silo("Silo", 1));
                        break;
                    case "Stone Mine":
                        player.Villages[0].AddBuilding(new StoneMine("Stone Mine", 1));
                        break;
                }
                MessageBox.Show($"Wybudowano {selectedItem}!", "Zasoby",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                ExpToLevel.Text = player.CurrentExperience + "/" + player.CalculateRequiredExperience(player.Level).ToString();
                BuildingsList.Items.Clear();
                foreach (Building building in player.Villages[0].Buildings)
                {            
                    BuildingsList.Items.Add(building.Name);
                }
                GoldAmount.Text = player.Resources.Find(r => r.Name == "Gold").Amount.ToString();
                PlayerLevel.Text = player.Level.ToString();
            }
            else
            {
                MessageBox.Show("Nie masz wystarczająco zasobów!", "Zasoby",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Buildings_SelectedIndexChanged(object sender, EventArgs e)
        {
            ResourcesForBuilding.Items.Clear();
            string selectedItem = Buildings.SelectedItem?.ToString();
            ResourcesNeeded resourcesNeeded = new ResourcesNeeded();
            List<Resource> resources = resourcesNeeded.ResourcesForBuilding(selectedItem);
            foreach (Resource resource in resources)
            {
                ResourcesForBuilding.Items.Add(resource.ToString());
            }
        }

        private void SawMill_Click(object sender, EventArgs e)
        {
            showBuildingProperties("Sawmill");
        }
    }
}
