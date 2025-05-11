using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using OOP_Project.DL;

namespace OOP_Project
{
    public partial class SignUp : Form
    {
        private DBConnection db = DBConnection.GetInstance();
        public SignUp()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string email = textBox3.Text;
            string password = textBox2.Text;

            if (RegisterUser(username, email, password))
            {
                MessageBox.Show("Registration successful!", "Sign Up", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                Login login = new Login();
                login.Show();
            }
            else
            {
                MessageBox.Show("Registration failed. Please try again.", "Sign Up Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool RegisterUser(string username, string email, string password)
        {
            string query = "INSERT INTO Users (Username, Email, Password) VALUES (@username, @Email, @password)";

            try
            {
                using (MySqlCommand cmd = new MySqlCommand(query, db.GetConnection()))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@password", password);

                    db.OpenConnection();
                    int result = cmd.ExecuteNonQuery();
                    db.CloseConnection();

                    return result > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Database Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
