namespace MiniProjektApp
{
    partial class NewPlayerForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            AddNewPlayerButton = new Button();
            NewPlayerNameTextBox = new TextBox();
            label1 = new Label();
            label2 = new Label();
            SuspendLayout();
            // 
            // AddNewPlayerButton
            // 
            AddNewPlayerButton.Location = new Point(248, 266);
            AddNewPlayerButton.Name = "AddNewPlayerButton";
            AddNewPlayerButton.Size = new Size(311, 55);
            AddNewPlayerButton.TabIndex = 0;
            AddNewPlayerButton.Text = "Dodaj nowego gracza!";
            AddNewPlayerButton.UseVisualStyleBackColor = true;
            AddNewPlayerButton.Click += AddNewPlayerButton_Click;
            // 
            // NewPlayerNameTextBox
            // 
            NewPlayerNameTextBox.Location = new Point(248, 212);
            NewPlayerNameTextBox.Name = "NewPlayerNameTextBox";
            NewPlayerNameTextBox.PlaceholderText = "Imię nowego gracza";
            NewPlayerNameTextBox.Size = new Size(311, 27);
            NewPlayerNameTextBox.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Old English Text MT", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(226, 37);
            label1.Name = "label1";
            label1.Size = new Size(360, 48);
            label1.TabIndex = 2;
            label1.Text = "Witaj w plemionach!";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Franklin Gothic Medium Cond", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(248, 130);
            label2.Name = "label2";
            label2.Size = new Size(297, 29);
            label2.TabIndex = 3;
            label2.Text = "Aby rozpocząć wpisz nazwę gracza";
            // 
            // NewPlayerForm
            // 
            AcceptButton = AddNewPlayerButton;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(800, 450);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(NewPlayerNameTextBox);
            Controls.Add(AddNewPlayerButton);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "NewPlayerForm";
            Text = "Plemiona";
            Load += AddNewPlayer_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button AddNewPlayerButton;
        private TextBox NewPlayerNameTextBox;
        private Label label1;
        private Label label2;
    }
}
