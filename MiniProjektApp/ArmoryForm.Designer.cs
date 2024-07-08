namespace MiniProjektApp
{
    partial class ArmoryForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            EntitiesList = new ListBox();
            groupBox1 = new GroupBox();
            AllEntites = new Button();
            KamikadzeOnly = new Button();
            TrojansOnly = new Button();
            HussarsOnly = new Button();
            CatapultsOnly = new Button();
            WarriorsOnly = new Button();
            label3 = new Label();
            label2 = new Label();
            ArchersOnly = new Button();
            groupBox2 = new GroupBox();
            WheatRequired = new Label();
            GoldRequired = new Label();
            pictureBox3 = new PictureBox();
            pictureBox2 = new PictureBox();
            label7 = new Label();
            label1 = new Label();
            EntityProperties = new ListBox();
            EntityUpgrade = new Button();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // EntitiesList
            // 
            EntitiesList.FormattingEnabled = true;
            EntitiesList.Location = new Point(6, 252);
            EntitiesList.Name = "EntitiesList";
            EntitiesList.Size = new Size(411, 164);
            EntitiesList.TabIndex = 0;
            EntitiesList.SelectedIndexChanged += EntitiesList_SelectedIndexChanged;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(AllEntites);
            groupBox1.Controls.Add(KamikadzeOnly);
            groupBox1.Controls.Add(TrojansOnly);
            groupBox1.Controls.Add(HussarsOnly);
            groupBox1.Controls.Add(CatapultsOnly);
            groupBox1.Controls.Add(WarriorsOnly);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(EntitiesList);
            groupBox1.Controls.Add(ArchersOnly);
            groupBox1.Location = new Point(23, 32);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(443, 422);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            // 
            // AllEntites
            // 
            AllEntites.Location = new Point(234, 23);
            AllEntites.Name = "AllEntites";
            AllEntites.Size = new Size(94, 29);
            AllEntites.TabIndex = 10;
            AllEntites.Text = "Wszyscy";
            AllEntites.UseVisualStyleBackColor = true;
            AllEntites.Click += AllEntites_Click;
            // 
            // KamikadzeOnly
            // 
            KamikadzeOnly.Location = new Point(234, 128);
            KamikadzeOnly.Name = "KamikadzeOnly";
            KamikadzeOnly.Size = new Size(94, 29);
            KamikadzeOnly.TabIndex = 9;
            KamikadzeOnly.Text = "Kamikadze";
            KamikadzeOnly.UseVisualStyleBackColor = true;
            KamikadzeOnly.Click += KamikadzeOnly_Click;
            // 
            // TrojansOnly
            // 
            TrojansOnly.Location = new Point(119, 128);
            TrojansOnly.Name = "TrojansOnly";
            TrojansOnly.Size = new Size(94, 29);
            TrojansOnly.TabIndex = 8;
            TrojansOnly.Text = "Trojani";
            TrojansOnly.UseVisualStyleBackColor = true;
            TrojansOnly.Click += TrojansOnly_Click;
            // 
            // HussarsOnly
            // 
            HussarsOnly.Location = new Point(6, 128);
            HussarsOnly.Name = "HussarsOnly";
            HussarsOnly.Size = new Size(94, 29);
            HussarsOnly.TabIndex = 7;
            HussarsOnly.Text = "Husarzy";
            HussarsOnly.UseVisualStyleBackColor = true;
            HussarsOnly.Click += HussarsOnly_Click;
            // 
            // CatapultsOnly
            // 
            CatapultsOnly.Location = new Point(234, 68);
            CatapultsOnly.Name = "CatapultsOnly";
            CatapultsOnly.Size = new Size(94, 29);
            CatapultsOnly.TabIndex = 6;
            CatapultsOnly.Text = "Katapulty";
            CatapultsOnly.UseVisualStyleBackColor = true;
            CatapultsOnly.Click += CatapultsOnly_Click;
            // 
            // WarriorsOnly
            // 
            WarriorsOnly.Location = new Point(119, 68);
            WarriorsOnly.Name = "WarriorsOnly";
            WarriorsOnly.Size = new Size(94, 29);
            WarriorsOnly.TabIndex = 5;
            WarriorsOnly.Text = "Wojownicy";
            WarriorsOnly.UseVisualStyleBackColor = true;
            WarriorsOnly.Click += WarriorsOnly_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 238);
            label3.ForeColor = Color.Gold;
            label3.Location = new Point(6, 23);
            label3.Name = "label3";
            label3.Size = new Size(137, 31);
            label3.TabIndex = 4;
            label3.Text = "Sortowanie";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 238);
            label2.ForeColor = Color.Gold;
            label2.Location = new Point(6, 189);
            label2.Name = "label2";
            label2.Size = new Size(117, 31);
            label2.TabIndex = 3;
            label2.Text = "Jednostki";
            // 
            // ArchersOnly
            // 
            ArchersOnly.Location = new Point(6, 68);
            ArchersOnly.Name = "ArchersOnly";
            ArchersOnly.Size = new Size(94, 29);
            ArchersOnly.TabIndex = 2;
            ArchersOnly.Text = "Łucznicy";
            ArchersOnly.UseVisualStyleBackColor = true;
            ArchersOnly.Click += ArchersOnly_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(WheatRequired);
            groupBox2.Controls.Add(GoldRequired);
            groupBox2.Controls.Add(pictureBox3);
            groupBox2.Controls.Add(pictureBox2);
            groupBox2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 238);
            groupBox2.ForeColor = Color.Gold;
            groupBox2.Location = new Point(494, 90);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(209, 116);
            groupBox2.TabIndex = 30;
            groupBox2.TabStop = false;
            // 
            // WheatRequired
            // 
            WheatRequired.AutoSize = true;
            WheatRequired.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 238);
            WheatRequired.Location = new Point(66, 71);
            WheatRequired.Name = "WheatRequired";
            WheatRequired.Size = new Size(24, 28);
            WheatRequired.TabIndex = 31;
            WheatRequired.Text = "0";
            // 
            // GoldRequired
            // 
            GoldRequired.AutoSize = true;
            GoldRequired.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 238);
            GoldRequired.Location = new Point(66, 23);
            GoldRequired.Name = "GoldRequired";
            GoldRequired.Size = new Size(24, 28);
            GoldRequired.TabIndex = 30;
            GoldRequired.Text = "0";
            // 
            // pictureBox3
            // 
            pictureBox3.Image = Properties.Resources.gold;
            pictureBox3.Location = new Point(6, 23);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(32, 32);
            pictureBox3.TabIndex = 28;
            pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.wheat;
            pictureBox2.Location = new Point(6, 71);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(32, 32);
            pictureBox2.TabIndex = 27;
            pictureBox2.TabStop = false;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 238);
            label7.ForeColor = Color.Gold;
            label7.Location = new Point(494, 32);
            label7.Name = "label7";
            label7.Size = new Size(209, 46);
            label7.TabIndex = 31;
            label7.Text = "Wymagania";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 238);
            label1.ForeColor = Color.Gold;
            label1.Location = new Point(494, 221);
            label1.Name = "label1";
            label1.Size = new Size(213, 46);
            label1.TabIndex = 32;
            label1.Text = "Właściwości";
            // 
            // EntityProperties
            // 
            EntityProperties.FormattingEnabled = true;
            EntityProperties.Location = new Point(494, 284);
            EntityProperties.Name = "EntityProperties";
            EntityProperties.Size = new Size(209, 164);
            EntityProperties.TabIndex = 33;
            EntityProperties.SelectedIndexChanged += EntityProperties_SelectedIndexChanged;
            // 
            // EntityUpgrade
            // 
            EntityUpgrade.Location = new Point(23, 480);
            EntityUpgrade.Name = "EntityUpgrade";
            EntityUpgrade.Size = new Size(443, 29);
            EntityUpgrade.TabIndex = 34;
            EntityUpgrade.Text = "Ulepsz!";
            EntityUpgrade.UseVisualStyleBackColor = true;
            EntityUpgrade.Click += EntityUpgrade_Click;
            // 
            // ArmoryForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.SaddleBrown;
            ClientSize = new Size(738, 521);
            Controls.Add(EntityUpgrade);
            Controls.Add(EntityProperties);
            Controls.Add(label1);
            Controls.Add(label7);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "ArmoryForm";
            Text = "Zbrojownia";
            Load += ArmoryForm_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox EntitiesList;
        private GroupBox groupBox1;
        private Button ArchersOnly;
        private GroupBox groupBox2;
        private Label WheatRequired;
        private Label GoldRequired;
        private PictureBox pictureBox3;
        private PictureBox pictureBox2;
        private Label label3;
        private Label label2;
        private Label label7;
        private Label label1;
        private ListBox EntityProperties;
        private Button EntityUpgrade;
        private Button WarriorsOnly;
        private Button KamikadzeOnly;
        private Button TrojansOnly;
        private Button HussarsOnly;
        private Button CatapultsOnly;
        private Button AllEntites;
    }
}