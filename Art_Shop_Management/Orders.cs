using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Art_Shop_Management.Models
{
    public class Orders
    {
        public int OrderID { get; set; }       // Identity / auto-increment
        public int CustomerID { get; set; }
        public int ProductID { get; set; }
        public decimal Total_Price { get; set; }
        public int Quantity { get; set; }
        public bool IsConfirmed { get; set; }

        // 1️⃣ Default constructor
        public Orders()
        {
        }

        // 2️⃣ Constructor without OrderID (for inserting new orders)
        public Orders(int customerID, int productID, decimal totalPrice, int quantity, bool isConfirmed = false)
        {
            CustomerID = customerID;
            ProductID = productID;
            Total_Price = totalPrice;
            Quantity = quantity;
            IsConfirmed = isConfirmed;
        }

        // 3️⃣ Constructor with OrderID (for reading from database)
        public Orders(int orderID, int customerID, int productID, decimal totalPrice, int quantity, bool isConfirmed)
        {
            OrderID = orderID;
            CustomerID = customerID;
            ProductID = productID;
            Total_Price = totalPrice;
            Quantity = quantity;
            IsConfirmed = isConfirmed;
        }
    }
}

