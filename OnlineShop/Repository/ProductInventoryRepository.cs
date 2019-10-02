using OnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace OnlineShop.Repository
{
    public class ProductInventoryRepository
    {
        public string connectionString = ConfigurationManager.ConnectionStrings["OnlineStoreDB"].ConnectionString;
        public void ProductInventory(ProductInventory productInventory)
        {
            string query1 = "insert into Online_Store.dbo.tblProductInventory values( '" + productInventory.ProductCount + "')";

            using (var db = new SqlConnection(connectionString))
            {
                var SentenciaAEjecutar = new SqlCommand(query1, db);

                // abrimos connection

                db.Open();

                var ex = SentenciaAEjecutar.ExecuteNonQuery();
                db.Close();

            }
        }

    }
}