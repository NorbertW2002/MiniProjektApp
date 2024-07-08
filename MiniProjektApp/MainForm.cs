using MiniProjekt;
using System.Diagnostics.Eventing.Reader;
using System.Text.Json;
using System.Windows.Forms;
using System.Xml.Linq;
namespace MiniProjektApp
{
    public partial class MainForm : Form
    {
        public Player player;
        public static MainForm MainFormInstance;
        private System.Windows.Forms.Timer GoldTimer;
        private System.Windows.Forms.Timer IronTimer;
        private System.Windows.Forms.Timer StoneTimer;
        private System.Windows.Forms.Timer GrainTimer;
        private System.Windows.Forms.Timer WoodTimer;
        public static int timeDelay = 100;
        private string CurrentSelectedItem;
        public MainForm()
        {
            InitializeComponent();
            AddClickEventToAllControls(this.Controls);
            this.Click += new EventHandler(Form_Click);
            MainFormInstance = this;
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
            player.OnEntitesAdded += (player) =>
            {
                GoldAmount.Text = player.Resources.Find(r => r.Name == "Gold").Amount.ToString();
                WoodAmount.Text = player.Resources.Find(r => r.Name == "Wood").Amount.ToString();
                IronAmount.Text = player.Resources.Find(r => r.Name == "Iron").Amount.ToString();
                StoneAmount.Text = player.Resources.Find(r => r.Name == "Stone").Amount.ToString();
                WheatAmount.Text = player.Resources.Find(r => r.Name == "Wheat").Amount.ToString();
                ArcherAmount.Text = player.Villages[0].Entities.Count(e => e.Name == "Archer").ToString();
                CatapultAmount.Text = player.Villages[0].Entities.Count(e => e.Name == "Catapult").ToString();
                HussarAmount.Text = player.Villages[0].Entities.Count(e => e.Name == "Hussar").ToString();
                KamikadzeAmount.Text = player.Villages[0].Entities.Count(e => e.Name == "Kamikadze").ToString();
                TrojanAmount.Text = player.Villages[0].Entities.Count(e => e.Name == "Trojan").ToString();
                WarriorAmount.Text = player.Villages[0].Entities.Count(e => e.Name == "Warrior").ToString();
            };
            player.OnUpgrade += (player) =>
            {
                ShowNotification("Ulepszono budynek!");
            };
            player.OnBuild += (player) =>
            {
                GoldAmount.Text = player.Resources.Find(r => r.Name == "Gold").Amount.ToString();
                WoodAmount.Text = player.Resources.Find(r => r.Name == "Wood").Amount.ToString();
                StoneAmount.Text = player.Resources.Find(r => r.Name == "Stone").Amount.ToString();
                WheatAmount.Text = player.Resources.Find(r => r.Name == "Wheat").Amount.ToString();
                IronAmount.Text = player.Resources.Find(r => r.Name == "Iron").Amount.ToString();
                ShowNotification("Wybudowano budynek!");
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

        private void Player_OnBuild(Player player)
        {
            throw new NotImplementedException();
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
            if (sender != Armories)
            {
                Armories.Tag = Color.Transparent;
                Armories.Refresh();
            }
            if (sender != horses)
            {
                horses.Tag = Color.Transparent;
                horses.Refresh();
            }
            if (sender != silo)
            {
                silo.Tag = Color.Transparent;
                silo.Refresh();
            }
            if (sender != Walls)
            {
                Walls.Tag = Color.Transparent;
                Walls.Refresh();
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
            Silo silo = (Silo)player.Villages[0].Buildings.Find(b => b.Name == "Silo");
            int siloNumber;
            if (silo == null)
            {
                siloNumber = 1;
            }
            else
            {
                siloNumber = silo.Level;
            }
            int currentWood = player.Resources.Find(r => r.Name == "Wood").Amount;
            if (currentWood < tartak.MaxWoodPerTime * siloNumber + 1)
            {
                player.Resources.Find(r => r.Name == "Wood").Amount += tartak.GenerateWoodPerTime;
                WoodAmount.Text = player.Resources.Find(r => r.Name == "Wood").Amount.ToString();
            }
        }
        private void generateWheat(object sender, EventArgs e)
        {
            GrainFarm farma = (GrainFarm)player.Villages[0].Buildings.Find(b => b.Name == "Grain Farm");
            Silo silo = (Silo)player.Villages[0].Buildings.Find(b => b.Name == "Silo");
            int siloNumber;
            if (silo == null)
            {
                siloNumber = 1;
            }
            else
            {
                siloNumber = silo.Level;
            }
            int currentWheat = player.Resources.Find(r => r.Name == "Wheat").Amount;
            if (currentWheat < farma.MaxFarmPerTime * siloNumber + 1)
            {
                player.Resources.Find(r => r.Name == "Wheat").Amount += farma.GenerateWheatPerTime;
                WheatAmount.Text = player.Resources.Find(r => r.Name == "Wheat").Amount.ToString();
            }
        }
        private void generateStone(object sender, EventArgs e)
        {
            StoneMine kopalnia = (StoneMine)player.Villages[0].Buildings.Find(b => b.Name == "Stone Mine");
            Silo silo = (Silo)player.Villages[0].Buildings.Find(b => b.Name == "Silo");
            int siloNumber;
            if (silo == null)
            {
                siloNumber = 1;
            }
            else
            {
                siloNumber = silo.Level;
            }
            int currentStone = player.Resources.Find(r => r.Name == "Stone").Amount;
            if (currentStone < kopalnia.MaxStonePerTime * siloNumber + 1)
            {
                player.Resources.Find(r => r.Name == "Stone").Amount += kopalnia.GenerateStonePerTime;
                StoneAmount.Text = player.Resources.Find(r => r.Name == "Stone").Amount.ToString();
            }
        }
        private void generateIron(object sender, EventArgs e)
        {
            IronMine kopalnia = (IronMine)player.Villages[0].Buildings.Find(b => b.Name == "Iron Mine");
            Silo silo = (Silo)player.Villages[0].Buildings.Find(b => b.Name == "Silo");
            int siloNumber;
            if (silo == null)
            {
                siloNumber = 1;
            }
            else
            {
                siloNumber = silo.Level;
            }
            int currentIron = player.Resources.Find(r => r.Name == "Iron").Amount;
            if (currentIron < kopalnia.MaxIronPerTime * siloNumber + 1)
            {
                player.Resources.Find(r => r.Name == "Iron").Amount += kopalnia.GenerateIronPerTime;
                IronAmount.Text = player.Resources.Find(r => r.Name == "Iron").Amount.ToString();
            }
        }
        public void showBuildingProperties(string name)
        {
            CurrentSelectedItem = name;
            BuildingProperty.Items.Clear();
            Building building = player.Villages[0].Buildings.Find(b => b.Name == name);
            string[] properties = building.ToString().Split(';');
            foreach (string property in properties)
            {
                BuildingProperty.Items.Add(property);
            }
            ResourcesForUpgrade.Items.Clear();
            ResourcesNeeded resourcesNeeded = new ResourcesNeeded();
            List<Resource> resources = resourcesNeeded.ResourceForUpgrade(name, building.Level);
            foreach (Resource resource in resources)
            {
                ResourcesForUpgrade.Items.Add(resource.ToString());
            }
        }

        private void TownHall_Click(object sender, EventArgs e)
        {
            showBuildingProperties("Ratusz");
            TownHall.Tag = Color.Blue; // Zmiana koloru obramowania na niebieski
            TownHall.Refresh();
        }

        private void BuildingsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedItem = BuildingsList.SelectedItem?.ToString();
            showBuildingProperties(selectedItem);
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
        private void Armory_DoubleClick(object sender, EventArgs e)
        {
            var armoryform = new ArmoryForm();
            armoryform.Show();
        }
        public void ShowNotification(string message)
        {
            NotificationForm notification = new NotificationForm(message);
            notification.Location = new Point(this.Location.X + (this.Width - notification.Width) / 2, this.Location.Y + 50);
            notification.Show();
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
        private void Armories_Paint(object sender, PaintEventArgs e)
        {
            if (Armories.Tag == null) { Armories.Tag = Color.Transparent; } // Brak obramowania jako domyślny kolor
            ControlPaint.DrawBorder(e.Graphics, Armories.ClientRectangle, (Color)Armories.Tag, ButtonBorderStyle.Solid);
        }
        private void Silo_Paint(object sender, PaintEventArgs e)
        {
            if (silo.Tag == null) { silo.Tag = Color.Transparent; } // Brak obramowania jako domyślny kolor
            ControlPaint.DrawBorder(e.Graphics, silo.ClientRectangle, (Color)silo.Tag, ButtonBorderStyle.Solid);
        }
        private void Walls_Paint(object sender, PaintEventArgs e)
        {
            if (Walls.Tag == null) { Walls.Tag = Color.Transparent; } // Brak obramowania jako domyślny kolor
            ControlPaint.DrawBorder(e.Graphics, Walls.ClientRectangle, (Color)Walls.Tag, ButtonBorderStyle.Solid);
        }
        private void Horse_Paint(object sender, PaintEventArgs e)
        {
            if (horses.Tag == null) { horses.Tag = Color.Transparent; } // Brak obramowania jako domyślny kolor
            ControlPaint.DrawBorder(e.Graphics, horses.ClientRectangle, (Color)horses.Tag, ButtonBorderStyle.Solid);
        }

        private void Armories_Click(object sender, EventArgs e)
        {
            showBuildingProperties("Armory");
            Armories.Tag = Color.Blue; // Zmiana koloru obramowania na niebieski
            Armories.Refresh();
        }

        private void horses_Click(object sender, EventArgs e)
        {
            showBuildingProperties("Horse Stable");
            horses.Tag = Color.Blue; // Zmiana koloru obramowania na niebieski
            horses.Refresh();
        }

        private void Walls_Click(object sender, EventArgs e)
        {
            showBuildingProperties("Defensive Walls");
            Walls.Tag = Color.Blue; // Zmiana koloru obramowania na niebieski
            Walls.Refresh();
        }

        private void silo_Click(object sender, EventArgs e)
        {
            showBuildingProperties("Silo");
            silo.Tag = Color.Blue; // Zmiana koloru obramowania na niebieski
            silo.Refresh();
        }

        private void UpgradeButton_Click(object sender, EventArgs e)
        {

            ResourcesNeeded resourcesNeeded = new ResourcesNeeded();
            Building building = player.Villages[0].Buildings.Find(b => b.Name == CurrentSelectedItem);
            if (building != null)
            {
                List<Resource> resources = resourcesNeeded.ResourceForUpgrade(CurrentSelectedItem, building.Level);
                if (player.HasEnoughResources(resources))
                {
                    building.Level++;
                    player.afterUpgrade(resources);
                }
            }
        }

        private void zapiszGraczaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "JSON files (*.json)|*.json";
                saveFileDialog.Title = "Save as JSON";

                // Wyświetlenie okna dialogowego
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName;

                    // Serializacja obiektu do JSON
                    string jsonString = JsonSerializer.Serialize(player, new JsonSerializerOptions { WriteIndented = true });

                    // Zapis do pliku
                    File.WriteAllText(filePath, jsonString);
                }
            }
        }

        private void wczytajGraczaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "JSON files (*.json)|*.json";
                openFileDialog.Title = "Open JSON file";

                // Wyświetlenie okna dialogowego
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;

                    // Odczyt pliku
                    string jsonString = File.ReadAllText(filePath);

                    // Deserializacja JSON do obiektu
                    Player newPlayer = JsonSerializer.Deserialize<Player>(jsonString);
                    player = newPlayer;
                }
            }
        }

    }
}
