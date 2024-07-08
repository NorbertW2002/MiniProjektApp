using System;
using System.Drawing;
using System.Windows.Forms;

namespace MiniProjektApp
{
    public partial class NotificationForm : Form
    {
        System.Windows.Forms.Timer timer;

        public NotificationForm(string message)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
            this.FormBorderStyle = FormBorderStyle.None;
            this.BackColor = Color.FromArgb(255, 255, 192);
            this.Padding = new Padding(10);
            this.ShowInTaskbar = false;

            Label messageLabel = new Label();
            messageLabel.Text = message;
            messageLabel.AutoSize = true;
            messageLabel.BackColor = Color.Transparent;
            this.Controls.Add(messageLabel);

            this.AutoSize = true;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;

            timer = new System.Windows.Forms.Timer();
            timer.Interval = 3000; // 3 sekundy
            timer.Tick += Timer_Tick;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            timer.Stop();
            this.Close();
        }

        private void NotificationForm_Load(object sender, EventArgs e)
        {

        }
    }
}
