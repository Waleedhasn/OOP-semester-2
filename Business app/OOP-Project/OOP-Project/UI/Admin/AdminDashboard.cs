using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OOP_Project.UI.Admin;

namespace OOP_Project.UI
{
    public partial class AdminDashboard : Form
    {
        public AdminDashboard()
        {
            InitializeComponent();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            sidebartransition.Start();
        }

        bool sidebarExpand = true;
        private void sidebartransition_Tick(object sender, EventArgs e)
        {
            if (sidebarExpand)
            {
                flowLayoutPanel1.Width -= 20;
                if (flowLayoutPanel1.Width <= 50)
                {
                    sidebarExpand = false;
                    sidebartransition.Stop();
                }
            }
            else
            {
                flowLayoutPanel1.Width += 20;
                if (flowLayoutPanel1.Width >= 200)
                {
                    sidebarExpand = true;
                    sidebartransition.Stop();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            adminProducts adminProducts = new adminProducts();
            panel1.Controls.Clear();
            panel1.Controls.Add(adminProducts);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
