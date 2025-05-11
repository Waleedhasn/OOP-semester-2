using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OOP_Project.UI.Customer;

namespace OOP_Project.UI
{
    public partial class CustomerDashboard : Form
    {
        public CustomerDashboard()
        {
            InitializeComponent();   
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Sidebartransition.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            customerProducts customerProducts = new customerProducts();
            panel1.Controls.Clear();
            panel1.Controls.Add(customerProducts);

        }
        bool sidebarExpand = true;
        private void Sidebartransition_Tick(object sender, EventArgs e)
        {
            if (sidebarExpand)
            {
                flowLayoutPanel1.Width -= 20;
                if (flowLayoutPanel1.Width <= 50)
                {
                    sidebarExpand = false;
                    Sidebartransition.Stop();
                }
            }
            else
            {
                flowLayoutPanel1.Width += 20;
                if (flowLayoutPanel1.Width >= 200)
                {
                    sidebarExpand = true;
                    Sidebartransition.Stop();
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            addReviews addReviews = new addReviews();
            panel1.Controls.Clear();
            panel1.Controls.Add(addReviews);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            checkout checkout = new checkout();
            panel1.Controls.Clear();
            panel1.Controls.Add(checkout);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            customerHome customerHome = new customerHome();
            panel1.Controls.Clear();
            panel1.Controls.Add(customerHome);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }
    }
}
