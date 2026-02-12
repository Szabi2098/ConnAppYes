using ConnAppYes.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnAppYes.Controllers
{
    internal class ConnController
    {
        public List<Conn> GetConnList()
        {
            MySqlConnection conn = new MySqlConnection("server=localhost;user=root;password=;database=connappyes;");
            conn.Open();
            string comd = "SELECT * FROM connappyes;";
            MySqlCommand cmd = new MySqlCommand(comd, conn);
            List<Conn> connections = new List<Conn>();
            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    connections.Add(new Conn(
                        reader.GetInt32("id"),
                        reader.GetString("nev"),
                        reader.GetString("cim"),
                        reader.GetString("telefon"),
                        reader.GetString("email")
                    ));
                }

                conn.Close();
                return connections;
            }
        }
    }
}
