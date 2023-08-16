using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Miggle
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle; // Stop Form from being resizable
        }

        private void visibleText(object sender, EventArgs e)
        {
            textBox2.Text = "";
            textBox3.Text = "";
            textBox2.UseSystemPasswordChar = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(button1.Text == "")
            {
                try
                {
                    SqlConnection con = new SqlConnection();
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Error: " + ex);
                }
            }
        }
    }
}
