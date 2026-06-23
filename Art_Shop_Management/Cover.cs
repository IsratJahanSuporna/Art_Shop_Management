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
    public partial class Cover : Form
    {
        public Cover()
        {
            InitializeComponent();
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Cover_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

            this.Hide();
            Login login = new Login();
            login.Show();
        }

        private void Cover_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
