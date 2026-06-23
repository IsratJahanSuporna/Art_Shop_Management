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
    public partial class Users : Form
    {
        public Users()
        {
            InitializeComponent();
        }

        private void LoadUsers()
        {
            string connectionString = @"Data Source = SUPORNA\SQLEXPRESS;Initial Catalog = Art_Shop; Integrated Security = True; TrustServerCertificate=True";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    string query = @"SELECT 
                                UserID,
                                UserName,
                                Email,
                                ContactInfo,
                                Gender,
                                UserType
                             FROM Users";

                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    guna2DataGridView1.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading users: " + ex.Message);
                }
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Register register = new Register();
            register.Show();
        }

        private void Users_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void Users_Load(object sender, EventArgs e)
        {

        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
           
            if (!int.TryParse(txtSearchId.Text.Trim(), out int userId))
            {
                MessageBox.Show("Please enter a valid numeric User ID.");
                return;
            }

            SearchUserById(userId);
        }

        

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            LoadUsers();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
          
            if (guna2DataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a user to delete.");
                return;
            }

            int userId = Convert.ToInt32(
                guna2DataGridView1.SelectedRows[0].Cells["UserID"].Value);

            if (MessageBox.Show("Delete selected user?",
                "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                == DialogResult.Yes)
            {
                DeleteUser(userId);
                LoadUsers();
            
        }

        }

        private void DeleteUser(int userId)
        {
            string connectionString = @"Data Source=SUPORNA\SQLEXPRESS;Initial Catalog=Art_Shop; Integrated Security=True; TrustServerCertificate=True";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    // 1️⃣ Delete related orders first
                    SqlCommand cmdOrders = new SqlCommand(
                        @"DELETE FROM Orders 
                  WHERE CustomerID = (SELECT CustomerID FROM Customers WHERE UserID = @UserID)",
                        conn, transaction);
                    cmdOrders.Parameters.Add("@UserID", SqlDbType.Int).Value = userId;
                    cmdOrders.ExecuteNonQuery();

                    // 2️⃣ Delete from Customers
                    SqlCommand cmdCustomer = new SqlCommand(
                        "DELETE FROM Customers WHERE UserID = @UserID",
                        conn, transaction);
                    cmdCustomer.Parameters.Add("@UserID", SqlDbType.Int).Value = userId;
                    cmdCustomer.ExecuteNonQuery();

                    // 3️⃣ Delete from Users
                    SqlCommand cmdUser = new SqlCommand(
                        "DELETE FROM Users WHERE UserID = @UserID",
                        conn, transaction);
                    cmdUser.Parameters.Add("@UserID", SqlDbType.Int).Value = userId;
                    cmdUser.ExecuteNonQuery();

                    transaction.Commit();
                    MessageBox.Show("User and all related orders removed successfully.");
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Error removing user: " + ex.Message);
                }
            }
        }

        private void SearchUserById(int userId)
        {
            string connectionString = @"Data Source = SUPORNA\SQLEXPRESS;Initial Catalog = Art_Shop; Integrated Security = True; TrustServerCertificate=True";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    string query = @"
                SELECT 
                    UserID,
                    UserName,
                    Email,
                    ContactInfo,
                    Gender,
                    UserType
                FROM Users
                WHERE UserID = @UserID";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = userId;

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("No user found with this ID.");
                    }

                    guna2DataGridView1.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Search error: " + ex.Message);
                }
            }
        }


    }
}
