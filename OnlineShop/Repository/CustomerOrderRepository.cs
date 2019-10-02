using OnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace OnlineShop.Repository
{
    public class CustomerOrderRepository
    {
        public string connectionString = ConfigurationManager.ConnectionStrings["OnlineStoreDB"].ConnectionString;
        public void RegisterCustomerOrder(CustomerOrder customerOrder)
        {

            string query1 = "insert into Online_Store.dbo.tblCustomer_Orders values( '" + customerOrder.OrderDate + "' , '" + customerOrder.OrderStatus + "', '" + customerOrder.Product_id + "', '" + customerOrder.CustomerID + "')";

            using (var db = new SqlConnection(connectionString))
            {
                var SentenciaAEjecutar = new SqlCommand(query1, db);

                // abrimos connection

                db.Open();

                var ex = SentenciaAEjecutar.ExecuteNonQuery();

                db.Close();
            }

        }
        public List<CustomerOrder> CustomerList()
        {
            var Lista = new List<CustomerOrder>();

            string query = "select * from  Online_Store.dbo.tblCustomer_Orders";

            using (var db = new SqlConnection(connectionString))
            {
                var SentenciaAEjecutar = new SqlCommand(query, db);

                // abrimos connection

                db.Open();

                var reader = SentenciaAEjecutar.ExecuteReader();

                while (reader.Read())
                {

                    var customer = new CustomerOrder();

                    customer.OrderID = Int32.Parse(reader[0].ToString());

                    customer.OrderDate = reader[1].ToString();

                    customer.OrderStatus = reader[2].ToString();

                    customer.Product_id = Int32.Parse(reader[3].ToString());

                    customer.CustomerID = Int32.Parse(reader[3].ToString());

                    Lista.Add(customer);

                }
                db.Close();

                return Lista;
            }
        }
        public void DeleteOrder(int id)
        {
            string query1 = "delete from Online_Store.dbo.tblCustomer_Orders where OrderID =" + id;

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