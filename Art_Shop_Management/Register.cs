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
using System.Data.SqlClient;

namespace Art_Shop_Management
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

       




private void btnRegister_Click(object sender, EventArgs e)
    {
        // 1️⃣ Read values from TextBoxes
        string username = txtUsername.Text.Trim();
        string password = txtPassword.Text.Trim();  // TODO: hash password in production
        string contact = txtContactInfo.Text.Trim();
        string email = txtEmail.Text.Trim();
        string dob = txtDOB.Text.Trim();            // stored as NVARCHAR(50)
        string gender = txtGender.Text.Trim();
        string address = txtAddress.Text.Trim();
        string customerName = txtUsername.Text.Trim();

        // Optional: validate inputs
        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(customerName))
        {
            MessageBox.Show("Please fill all required fields.");
            return;
        }

        int membershipTier = 1; // default
        int totalSpending = 0;  // default

        // 2️⃣ Connect to database
        string connectionString = @"Data Source = SUPORNA\SQLEXPRESS;Initial Catalog = Art_Shop; Integrated Security = True; TrustServerCertificate=True";

        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            try
            {
                conn.Open();

                // 3️⃣ Insert into Users table and get new UserID
                string queryUser = @"
                INSERT INTO Users (UserName, [HashPassword], ContactInfo, Email, DOB, Gender, Address, UserType)
                VALUES (@Username, @Password, @Contact, @Email, @DOB, @Gender, @Address, 'Customer');
                SELECT CAST(SCOPE_IDENTITY() AS INT);";

                SqlCommand cmdUser = new SqlCommand(queryUser, conn);
                cmdUser.Parameters.AddWithValue("@Username", username);
                cmdUser.Parameters.AddWithValue("@Password", password);
                cmdUser.Parameters.AddWithValue("@Contact", contact);
                cmdUser.Parameters.AddWithValue("@Email", email);
                cmdUser.Parameters.AddWithValue("@DOB", dob);       // as string
                cmdUser.Parameters.AddWithValue("@Gender", gender);
                cmdUser.Parameters.AddWithValue("@Address", address);

                int newUserId = (int)cmdUser.ExecuteScalar(); // get new UserID

                if (newUserId > 0)
                {
                    // 4️⃣ Insert into Customers table
                    string queryCustomer = @"
                    INSERT INTO Customers ( UserID,CustomerName, MembershipTier, TotalSpending)
                    VALUES (@UserID,@CustomerName, @MembershipTier, @TotalSpending)";

                    SqlCommand cmdCustomer = new SqlCommand(queryCustomer, conn);
                    cmdCustomer.Parameters.AddWithValue("@UserID", newUserId);
                    cmdCustomer.Parameters.AddWithValue("@CustomerName", customerName);
                    cmdCustomer.Parameters.AddWithValue("@MembershipTier", membershipTier);  // int
                    cmdCustomer.Parameters.AddWithValue("@TotalSpending", totalSpending);    // int

                    cmdCustomer.ExecuteNonQuery();

                    MessageBox.Show("Registration successful! You can now log in.");
                    this.Hide();
                    Login loginForm = new Login();
                    loginForm.Show();
                }
                else
                {
                    MessageBox.Show("Registration failed. Please try again.");
                }
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show("SQL Error: " + sqlEx.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }




    private void guna2TextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void Register_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
