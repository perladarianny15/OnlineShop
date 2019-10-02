using OnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace OnlineShop.Repository
{
    public class ProductRepository
    {
        public string connectionString = ConfigurationManager.ConnectionStrings["OnlineStoreDB"].ConnectionString;
        public void RegisterProduct(Product product)
        {
            string query1 = "insert into Online_Store.dbo.tblProduct values( '" + product.ProducttName + "' , '" + product.ProductCategory + "', '" + product.ProductDescription + "','" + product.ProductPrice + "')";

            try
            {
                using (var db = new SqlConnection(connectionString))
                {

                    var SentenciaAEjecutar = new SqlCommand(query1, db);

                    // abrimos connection

                    db.Open();

                    var ex = SentenciaAEjecutar.ExecuteNonQuery();

                    db.Close();
                }


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public List<Product> ProductList()
        {
            var Lista = new List<Product>();

            string query = "select * from  Online_Store.dbo.tblProduct";

            using (var db = new SqlConnection(connectionString))
            {
                var SentenciaAEjecutar = new SqlCommand(query, db);

                // abrimos connection

                db.Open();

                var reader = SentenciaAEjecutar.ExecuteReader();

                while (reader.Read())
                {

                    var product = new Product();

                    product.ProductID = Int32.Parse(reader[0].ToString());

                    product.ProducttName = reader[1].ToString();

                    product.ProductCategory = reader[2].ToString();

                    product.ProductDescription = reader[3].ToString();

                    product.ProductPrice = Decimal.Parse(reader[4].ToString());

                    Lista.Add(product);

                }
                db.Close();

                return Lista;
            }
        }

        public int LastProductId()
        {

            var producto = 0;

            string query = "select top 1 * from  Online_Store.dbo.tblProduct order by Product_id desc";

            using (var db = new SqlConnection(connectionString))
            {

                var SentenciaAEjecutar = new SqlCommand(query, db);

                // abrimos connection

                db.Open();

                var reader = SentenciaAEjecutar.ExecuteReader();

                while (reader.Read())

                {

                    producto = Int32.Parse(reader[0].ToString());

                }
                db.Close();

                return producto;

            }

        }

        public void DeleteProduct(int id)
        {
            string query1 = "delete from Online_Store.dbo.tblProduct where Product_id =" + id;

            using (var db = new SqlConnection(connectionString))
            {
                var SentenciaAEjecutar = new SqlCommand(query1, db);

                // abrimos connection

                db.Open();

                var ex = SentenciaAEjecutar.ExecuteNonQuery();
                db.Close();

            }
        }
        public void FindProductByID(int id)
        {
            string query1 = "select * from Online_Store.dbo.tblProduct where Product_id =" + id;

            using (var db = new SqlConnection(connectionString))
            {
                var SentenciaAEjecutar = new SqlCommand(query1, db);

                // abrimos connection

                db.Open();

                var ex = SentenciaAEjecutar.ExecuteNonQuery();
                db.Close();

            }
        }
        public void UpdateProductByID(int id, Product product)
        {
            string query1 = "UPDATE Online_Store.dbo.tblProduct SET ProductName = '" + product.ProducttName + "', ProductCategory = '" + product.ProductCategory + "', ProductDescription = '" + product.ProductDescription + "', ProductPrice = " + product.ProductPrice 
            + " WHERE Product_id = " + id;

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