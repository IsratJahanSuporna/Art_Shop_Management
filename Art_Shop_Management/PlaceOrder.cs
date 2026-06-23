using Art_Shop_Management.Models;
using Art_shop_management_system;
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
    public partial class PlaceOrder : Form
    {
        private int userId;
        public PlaceOrder(int userId)
        {
            InitializeComponent();
            this.userId = userId;
        }
        private int GetCustomerId(int userId)
        {
            int customerId = 0;
            string connectionString = @"Data Source=SUPORNA\SQLEXPRESS;Initial Catalog=Art_Shop; Integrated Security=True; TrustServerCertificate=True";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT CustomerID FROM Customers WHERE UserID=@userId";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@userId", userId);
                    conn.Open();
                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        customerId = Convert.ToInt32(result);
                    }
                    else
                    {
                        throw new Exception("Customer not found for this user.");
                    }
                }
            }

            return customerId;
        }

        private void LoadProducts()
        {
            string connectionString = @"Data Source = SUPORNA\SQLEXPRESS;Initial Catalog = Art_Shop; Integrated Security = True; TrustServerCertificate=True";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT ProductId, Product_Name, Product_Price, Product_Quantity FROM Products";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                guna2DataGridView1.AutoGenerateColumns = true;
                guna2DataGridView1.DataSource = dt;

                // Rename headers
                guna2DataGridView1.Columns["ProductId"].HeaderText = "ID";
                guna2DataGridView1.Columns["Product_Name"].HeaderText = "Name";
                guna2DataGridView1.Columns["Product_Price"].HeaderText = "Price";
                guna2DataGridView1.Columns["Product_Quantity"].HeaderText = "Stock";
            }
        }
        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            if (decimal.TryParse(txtPrice.Text, out decimal price) &&
                int.TryParse(txtQuantity.Text, out int quantity))
            {
                decimal total = price * quantity;
                txtTotalPrice.Text = total.ToString("F2"); // Format as currency
            }
            else
            {
                txtTotalPrice.Text = "0.00";
            }
        }
      

        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Check to make sure the click is not on the header row
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = guna2DataGridView1.Rows[e.RowIndex];

                // Assuming your columns are named exactly like this:
                string productName = selectedRow.Cells["Product_Name"].Value?.ToString();
                string price = selectedRow.Cells["Product_Price"].Value?.ToString();

                // Assign values to textboxes
                txtProductName.Text = productName ?? "";
                txtPrice.Text = price ?? "";
            }
        }


        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {

        }

        private void PlaceOrder_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

            // Validate quantity
            if (!int.TryParse(txtQuantity.Text, out int quantity) || quantity <= 0)
            {
                MessageBox.Show("Enter a valid quantity.");
                return;
            }

            // Get selected product ID and price
            if (guna2DataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Please select a product.");
                return;
            }

            int productId = Convert.ToInt32(guna2DataGridView1.CurrentRow.Cells["ProductId"].Value);
            decimal price = Convert.ToDecimal(txtPrice.Text);
            decimal totalPrice = price * quantity;

            // Get customerId from userId
            int customerId = 0;
            string connectionString = @"Data Source=SUPORNA\SQLEXPRESS;Initial Catalog=Art_Shop; Integrated Security=True; TrustServerCertificate=True";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // 1️⃣ Get CustomerID from UserID
                string getCustomerQuery = "SELECT CustomerID FROM Customers WHERE UserID=@userId";
                using (SqlCommand cmd = new SqlCommand(getCustomerQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@userId", this.userId);
                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        customerId = Convert.ToInt32(result);
                    }
                    else
                    {
                        MessageBox.Show("Customer not found!");
                        return;
                    }
                }

                // 2️⃣ Insert directly into Orders table
                string insertQuery = "INSERT INTO Orders (CustomerID, ProductID, Total_Price, Quantity, IsConfirmed) " +
                                     "VALUES (@CustomerID, @ProductID, @TotalPrice, @Quantity, @IsConfirmed)";

                using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@CustomerID", customerId);
                    cmd.Parameters.AddWithValue("@ProductID", productId);
                    cmd.Parameters.AddWithValue("@TotalPrice", totalPrice);
                    cmd.Parameters.AddWithValue("@Quantity", quantity);
                    cmd.Parameters.AddWithValue("@IsConfirmed", true);

                    cmd.ExecuteNonQuery(); // ✅ This pushes the order directly into Orders table
                }
            }

            MessageBox.Show("Order placed successfully!");
        }



        

        private void guna2HtmlLabel3_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel2_Click(object sender, EventArgs e)
        {

        }

        private void txtSearchId_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel6_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click_1(object sender, EventArgs e)
        {
          
            // Parseriv price and quantity safely
            if (decimal.TryParse(txtPrice.Text, out decimal price) &&
                int.TryParse(txtQuantity.Text, out int quantity))
            {
                decimal totalPrice = price * quantity;

                // Show total price in the Total Amount textbox
                txtTotalPrice.Text = totalPrice.ToString("F2"); // 2 decimal places

                // Optionally, show a message box
                MessageBox.Show($"Total price is: {totalPrice:C}", "Total Price");
            }
            else
            {
                MessageBox.Show("Please enter valid numbers for Price and Quantity.", "Input Error");
            }
        }

        

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            this.Hide();   
           CustomerDashboard customerDashboard = new CustomerDashboard(userId);   
            customerDashboard.Show();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            LoadProducts();
        }
    }
}
