using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Art_Shop_Management
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void password_TextChanged(object sender, EventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            
        }
        private void RegisterButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            Register register = new Register();
            register.Show();
        }

        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text; // your username textbox
            string password = txtPassword.Text; // your password textbox
            string connectionString= @"Data Source = SUPORNA\SQLEXPRESS;Initial Catalog = Art_Shop; Integrated Security = True; TrustServerCertificate=True";
            using (System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT UserID, UserName, UserType FROM Users WHERE UserName=@username AND HashPassword=@password";
                System.Data.SqlClient.SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password); // in real app, store hashed passwords!

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    string userType = reader["UserType"].ToString();
                    int userId = Convert.ToInt32(reader["UserID"]);

                    if (userType == "Customer")
                    {
                        // Optionally, get customer info from Customers table
                        CustomerDashboard dashboard = new CustomerDashboard(userId);
                        this.Hide();
                        dashboard.Show();
                    }

                    else if (userType == "Staff")
                    {
                        StaffDashboard dashboard = new StaffDashboard();
                        this.Hide();
                        dashboard.Show();
                    }
                    else if (userType == "Admin")
                    {
                        AdminDashboard dashboard = new AdminDashboard();
                        this.Hide();
                        dashboard.Show();
                    }
                    else
                    {
                        MessageBox.Show("Not a customer account.");
                    }
                }
                else
                {
                    MessageBox.Show("Invalid username or password.");
                }
                reader.Close();
            }
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
