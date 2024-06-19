using MiniProjekt;
using System.Diagnostics.Eventing.Reader;
using System.Windows.Forms;
using System.Xml.Linq;
namespace MiniProjektApp
{
    public partial class MainForm : Form
    {
        Player player;
        private System.Windows.Forms.Timer GoldTimer;
        private System.Windows.Forms.Timer IronTimer;
        private System.Windows.Forms.Timer StoneTimer;
        private System.Windows.Forms.Timer GrainTimer;
        private System.Windows.Forms.Timer WoodTimer;
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
            player.OnExpGained += (player, expgained) =>
            {
                ExpToLevel.Text = player.CurrentExperience + "/" + player.CalculateRequiredExperience(player.Level).ToString();
                PlayerExp.Step = 10;
                PlayerExp.PerformStep();
            };
            player.OnLvlGained += (player) =>
            {
                ExpToLevel.Text = player.CurrentExperience + "/" + player.CalculateRequiredExperience(player.Level).ToString();
                PlayerLevel.Text = player.Level.ToString();
                PlayerExp.Minimum = 0;
                PlayerExp.Maximum = player.CalculateRequiredExperience(player.Level);
                PlayerExp.Value = player.CurrentExperience;
            };

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
            int interval = ratusz.Time * 100;
            GoldTimer = new System.Windows.Forms.Timer();
            GoldTimer.Interval = interval;
            GoldTimer.Enabled = true;
            GoldTimer.Tick += generateGold;

        }
        private void generateGold(object sender, EventArgs e)
        {
            TownHall ratusz = (TownHall)player.Villages[0].Buildings.Find(b => b.Name == "Ratusz");
            player.Resources.Find(r => r.Name == "Gold").Amount += ratusz.GenerateGoldPerTime;
            GoldAmount.Text = player.Resources.Find(r => r.Name == "Gold").Amount.ToString();
        }
        private void generateWood(object sender, EventArgs e)
        {
            Sawmill tartak = (Sawmill)player.Villages[0].Buildings.Find(b => b.Name == "Sawmill");
            player.Resources.Find(r => r.Name == "Wood").Amount += tartak.GenerateWoodPerTime;
            WoodAmount.Text = player.Resources.Find(r => r.Name == "Wood").Amount.ToString();
        }
        private void generateWheat(object sender, EventArgs e)
        {
            GrainFarm farma = (GrainFarm)player.Villages[0].Buildings.Find(b => b.Name == "Grain Farm");
            player.Resources.Find(r => r.Name == "Wheat").Amount += farma.GenerateWheatPerTime;
            WheatAmount.Text = player.Resources.Find(r => r.Name == "Wheat").Amount.ToString();
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
            if (enoughResources && !player.Villages[0].Buildings.Any(b => b.Name == selectedItem))
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
                        player.AddExp(20);
                        GrainFarm.Visible = true;
                        GrainFarm farma = (GrainFarm)player.Villages[0].Buildings.Find(b => b.Name == "Grain Farm");
                        int interval = farma.Time * 100;
                        GrainTimer = new System.Windows.Forms.Timer();
                        GrainTimer.Interval = interval;
                        GrainTimer.Enabled = true;
                        GrainTimer.Tick += generateWheat;
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
                        SawMill.Visible = true;
                        Sawmill tartak = (Sawmill)player.Villages[0].Buildings.Find(b => b.Name == "Sawmill");
                        interval = tartak.Time * 100;
                        WoodTimer = new System.Windows.Forms.Timer();
                        WoodTimer.Interval = interval;
                        WoodTimer.Enabled = true;
                        WoodTimer.Tick += generateWood;
                        break;
                    case "Silo":
                        player.Villages[0].AddBuilding(new Silo("Silo", 1));
                        break;
                    case "Stone Mine":
                        player.Villages[0].AddBuilding(new StoneMine("Stone Mine", 1));
                        break;
                }
                BuildingsList.Items.Clear();
                foreach (Building building in player.Villages[0].Buildings)
                {
                    BuildingsList.Items.Add(building.Name);
                }
                GoldAmount.Text = player.Resources.Find(r => r.Name == "Gold").Amount.ToString();
                WoodAmount.Text = player.Resources.Find(r => r.Name == "Wood").Amount.ToString();
            }
            else if (player.Villages[0].Buildings.Any(b => b.Name == selectedItem))
            {
                MessageBox.Show("Wybudowałeś już ten budynek!", "Zasoby",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void GrainFarm_Click(object sender, EventArgs e)
        {
            showBuildingProperties("Grain Farm");
        }
    }
}
