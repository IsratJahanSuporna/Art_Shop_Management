using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Art_Shop_Management.Models
{
    public class Product
    {
        public int ProductId { get; set; }        // Auto-increment (DB)
        public string Product_Name { get; set; }
        public decimal Product_Price { get; set; }
        public int Product_Quantity { get; set; }

        // 1️⃣ Default constructor (required)
        public Product()
        {
        }

        // 2️⃣ Constructor without ProductId (for INSERT)
        public Product(string productName, decimal productPrice, int productQuantity)
        {
            Product_Name = productName;
            Product_Price = productPrice;
            Product_Quantity = productQuantity;
        }

        // 3️⃣ Constructor with ProductId (for READ / UPDATE)
        public Product(int productId, string productName, decimal productPrice, int productQuantity)
        {
            ProductId = productId;
            Product_Name = productName;
            Product_Price = productPrice;
            Product_Quantity = productQuantity;
        }
    }
}


