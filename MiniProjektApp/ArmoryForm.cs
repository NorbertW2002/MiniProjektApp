using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MiniProjekt;
using MiniProjektApp.Properties;
namespace MiniProjektApp
{
    public partial class ArmoryForm : Form
    {
        protected List<Entity> Entites;
        public ArmoryForm()
        {
            InitializeComponent();
        }

        private void ArmoryForm_Load(object sender, EventArgs e)
        {
            LoadList();
            MainForm.MainFormInstance.player.OnEntityUpgrade += (player) =>
            {
                EntitiesList.Items.Clear();
                Entites = MainForm.MainFormInstance.player.Villages[0].Entities;
                int id = 0;
                foreach (Entity entity in Entites)
                {
                    EntitiesList.Items.Add("ID:" + id + ", Name: " + entity.Name + ", Level: " + entity.Level);
                    id++;
                }
            };
        }

        public void ShowNotification(string message)
        {
            NotificationForm notification = new NotificationForm(message);
            notification.Location = new Point(this.Location.X + (this.Width - notification.Width) / 2, this.Location.Y + 50);
            notification.Show();
        }
        private void EntityProperties_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void LoadList()
        {

            EntitiesList.Items.Clear();
            Entites = MainForm.MainFormInstance.player.Villages[0].Entities;
            int id = 0;
            foreach (Entity entity in Entites)
            {
                EntitiesList.Items.Add("ID:" + id + ", Name: " + entity.Name + ", Level: " + entity.Level);
                id++;
            }
        }
        private void EntitiesList_SelectedIndexChanged(object sender, EventArgs e)
        {
            EntityProperties.Items.Clear();
            string selectedItem = EntitiesList.SelectedItem?.ToString();
            string[] splitString = selectedItem.Split(',');
            string[] idSplit = splitString[0].Split(':');
            int id = Int32.Parse(idSplit[1]);
            string[] props = Entites[id].ToString().Split(';');
            foreach (string prop in props)
            {
                EntityProperties.Items.Add(prop);
            }
            int level = Entites[id].Level;
            string name = Entites[id].Name;
            ResourcesNeeded resourcesNeeded = new ResourcesNeeded();
            List<Resource> resources = resourcesNeeded.ResourcesForEntityUpgrade(name, level);
            foreach (Resource resource in resources)
            {
                if (resource.Name == "Gold")
                {
                    GoldRequired.Text = (int.Parse(GoldRequired.Text) + resource.Amount).ToString();
                }
                else if (resource.Name == "Wheat")
                {
                    WheatRequired.Text = (int.Parse(WheatRequired.Text) + resource.Amount).ToString();
                }
            }
        }

        private void EntityUpgrade_Click(object sender, EventArgs e)
        {
            List<Resource> resourcesNeeded = new List<Resource>();
            resourcesNeeded.Add(new Gold("Gold", int.Parse(GoldRequired.Text)));
            resourcesNeeded.Add(new Wheat("Wheat", int.Parse(WheatRequired.Text)));
            string selectedItem = EntitiesList.SelectedItem?.ToString();
            if (selectedItem != null)
            {
                if (MainForm.MainFormInstance.player.HasEnoughResources(resourcesNeeded))
                {
                    string[] splitString = selectedItem.Split(',');
                    string[] idSplit = splitString[0].Split(':');
                    int id = Int32.Parse(idSplit[1]);
                    MainForm.MainFormInstance.player.Villages[0].Entities[id].Level++;
                    MainForm.MainFormInstance.player.afterEntityUpgrade(resourcesNeeded);
                    ShowNotification("Ulepszono jednostki!");
                }
                else
                {
                    MessageBox.Show("Nie masz wystarczająco zasobów!", "Zasoby",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ArchersOnly_Click(object sender, EventArgs e)
        {
            LoadList();
            for (int n = EntitiesList.Items.Count - 1; n >= 0; --n)
            {
                string removelistitem = "Archer";
                if (!EntitiesList.Items[n].ToString().Contains(removelistitem))
                {
                    EntitiesList.Items.RemoveAt(n);
                }
            }
        }

        private void WarriorsOnly_Click(object sender, EventArgs e)
        {
            LoadList();
            for (int n = EntitiesList.Items.Count - 1; n >= 0; --n)
            {
                string removelistitem = "Warrior";
                if (!EntitiesList.Items[n].ToString().Contains(removelistitem))
                {
                    EntitiesList.Items.RemoveAt(n);
                }
            }
        }

        private void CatapultsOnly_Click(object sender, EventArgs e)
        {
            LoadList();
            for (int n = EntitiesList.Items.Count - 1; n >= 0; --n)
            {
                string removelistitem = "Catapult";
                if (!EntitiesList.Items[n].ToString().Contains(removelistitem))
                {
                    EntitiesList.Items.RemoveAt(n);
                }
            }
        }

        private void HussarsOnly_Click(object sender, EventArgs e)
        {
            LoadList();
            for (int n = EntitiesList.Items.Count - 1; n >= 0; --n)
            {
                string removelistitem = "Hussar";
                if (!EntitiesList.Items[n].ToString().Contains(removelistitem))
                {
                    EntitiesList.Items.RemoveAt(n);
                }
            }
        }

        private void TrojansOnly_Click(object sender, EventArgs e)
        {
            LoadList();
            for (int n = EntitiesList.Items.Count - 1; n >= 0; --n)
            {
                string removelistitem = "Trojan";
                if (!EntitiesList.Items[n].ToString().Contains(removelistitem))
                {
                    EntitiesList.Items.RemoveAt(n);
                }
            }
        }

        private void KamikadzeOnly_Click(object sender, EventArgs e)
        {
            LoadList();
            for (int n = EntitiesList.Items.Count - 1; n >= 0; --n)
            {
                string removelistitem = "Kamikadze";
                if (!EntitiesList.Items[n].ToString().Contains(removelistitem))
                {
                    EntitiesList.Items.RemoveAt(n);
                }
            }
        }

        private void AllEntites_Click(object sender, EventArgs e)
        {
            LoadList();
        }
    }
}
