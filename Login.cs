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
        public bool success = false;

        public Login()
        {
            InitializeComponent();
        }
        public string connectionString; //connection string as Public Field to be re-usable. 
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
            if (!string.IsNullOrWhiteSpace(textBox1.Text) ||
                !string.IsNullOrWhiteSpace(textBox2.Text) ||
                !string.IsNullOrWhiteSpace(textBox3.Text)) //Check if username and password inputs are not null
            {
                MessageBox.Show("Please provide valid Username and/or Password!");
            }
            else
            { 
                try
                {
                    connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=registerform;Integrated Security=True";
                    SqlConnection con = new SqlConnection(connectionString); //attempt to connect to SQLManagament database.
                    success = true;
                    con.Open();

                    if (success)
                    {
                        MessageBox.Show("Successful Connection to database");
                        string username = textBox1.Text;
                        string password = textBox2.Text;

                        var insertQuery = "INSERT INTO register_table (username, password) VALUES (@USERNAME, @PASSWORD)";  //SQL insertion

                        SqlCommand sqlcmd = new SqlCommand(insertQuery, con);   
                        sqlcmd.Parameters.AddWithValue("@USERNAME", username);
                        sqlcmd.Parameters.AddWithValue("@PASSWORD", password);

                        int isAffected = sqlcmd.ExecuteNonQuery();
                        if(isAffected > 0)
                        {
                            MessageBox.Show("Login Successful!");
                        }
                        else
                        {
                            MessageBox.Show("Re-enter sign-up details.");
                        }

                    }
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex);
                }
            }
        }
    }
}
