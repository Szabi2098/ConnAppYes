using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConnAppYes.Models; 
using ConnAppYes.Controllers; 
using ConnAppYes.Views;

namespace ConnAppYes
{
    internal class Program
    {
        static void Main()
        {
            List<Conn> connections = new ConnController().GetConnList();
            new ConnView().ShowConnList(connections);
        }
    }
}
