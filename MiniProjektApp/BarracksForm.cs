using MiniProjekt;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniProjektApp
{
    public partial class BarracksForm : Form
    {
        int BarracksLevel;
        double BarracksCost;
        int previousArchersAmount;
        int previousCatapultAmount;
        int previousHussarAmount;
        int previousKamikadzeAmount;
        int previousTrojanAmount;
        int previousWarriorAmount;

        public BarracksForm()
        {
            InitializeComponent();
        }
        private void BarracksForm_Load(object sender, EventArgs e)
        {
            Barracks barrack = (Barracks)MainForm.MainFormInstance.player.Villages[0].Buildings.Find(b => b.Name == "Barracks");
            BarracksLevel = barrack.Level;
            BarracksCost = barrack.Cost;
            // Initialize previous amounts
            previousArchersAmount = 0;
            previousCatapultAmount = 0;
            previousHussarAmount = 0;
            previousKamikadzeAmount = 0;
            previousTrojanAmount = 0;
            previousWarriorAmount = 0;
        }

        private void ArchersAmount_ValueChanged(object sender, EventArgs e)
        {
            int newAmount = Decimal.ToInt32(ArchersAmount.Value);
            UpdateResources("Archer", (int)(newAmount * BarracksCost), ref previousArchersAmount);
        }

        private void CatapultAmount_ValueChanged(object sender, EventArgs e)
        {
            int newAmount = Decimal.ToInt32(CatapultAmount.Value);
            UpdateResources("Catapult", (int)(newAmount * BarracksCost), ref previousCatapultAmount);
        }

        private void HussarAmount_ValueChanged(object sender, EventArgs e)
        {
            int newAmount = Decimal.ToInt32(HussarAmount.Value);
            UpdateResources("Hussar", (int)(newAmount * BarracksCost), ref previousHussarAmount);
        }

        private void KamikadzeAmount_ValueChanged(object sender, EventArgs e)
        {
            int newAmount = Decimal.ToInt32(KamikadzeAmount.Value);
            UpdateResources("Kamikadze", (int)(newAmount * BarracksCost), ref previousKamikadzeAmount);
        }

        private void TrojanAmount_ValueChanged(object sender, EventArgs e)
        {
            int newAmount = Decimal.ToInt32(TrojanAmount.Value);
            UpdateResources("Trojan", (int)(newAmount * BarracksCost), ref previousTrojanAmount);
        }

        private void WarriorAmount_ValueChanged(object sender, EventArgs e)
        {
            int newAmount = Decimal.ToInt32(WarriorAmount.Value);
            UpdateResources("Warrior", (int)(newAmount * BarracksCost), ref previousWarriorAmount);
        }

        private void UpdateResources(string entityName, int newAmount, ref int previousAmount)
        {
            ResourcesNeeded resourcesNeeded = new ResourcesNeeded();
            int amountDifference = newAmount - previousAmount;
            List<Resource> resources = resourcesNeeded.ResourcesForEntities(entityName, BarracksLevel, amountDifference);
            ResourceChange(resources);
            previousAmount = newAmount;
        }

        public void ResourceChange(List<Resource> resources)
        {
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
                else if (resource.Name == "Stone")
                {
                    StoneRequired.Text = (int.Parse(StoneRequired.Text) + resource.Amount).ToString();
                }
                else if (resource.Name == "Iron")
                {
                    IronRequired.Text = (int.Parse(IronRequired.Text) + resource.Amount).ToString();
                }
            }
        }
        public void ShowNotification(string message)
        {
            NotificationForm notification = new NotificationForm(message);
            notification.Location = new Point(this.Location.X + (this.Width - notification.Width) / 2, this.Location.Y + 50);
            notification.Show();
        }
        private void RecruitButton_Click(object sender, EventArgs e)
        {
            List<Resource> resourcesNeeded = new List<Resource>();
            resourcesNeeded.Add(new Gold("Gold", int.Parse(GoldRequired.Text)));
            resourcesNeeded.Add(new Iron("Iron", int.Parse(IronRequired.Text)));
            resourcesNeeded.Add(new Stone("Stone", int.Parse(StoneRequired.Text)));
            resourcesNeeded.Add(new Wheat("Wheat", int.Parse(WheatRequired.Text)));
            if(MainForm.MainFormInstance.player.HasEnoughResources(resourcesNeeded))
            {
                List<Entity> entites = new List<Entity>();
                for(int i = 0; i < ArchersAmount.Value; i++)
                {
                    entites.Add(new Archer());
                }
                for (int i = 0; i < CatapultAmount.Value; i++)
                {
                    entites.Add(new Catapult());
                }
                for (int i = 0; i < HussarAmount.Value; i++)
                {
                    entites.Add(new Hussar());
                }
                for (int i = 0; i < KamikadzeAmount.Value; i++)
                {
                    entites.Add(new Kamikadze());
                }
                for (int i = 0; i < TrojanAmount.Value; i++)
                {
                    entites.Add(new Trojan());
                }
                for (int i = 0; i < WarriorAmount.Value; i++)
                {
                    entites.Add(new Warrior());
                }
                foreach(Entity entity in entites) 
                {
                    MainForm.MainFormInstance.player.Villages[0].AddEntity(entity);
                }
                MainForm.MainFormInstance.player.afterEntitesRecruited(resourcesNeeded);
                ShowNotification("Dodano jednostki!");
            }
            else
            {
                MessageBox.Show("Nie masz wystarczająco zasobów!", "Zasoby",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
