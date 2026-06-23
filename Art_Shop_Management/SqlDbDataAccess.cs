using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Art_shop_management_system
{
    internal class SqlDbDataAccess
    {
        private const string connectionString = @" Data Source = SUPORNA\SQLEXPRESS;Initial Catalog = Art_Shop; Integrated Security = True; Trust Server Certificate=True";
       
        public SqlCommand GetQuery(string query)
        {
            var connection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(query, connection);

            return cmd;
        }

    }
}

