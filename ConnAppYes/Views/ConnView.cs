using ConnAppYes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnAppYes.Views
{
    internal class ConnView
    {
        public void ShowConnList(List<Conn> conns)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("┌──────┬─────────────────────────┬──────────────────────────────────────────┬──────────────────────┬─────────────────────┐");
            Console.WriteLine("│  Id  │           Név           │                    Cím                   │        E-mail        │       Telefon       │");
            Console.WriteLine("│      │                         │                                          │                      │                     │");
            Console.WriteLine("├──────┼─────────────────────────┼──────────────────────────────────────────┼──────────────────────┼─────────────────────┼");

            bool first = true;
            foreach (var conn in conns)
            {
                if (!first)
                {
                    Console.WriteLine("├──────┼─────────────────────────┼──────────────────────────────────────────┼──────────────────────┼─────────────────────┼");
                }

                Console.WriteLine($"│{conn.Id,-6}│{conn.Nev,-25}│{conn.Cim,-42}│{conn.Email,-22}│{conn.Telefon,-21}│");
                first = false;
            }

            Console.WriteLine("└──────┴─────────────────────────┴──────────────────────────────────────────┴──────────────────────┴─────────────────────┘");


        }
    }
}
