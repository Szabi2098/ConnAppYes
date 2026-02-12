using ConnAppYes.Models;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;
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

        public bool NewConn(Conn conn)
        {
            MySqlConnection con = new MySqlConnection("server=localhost;user=root;password=;database=connappyes;");
            con.Open();
            string insertSql = "INSERT INTO connappyes VALUES (@Id,@Nev,@Cim,@Email,@Telefon)";
            MySqlCommand insertcmd = new MySqlCommand(insertSql, con);
            insertcmd.Parameters.AddWithValue("@Id", null);
            insertcmd.Parameters.AddWithValue("@Nev", conn.Nev);
            insertcmd.Parameters.AddWithValue("@Cim", conn.Cim);
            insertcmd.Parameters.AddWithValue("@Email", conn.Email);
            insertcmd.Parameters.AddWithValue("@Telefon", conn.Telefon);


            int sorok = insertcmd.ExecuteNonQuery();
            bool valasz = sorok > 0 ? true : false;
            return valasz;
        }

        public bool UpdConn(int id, string nev, string cim, string email, string telefon)
        {
            MySqlConnection con = new MySqlConnection("server=localhost;user=root;password=;database=connappyes;");
            con.Open();
            string insertSql = "UPDATE connappyes SET `Nev`= @Nev,`Cim`= @Cim,`Email`= @Email,`Telefon`= @Telefon WHERE Id = @Id;";
            MySqlCommand insertcmd = new MySqlCommand(insertSql, con);
            insertcmd.Parameters.AddWithValue("@Id", id);
            insertcmd.Parameters.AddWithValue("@Nev", nev);
            insertcmd.Parameters.AddWithValue("@Cim", cim);
            insertcmd.Parameters.AddWithValue("@Email", email);
            insertcmd.Parameters.AddWithValue("@Telefon", telefon);


            int sorok = insertcmd.ExecuteNonQuery();
            bool valasz = sorok > 0 ? true : false;
            return valasz;
            
        }

        public bool DelConn(int id) 
        {
            MySqlConnection con = new MySqlConnection("server=localhost;user=root;password=;database=connappyes;");
            con.Open();
            string insertSql = "DELETE FROM `connappyes` WHERE Id = @Id";
            MySqlCommand insertcmd = new MySqlCommand(insertSql, con);
            insertcmd.Parameters.AddWithValue("@Id", id);


            int sorok = insertcmd.ExecuteNonQuery();
            bool valasz = sorok > 0 ? true : false;
            return valasz;
            
        }

    }
}
