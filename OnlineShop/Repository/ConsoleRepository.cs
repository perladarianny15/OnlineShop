using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace OnlineShop.Repository
{
    public class ConsoleRepository
    {
        public string connectionString = ConfigurationManager.ConnectionStrings["OnlineStoreDB"].ConnectionString;
        public List<Models.Console> ConsoleList()
        {

            var Lista = new List<Models.Console>();

            string query = "select * from  Online_Store.dbo.tblConsole";

            using (var db = new SqlConnection(connectionString))

            {

                var SentenciaAEjecutar = new SqlCommand(query, db);

                // abrimos connection

                db.Open();

                var reader = SentenciaAEjecutar.ExecuteReader();

                while (reader.Read())

                {

                    var item = new Models.Console();

                    item.ConsoleID = Int32.Parse(reader[0].ToString());

                    item.ConsoleModel = reader[1].ToString();

                    Lista.Add(item);

                }
                db.Close();

                return Lista;

            }

        }

        public void RegisterConsole(Models.Console console)
        {
            string query1 = "insert into Online_Store.dbo.tblConsole values( '" + console.ConsoleModel + "' , '" + console.ConsoleState + "', '" + console.ConsoleDetail + "')";

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