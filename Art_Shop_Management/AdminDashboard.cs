using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Art_Shop_Management
{
    public partial class AdminDashboard : Form
    {
        public AdminDashboard()
        {
            InitializeComponent();
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.Show();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Users login = new Users();
            login.Show();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Inventory inventory = new Inventory();
            inventory.Show();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Order order = new Order(); 
            order.Show();
        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            UpdatePassword updatePassword = new UpdatePassword();
            updatePassword.Show();
        }

        private void guna2Button10_Click(object sender, EventArgs e)
        {
            this.Hide();
            Delete delete = new Delete();       
            delete.Show();
        }

        private void guna2Button9_Click(object sender, EventArgs e)
        {
            this.Hide();
            UpdateInfo updateInfo = new UpdateInfo();   
            updateInfo.Show();
        }
    }
}
