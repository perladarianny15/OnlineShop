using OnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace OnlineShop.Repository
{
    public class GameRepository
    {
        public string connectionString = ConfigurationManager.ConnectionStrings["OnlineStoreDB"].ConnectionString;
        public List<Game> ListGames()
        {
            var Lista = new List<Game>();

            string query = "select * from  Online_Store.dbo.tblGames";

            using (var db = new SqlConnection(connectionString))
            {

                var SentenciaAEjecutar = new SqlCommand(query, db);

                // abrimos connection

                db.Open();

                var reader = SentenciaAEjecutar.ExecuteReader();

                while (reader.Read())
                {

                    var game = new Game();

                    game.GameID = Int32.Parse(reader[0].ToString());

                    game.GameTittle = reader[1].ToString();

                    game.GameCategory = reader[2].ToString();

                    game.GameDetail = reader[3].ToString();

                    Lista.Add(game);

                }

                db.Close();
                return Lista;

            }

        }

        public void RegisterGame(Game gameClass)
        {
            string query1 = "insert into Online_Store.dbo.tblGames values( '" + gameClass.GameTittle + "' , '" + gameClass.GameCategory + "', '" + gameClass.GameDetail + "','" + 1 + "', '" + 1 + "')";

            using (var db = new SqlConnection(connectionString))
            {

                var SentenciaAEjecutar = new SqlCommand(query1, db);

                // abrimos connection

                db.Open();

                SentenciaAEjecutar.ExecuteNonQuery();

                db.Close();
            }
        }
        public void DeleteGame(int id)
        {
            string query1 = "delete from Online_Store.dbo.tblGames where GAMEID =" + id;

            using (var db = new SqlConnection(connectionString))
            {
                var SentenciaAEjecutar = new SqlCommand(query1, db);

                // abrimos connection

                db.Open();

                var ex = SentenciaAEjecutar.ExecuteNonQuery();
                db.Close();

            }
        }
        public void FindGameByID(int id)
        {
            string query1 = "select * from Online_Store.dbo.tblGames where GAMEID =" + id;

            using (var db = new SqlConnection(connectionString))
            {
                var SentenciaAEjecutar = new SqlCommand(query1, db);

                // abrimos connection

                db.Open();

                var ex = SentenciaAEjecutar.ExecuteNonQuery();
                db.Close();

            }
        }
        public void UpdateGameByID(int id, Game gameClass)
        {
            string query1 = "UPDATE Online_Store.dbo.tblGames SET GameTittle = '" + gameClass.GameTittle + "', GameCategory = '" + gameClass.GameCategory + "', GameDetail = '" + gameClass.GameDetail + "', ConsoleID = " + 1 + ", Product_id = " + 1 
            + " WHERE GAMEID = " + id;

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
