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
        public static int timeDelay = 1;
        public MainForm()
        {
            InitializeComponent();
            AddClickEventToAllControls(this.Controls);
            this.Click += new EventHandler(Form_Click);
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
            int interval = ratusz.Time * timeDelay;
            GoldTimer = new System.Windows.Forms.Timer();
            GoldTimer.Interval = interval;
            GoldTimer.Enabled = true;
            GoldTimer.Tick += generateGold;
        }
        private void AddClickEventToAllControls(Control.ControlCollection controls)
        {
            foreach (Control control in controls)
            {
                control.Click += new EventHandler(Form_Click);
                if (control.Controls.Count > 0)
                {
                    AddClickEventToAllControls(control.Controls); // Rekurencyjnie dodaj do podkontrolek
                }
            }
        }
        private void Form_Click(object sender, EventArgs e)
        {
            if (sender != SawMill)
            {
                SawMill.Tag = Color.Transparent; // Brak obramowania po kliknięciu gdzie indziej
                SawMill.Refresh();
            }
            if (sender != TownHall)
            {
                TownHall.Tag = Color.Transparent;
                TownHall.Refresh();
            }
            if (sender != StoneMine)
            {
                StoneMine.Tag = Color.Transparent;
                StoneMine.Refresh();
            }
            if (sender != GrainFarm)
            {
                GrainFarm.Tag = Color.Transparent;
                GrainFarm.Refresh();
            }
            if (sender != IronMine)
            {
                IronMine.Tag = Color.Transparent;
                IronMine.Refresh();
            }
            if (sender != Barracks)
            {
                Barracks.Tag = Color.Transparent;
                Barracks.Refresh();
            }
        }
        private void generateGold(object sender, EventArgs e)
        {
            TownHall ratusz = (TownHall)player.Villages[0].Buildings.Find(b => b.Name == "Ratusz");
            int currentGold = player.Resources.Find(r => r.Name == "Gold").Amount;
            if (currentGold < ratusz.MaxGoldPerTime)
            {
                player.Resources.Find(r => r.Name == "Gold").Amount += ratusz.GenerateGoldPerTime;
                GoldAmount.Text = player.Resources.Find(r => r.Name == "Gold").Amount.ToString();
            }
        }
        private void generateWood(object sender, EventArgs e)
        {
            Sawmill tartak = (Sawmill)player.Villages[0].Buildings.Find(b => b.Name == "Sawmill");
            int currentWood = player.Resources.Find(r => r.Name == "Wood").Amount;
            if (currentWood < tartak.MaxWoodPerTime)
            {
                player.Resources.Find(r => r.Name == "Wood").Amount += tartak.GenerateWoodPerTime;
                WoodAmount.Text = player.Resources.Find(r => r.Name == "Wood").Amount.ToString();
            }
        }
        private void generateWheat(object sender, EventArgs e)
        {
            GrainFarm farma = (GrainFarm)player.Villages[0].Buildings.Find(b => b.Name == "Grain Farm");
            int currentWheat = player.Resources.Find(r => r.Name == "Wheat").Amount;
            if (currentWheat < farma.MaxFarmPerTime)
            {
                player.Resources.Find(r => r.Name == "Wheat").Amount += farma.GenerateWheatPerTime;
                WheatAmount.Text = player.Resources.Find(r => r.Name == "Wheat").Amount.ToString();
            }
        }
        private void generateStone(object sender, EventArgs e)
        {
            StoneMine kopalnia = (StoneMine)player.Villages[0].Buildings.Find(b => b.Name == "Stone Mine");
            int currentStone = player.Resources.Find(r => r.Name == "Stone").Amount;
            if (currentStone < kopalnia.MaxStonePerTime)
            {
                player.Resources.Find(r => r.Name == "Stone").Amount += kopalnia.GenerateStonePerTime;
                StoneAmount.Text = player.Resources.Find(r => r.Name == "Stone").Amount.ToString();
            }
        }
        private void generateIron(object sender, EventArgs e)
        {
            IronMine kopalnia = (IronMine)player.Villages[0].Buildings.Find(b => b.Name == "Iron Mine");
            int currentIron = player.Resources.Find(r => r.Name == "Iron").Amount;
            if (currentIron < kopalnia.MaxIronPerTime)
            {
                player.Resources.Find(r => r.Name == "Iron").Amount += kopalnia.GenerateIronPerTime;
                IronAmount.Text = player.Resources.Find(r => r.Name == "Iron").Amount.ToString();
            }
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
            TownHall.Tag = Color.Blue; // Zmiana koloru obramowania na niebieski
            TownHall.Refresh();
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
                        player.AddExp(20);
                        Armories.Visible = true;
                        break;
                    case "Barracks":
                        player.Villages[0].AddBuilding(new Barracks("Barracks", 1));
                        player.AddExp(30);
                        Barracks.Visible = true;
                        break;
                    case "Defensive Walls":
                        player.Villages[0].AddBuilding(new DefensiveWalls("Defensive Walls", 1));
                        player.AddExp(35);
                        Walls.Visible = true;
                        break;
                    case "Grain Farm":
                        player.Villages[0].AddBuilding(new GrainFarm("Grain Farm", 1));
                        player.AddExp(20);
                        GrainFarm.Visible = true;
                        GrainFarm farma = (GrainFarm)player.Villages[0].Buildings.Find(b => b.Name == "Grain Farm");
                        int interval = farma.Time * timeDelay;
                        GrainTimer = new System.Windows.Forms.Timer();
                        GrainTimer.Interval = interval;
                        GrainTimer.Enabled = true;
                        GrainTimer.Tick += generateWheat;
                        break;
                    case "Horse Stable":
                        player.Villages[0].AddBuilding(new HorseStable("Horse Stable", 1));
                        player.AddExp(25);
                        horses.Visible = true;
                        break;
                    case "Iron Mine":
                        player.Villages[0].AddBuilding(new IronMine("Iron Mine", 1));
                        player.AddExp(25);
                        IronMine.Visible = true;
                        IronMine kopalniaZelaza = (IronMine)player.Villages[0].Buildings.Find(b => b.Name == "Iron Mine");
                        interval = kopalniaZelaza.Time * timeDelay;
                        IronTimer = new System.Windows.Forms.Timer();
                        IronTimer.Interval = interval;
                        IronTimer.Enabled = true;
                        IronTimer.Tick += generateIron;
                        break;
                    case "Sawmill":
                        player.Villages[0].AddBuilding(new Sawmill("Sawmill", 1));
                        player.AddExp(10);
                        SawMill.Visible = true;
                        Sawmill tartak = (Sawmill)player.Villages[0].Buildings.Find(b => b.Name == "Sawmill");
                        interval = tartak.Time * timeDelay;
                        WoodTimer = new System.Windows.Forms.Timer();
                        WoodTimer.Interval = interval;
                        WoodTimer.Enabled = true;
                        WoodTimer.Tick += generateWood;
                        break;
                    case "Silo":
                        player.Villages[0].AddBuilding(new Silo("Silo", 1));
                        player.AddExp(30);
                        silo.Visible = true;
                        break;
                    case "Stone Mine":
                        player.Villages[0].AddBuilding(new StoneMine("Stone Mine", 1));
                        player.AddExp(15);
                        StoneMine.Visible = true;
                        StoneMine kopalniaKamienia = (StoneMine)player.Villages[0].Buildings.Find(b => b.Name == "Stone Mine");
                        interval = kopalniaKamienia.Time * timeDelay;
                        StoneTimer = new System.Windows.Forms.Timer();
                        StoneTimer.Interval = interval;
                        StoneTimer.Enabled = true;
                        StoneTimer.Tick += generateStone;
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

            ResourcesForUpgrade.Items.Clear();
            string upgradeItem = Buildings.SelectedItem?.ToString();
            List<Resource> resources1 = resourcesNeeded.ResourceForUpgrade(upgradeItem, 1);
            foreach (Resource resource in resources1)
            {
                ResourcesForUpgrade.Items.Add(resource.ToString());
            }

        }

        private void SawMill_Click(object sender, EventArgs e)
        {
            showBuildingProperties("Sawmill");
            SawMill.Tag = Color.Blue; // Zmiana koloru obramowania na niebieski
            SawMill.Refresh();
        }

        private void GrainFarm_Click(object sender, EventArgs e)
        {
            showBuildingProperties("Grain Farm");
            GrainFarm.Tag = Color.Blue; // Zmiana koloru obramowania na niebieski
            GrainFarm.Refresh();
        }

        private void StoneMine_Click(object sender, EventArgs e)
        {
            showBuildingProperties("Stone Mine");
            StoneMine.Tag = Color.Blue; // Zmiana koloru obramowania na niebieski
            StoneMine.Refresh();
        }
        private void IronMine_Click(object sender, EventArgs e)
        {
            showBuildingProperties("Iron Mine");
            IronMine.Tag = Color.Blue; // Zmiana koloru obramowania na niebieski
            IronMine.Refresh();
        }

        private void Barracks_Click(object sender, EventArgs e)
        {
            showBuildingProperties("Barracks");
            Barracks.Tag = Color.Blue; // Zmiana koloru obramowania na niebieski
            Barracks.Refresh();
        }

        private void Barracks_DoubleClick(object sender, EventArgs e)
        {
            var barracksform = new BarracksForm();
            barracksform.Show();
        }
        private void SawMill_Paint(object sender, PaintEventArgs e)
        {
            if (SawMill.Tag == null) { SawMill.Tag = Color.Transparent; } // Brak obramowania jako domyślny kolor
            ControlPaint.DrawBorder(e.Graphics, SawMill.ClientRectangle, (Color)SawMill.Tag, ButtonBorderStyle.Solid);
        }
        private void TownHall_Paint(object sender, PaintEventArgs e)
        {
            if (TownHall.Tag == null) { TownHall.Tag = Color.Transparent; } // Brak obramowania jako domyślny kolor
            ControlPaint.DrawBorder(e.Graphics, TownHall.ClientRectangle, (Color)TownHall.Tag, ButtonBorderStyle.Solid);
        }
        private void StoneMine_Paint(object sender, PaintEventArgs e)
        {
            if (StoneMine.Tag == null) { StoneMine.Tag = Color.Transparent; } // Brak obramowania jako domyślny kolor
            ControlPaint.DrawBorder(e.Graphics, StoneMine.ClientRectangle, (Color)StoneMine.Tag, ButtonBorderStyle.Solid);
        }
        private void GrainFarm_Paint(object sender, PaintEventArgs e)
        {
            if (GrainFarm.Tag == null) { GrainFarm.Tag = Color.Transparent; } // Brak obramowania jako domyślny kolor
            ControlPaint.DrawBorder(e.Graphics, GrainFarm.ClientRectangle, (Color)GrainFarm.Tag, ButtonBorderStyle.Solid);
        }
        private void IronMine_Paint(object sender, PaintEventArgs e)
        {
            if (IronMine.Tag == null) { IronMine.Tag = Color.Transparent; } // Brak obramowania jako domyślny kolor
            ControlPaint.DrawBorder(e.Graphics, IronMine.ClientRectangle, (Color)IronMine.Tag, ButtonBorderStyle.Solid);
        }

        private void Barracks_Paint(object sender, PaintEventArgs e)
        {
            if (Barracks.Tag == null) { Barracks.Tag = Color.Transparent; } // Brak obramowania jako domyślny kolor
            ControlPaint.DrawBorder(e.Graphics, Barracks.ClientRectangle, (Color)Barracks.Tag, ButtonBorderStyle.Solid);
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox13_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void UpgradeButton_Click(object sender, EventArgs e)
        {

        }
    }
}
