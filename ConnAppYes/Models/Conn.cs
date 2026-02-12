using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnAppYes.Models
{
    internal class Conn
    {
        private int id;
        private string nev;
        private string cim;
        private string telefon;
        private string email;

        public Conn(int id, string nev, string cim, string telefon, string email)
        {
            this.Id = id;
            this.Nev = nev;
            this.Cim = cim;
            this.Telefon = telefon;
            this.Email = email;
        }

        public int Id { get => id; set => id = value; }
        public string Nev { get => nev; set => nev = value; }
        public string Cim { get => cim; set => cim = value; }
        public string Telefon { get => telefon; set => telefon = value; }
        public string Email { get => email; set => email = value; }
    }
}
