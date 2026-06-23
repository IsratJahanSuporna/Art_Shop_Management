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
    public partial class Order : Form
    {
        private void LoadOrders()
        {
            string connectionString = @"Data Source=SUPORNA\SQLEXPRESS;Initial Catalog=Art_Shop; Integrated Security=True; TrustServerCertificate=True";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"SELECT o.OrderID, c.CustomerName, p.Product_Name, o.Quantity, o.Total_Price, o.IsConfirmed
                         FROM Orders o
                         JOIN Customers c ON o.CustomerID = c.CustomerID
                         JOIN Products p ON o.ProductID = p.ProductId";

                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                guna2DataGridView1.DataSource = dt;

                // Optional: rename columns
                guna2DataGridView1.Columns["OrderID"].HeaderText = "Order ID";
                guna2DataGridView1.Columns["CustomerName"].HeaderText = "Customer";
                guna2DataGridView1.Columns["Product_Name"].HeaderText = "Product";
                guna2DataGridView1.Columns["Quantity"].HeaderText = "Qty";
                guna2DataGridView1.Columns["Total_Price"].HeaderText = "Total Price";
                guna2DataGridView1.Columns["IsConfirmed"].HeaderText = "Confirmed";
            }
        }

        public Order()
        {
            InitializeComponent();
        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {

        }

        private void cmbFilterStatus_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Order_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
         
            LoadOrders();
       

    }
}
}
