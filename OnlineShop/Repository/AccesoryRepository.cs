using OnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace OnlineShop.Repository
{
    public class AccesoryRepository
    {
        public string connectionString = ConfigurationManager.ConnectionStrings["OnlineStoreDB"].ConnectionString;
        public void RegisterAccesory(Accesory accessory)
        {

            string query1 = "insert into Online_Store.dbo.tblAccessories values( '" + accessory.AccessoryName + "' , '" + accessory.AccessoryDetail + "')";

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