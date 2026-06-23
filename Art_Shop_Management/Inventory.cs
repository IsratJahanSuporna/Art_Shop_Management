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
    public partial class Inventory : Form
    {
        public Inventory()
        {
            InitializeComponent();
        }
        private void ClearFields()
        {
            txtProductName.Clear();
            txtPrice.Clear();
            txtQuantity.Clear();
        }
        private void UpdateProduct(int productId, string name, decimal price, int quantity)
        {
            string connectionString = @"Data Source = SUPORNA\SQLEXPRESS;Initial Catalog = Art_Shop; Integrated Security = True; TrustServerCertificate=True";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    string query = @"UPDATE Products
                             SET Product_Name = @Name,
                                 Product_Price = @Price,
                                 Product_Quantity = @Quantity
                             WHERE ProductId = @ProductId";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@Price", price);
                    cmd.Parameters.AddWithValue("@Quantity", quantity);
                    cmd.Parameters.AddWithValue("@ProductId", productId);

                    conn.Open();
                    int rows = cmd.ExecuteNonQuery();

                    if (rows > 0)
                        MessageBox.Show("Product updated successfully.");
                    else
                        MessageBox.Show("Product ID not found.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Update failed: " + ex.Message);
                }
            }
        }

        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = guna2DataGridView1.Rows[e.RowIndex];
                txtSearchId.Text = row.Cells["ProductId"].Value.ToString();
                txtProductName.Text = row.Cells["Product_Name"].Value.ToString();
                txtPrice.Text = row.Cells["Product_Price"].Value.ToString();
                txtQuantity.Text = row.Cells["Product_Quantity"].Value.ToString();
            }
        }

        private void LoadProducts()
        {
            string connectionString = @"Data Source = SUPORNA\SQLEXPRESS;Initial Catalog = Art_Shop; Integrated Security = True; TrustServerCertificate=True";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"SELECT ProductId, Product_Name, Product_Price, Product_Quantity FROM Products";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                guna2DataGridView1.AutoGenerateColumns = true;
                guna2DataGridView1.DataSource = dt;

                // Optional: rename headers
                guna2DataGridView1.Columns["ProductId"].HeaderText = "Product ID";
                guna2DataGridView1.Columns["Product_Name"].HeaderText = "Name";
                guna2DataGridView1.Columns["Product_Price"].HeaderText = "Price";
                guna2DataGridView1.Columns["Product_Quantity"].HeaderText = "Quantity";

                // Optional: hide ProductId if not needed
                // guna2DataGridView1.Columns["ProductId"].Visible = false;
            }
        }


        private void lblPrice_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (guna2DataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a product to delete.");
                return;
            }

            int productId = Convert.ToInt32(
                guna2DataGridView1.SelectedRows[0].Cells["ProductId"].Value);

            if (MessageBox.Show("Delete selected product and all related orders?",
                "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                string connectionString =
                @"Data Source=SUPORNA\SQLEXPRESS;Initial Catalog=Art_Shop;Integrated Security=True;TrustServerCertificate=True";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlTransaction transaction = conn.BeginTransaction();

                    try
                    {
                        // 1️⃣ Delete related orders
                        SqlCommand cmdOrders = new SqlCommand(
                            "DELETE FROM Orders WHERE ProductID = @ProductId", conn, transaction);
                        cmdOrders.Parameters.AddWithValue("@ProductId", productId);
                        cmdOrders.ExecuteNonQuery();

                        // 2️⃣ Delete the product
                        SqlCommand cmdProduct = new SqlCommand(
                            "DELETE FROM Products WHERE ProductId = @ProductId", conn, transaction);
                        cmdProduct.Parameters.AddWithValue("@ProductId", productId);
                        cmdProduct.ExecuteNonQuery();

                        transaction.Commit();
                        LoadProducts();
                        MessageBox.Show("Product and all related orders deleted successfully.");
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show("Error deleting product: " + ex.Message);
                    }
                }
            }
        }




        private void guna2Button3_Click(object sender, EventArgs e)
        {
          
            if (!int.TryParse(txtSearchId.Text.Trim(), out int productId))
            {
                MessageBox.Show("Please enter a valid Product ID.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtProductName.Text) ||
                string.IsNullOrWhiteSpace(txtPrice.Text) ||
                string.IsNullOrWhiteSpace(txtQuantity.Text))
            {
                MessageBox.Show("Please fill all fields.");
                return;
            }

            UpdateProduct(productId, txtProductName.Text.Trim(),
                          decimal.Parse(txtPrice.Text.Trim()),
                          int.Parse(txtQuantity.Text.Trim()));

            LoadProducts();
        }

        

        private void Inventory_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            LoadProducts();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
        
            if (string.IsNullOrWhiteSpace(txtProductName.Text) ||
                string.IsNullOrWhiteSpace(txtPrice.Text) ||
                string.IsNullOrWhiteSpace(txtQuantity.Text))
            {
                MessageBox.Show("Please fill all fields.");
                return;
            }
            string connectionString = @"Data Source = SUPORNA\SQLEXPRESS;Initial Catalog = Art_Shop; Integrated Security = True; TrustServerCertificate=True";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"INSERT INTO Products (Product_Name, Product_Price, Product_Quantity)
                         VALUES (@Name, @Price, @Quantity)";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Name", txtProductName.Text.Trim());
                cmd.Parameters.AddWithValue("@Price", decimal.Parse(txtPrice.Text));
                cmd.Parameters.AddWithValue("@Quantity", int.Parse(txtQuantity.Text));

                conn.Open();
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Product added successfully.");
            LoadProducts();
            ClearFields();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
         
            if (!int.TryParse(txtSearchId.Text.Trim(), out int productId))
            {
                MessageBox.Show("Please enter a valid numeric Product ID.");
                return;
            }

            SearchProductById(productId);

    }
        private void SearchProductById(int productId)
        {
            string connectionString = @"Data Source = SUPORNA\SQLEXPRESS;Initial Catalog = Art_Shop; Integrated Security = True; TrustServerCertificate=True";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    string query = @"SELECT ProductId, Product_Name, Product_Price, Product_Quantity
                             FROM Products
                             WHERE ProductId = @ProductId";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ProductId", productId);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("No product found with this ID.");
                    }

                    guna2DataGridView1.DataSource = dt;
                    if (dt.Rows.Count > 0)
                    {
                        // Optionally fill fields for update
                        txtProductName.Text = dt.Rows[0]["Product_Name"].ToString();
                        txtPrice.Text = dt.Rows[0]["Product_Price"].ToString();
                        txtQuantity.Text = dt.Rows[0]["Product_Quantity"].ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Search error: " + ex.Message);
                }
            }
        }

    }
}

