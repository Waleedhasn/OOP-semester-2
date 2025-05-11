using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using OOP_Project.UI;
using OOP_Project.DL;

namespace OOP_Project
{
    public partial class Login : Form
    {
        private DBConnection db = DBConnection.GetInstance();
        public Login()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SignUp signUp = new SignUp();
            signUp.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;

            if (username == "Waleed" && password == "12345") // Admin authentication
            {
                AdminDashboard adminDashboard = new AdminDashboard();
                adminDashboard.Show();
                this.Hide();
            }
            else if (AuthenticateUser(username, password)) // Customer authentication
            {
                CustomerDashboard customerDashboard = new CustomerDashboard();
                customerDashboard.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid username or password!", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool AuthenticateUser(string username, string password)
        {
            string query = "SELECT COUNT(*) FROM Users WHERE Username = @username AND Password = @password";

            using (MySqlCommand cmd = new MySqlCommand(query, db.GetConnection()))
            {
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);

                db.OpenConnection();
                int result = Convert.ToInt32(cmd.ExecuteScalar());
                db.CloseConnection();

                return result > 0;
            }
        }
    }
}
