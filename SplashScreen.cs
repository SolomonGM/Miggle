using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Miggle
{
    public partial class SplashScreen : Form
    {
        public Point mouseLocation;

        private bool isLoginFormOpen = false;
        private Login loginForm;
        public SplashScreen() => InitializeComponent();

        public void FormLocation()
        {
            Screen currentScreen = Screen.FromPoint(Cursor.Position);
            this.StartPosition = FormStartPosition.Manual;
            this.Location = currentScreen.WorkingArea.Location;
        }
        private async Task DelayAndOpenFormAsync()
        {
            this.Hide();
            await Task.Delay(3000);

            loginForm = new Login();
            loginForm.FormClosed += LoginForm_FormClosed;
            FormLocation();
            loginForm.Show();

            isLoginFormOpen = true;
        }

        private void LoginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            isLoginFormOpen = false;
        }

        private void CloseAndOpenForms()
        {
            _ = DelayAndOpenFormAsync();
        }

        private void loaderTime_Tick(object sender, EventArgs e)
        {
            progressBar1.Increment(2);
            if (progressBar1.Value == 100)
            {
                loaderTime.Stop();

                CloseAndOpenForms();
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseLocation = new Point(-e.X, -e.Y);
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                Point mousePose = Control.MousePosition;
                mousePose.Offset(mouseLocation.X, mouseLocation.Y);
                Location = mousePose;
            }
        }
    }
}
