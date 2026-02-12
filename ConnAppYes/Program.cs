using ConnAppYes.Controllers; 
using ConnAppYes.Models; 
using ConnAppYes.Views;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnAppYes
{
    internal class Program
    {
        static void Main()
        {
            Console.SetWindowSize(125, 30);
            Console.SetBufferSize(125, 30);
            Console.Clear();

            List<Conn> connections = new ConnController().GetConnList();
            new ConnView().ShowConnList(connections);

            Console.ReadLine();
        }

        static void NewConn() 
        {
            //while (true)
            //{
            //    if (Console.KeyAvailable) 
            //    { 
            //        ConsoleKeyInfo key = Console.ReadKey(true); 
            //        if (key.Key == ConsoleKey.Escape) 
            //        { 
            //            Main(); 
            //        } 
            //    }
            //}

            Console.WriteLine("Név: ");
            string nev = Console.ReadLine();

            Console.WriteLine("Cím: ");
            string cim = Console.ReadLine();

            Console.WriteLine("E-mail: ");
            string email = Console.ReadLine();

            Console.WriteLine("Telefonszám: ");
            string telefon = Console.ReadLine();

            Conn newConn = new Conn(
                id: 1,
                nev: nev,
                cim: cim, 
                email: email, 
                telefon: telefon
            );
            
            if(new ConnController().NewConn(newConn)) 
            { 
                Console.WriteLine("Sikeres mentés!"); 
            } 
            else 
            { 
                Console.WriteLine("Sikertelen mentés!"); 
            }
            Console.ReadLine();
            Main();
        }

        static void UpdConn() 
        {
            #region Jelenlegi adatok
            MySqlConnection conn = new MySqlConnection("server=localhost;user=root;password=;database=kockasfuzet;");

            conn.Open();

            // Módisítandó Kapcsolat ID-jának bekérése
            Console.WriteLine("\nAdd meg a módosítandó Kapcsolat ID-ját:");
            int id = int.Parse(Console.ReadLine());

            // Jelenlegi adatok lekérése az adatbázisból
            string selectSql = @"SELECT Nev, Cim, Email, Telefon FROM `connappyes` WHERE Id = @Id";
            MySqlCommand selectCmd = new MySqlCommand(selectSql, conn);
            selectCmd.Parameters.AddWithValue("@Id", id);

            MySqlDataReader reader = selectCmd.ExecuteReader();

            if (!reader.Read())
            {
                Console.WriteLine("Nincs ilyen Kapcsolat!");
                reader.Close();
                conn.Close();
                Console.ReadLine();
                UpdConn();
            }

            // Jelenlegi adatok elmentése változókba
            string currNev = reader.GetString("Nev");
            string currCim = reader.GetString("Cim");
            string currEmail = reader.GetString("Email");
            string currTelefon = reader.GetString("Telefon");

            reader.Close();
            #endregion

            // Módosítandó adatok bekérése
            Console.WriteLine("Enterrel jelenlegi adat megtartása\n");

            Console.WriteLine($"Új név: (Jel.: {currNev})");
            string nev = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(nev))
                nev = currNev;

            Console.WriteLine($"Új cím: (Jel.: {currCim})");
            string cim = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(cim))
                cim = currCim;

            Console.WriteLine($"Új E-mail: (Jel.: {currEmail})");
            string email = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(email))
                email = currEmail;

            Console.WriteLine($"Új név: (Jel.: {currTelefon})");
            string telefon = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(telefon))
                telefon = currTelefon;


            if (new ConnController().UpdConn(id, nev, cim, email, telefon))
            { 
                Console.WriteLine("Sikeres módosítás!"); 
            } 
            else 
            { 
                Console.WriteLine("Sikertelen módosítás!"); 
            } 
            Console.ReadLine();
            Main();
        }

        static void DelConn()
        {
            if (new ConnController().DelConn(id))
            { 
                Console.WriteLine("Sikeres törlés!"); 
            } 
            else 
            { 
                Console.WriteLine("Sikertelen törlés!"); 
            } 
            Console.ReadLine(); 
            Main();
        }

    }
}
