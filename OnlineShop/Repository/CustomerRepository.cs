using OnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace OnlineShop.Repository
{
    public class CustomerRepository
    {
        public string connectionString = ConfigurationManager.ConnectionStrings["OnlineStoreDB"].ConnectionString;
        public void RegisterCustomer(Customer customer)
        {
            string query1 = "insert into Online_Store.dbo.tblCusomer values( '" + customer.FirstName + "' , '" + customer.LastName + "', '" + customer.Address + "', '" + customer.Email + "')";

            using (var db = new SqlConnection(connectionString))
            {

                var SentenciaAEjecutar = new SqlCommand(query1, db);

                // abrimos connection

                db.Open();

                var ex = SentenciaAEjecutar.ExecuteNonQuery();
                db.Close();

            }
        }
        public List<Customer> CustomerList()
        {
            var Lista = new List<Customer>();

            string query = "select * from  Online_Store.dbo.tblCusomer";

            using (var db = new SqlConnection(connectionString))
            {
                var SentenciaAEjecutar = new SqlCommand(query, db);

                // abrimos connection

                db.Open();

                var reader = SentenciaAEjecutar.ExecuteReader();

                while (reader.Read())
                {

                    var customer = new Customer();

                    customer.CustomerId = Int32.Parse(reader[0].ToString());

                    customer.FirstName = reader[1].ToString();

                    customer.LastName = reader[2].ToString();

                    customer.Address = reader[3].ToString();

                    customer.Email = reader[3].ToString();

                    Lista.Add(customer);

                }
                db.Close();

                return Lista;
            }
        }
    }
}