using System;
using System.Drawing;
using System.Windows.Forms;

namespace GPOS
{
    public partial class ToastNotification : Form
    {
        private System.Windows.Forms.Timer timer;
        private Label messageLabel;

        public ToastNotification(string message)
        {
            // === Form Styling ===
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.Manual;
            this.TopMost = true;
            this.BackColor = Color.FromArgb(255, 245, 230); // Soft tone
            this.Size = new Size(320, 80);
            this.ShowInTaskbar = false;
            this.Opacity = 0.95;

            // === Label Styling ===
            messageLabel = new Label();
            messageLabel.Text = message;
            messageLabel.Font = new Font("Century Gothic", 10, FontStyle.Bold);
            messageLabel.ForeColor = Color.DarkRed;
            messageLabel.AutoSize = false;
            messageLabel.TextAlign = ContentAlignment.MiddleCenter;
            messageLabel.Dock = DockStyle.Fill;
            this.Controls.Add(messageLabel);

            // === Position Bottom-Right ===
            int x = Screen.PrimaryScreen.WorkingArea.Width - this.Width - 10;
            int y = Screen.PrimaryScreen.WorkingArea.Height - this.Height - 10;
            this.Location = new Point(x, y);

            // === Display Duration Timer ===
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 3000; // show for 3 seconds
            timer.Tick += Timer_Tick;
            timer.Start();

            timer.Start();

            // === Play Sound ===
            //System.Media.SoundPlayer player = new System.Media.SoundPlayer("notify.wav");
            //player.Play();
            //// === Play system alert sound ===
            System.Media.SystemSounds.Exclamation.Play();


        }
        private void ToastNotification_Load(object sender, EventArgs e)
        {
            // Optional: do something on load
        }
        // === After timer elapses, fade out smoothly ===
        private void Timer_Tick(object sender, EventArgs e)
        {
            timer.Stop();

            System.Windows.Forms.Timer fadeTimer = new System.Windows.Forms.Timer();
            fadeTimer.Interval = 50; // controls fade speed
            fadeTimer.Tick += (s, args) =>
            {
                if (this.Opacity > 0)
                {
                    this.Opacity -= 0.05;
                }
                else
                {
                    fadeTimer.Stop();
                    this.Close();
                }
            };
            fadeTimer.Start();
        }

        // === Static Helper Method (optional) ===
        // Call this directly anywhere: ToastNotification.ShowToast("Message here");
        public static void ShowToast(string message)
        {
            ToastNotification toast = new ToastNotification(message);
            toast.Show();
        }
    }

}
