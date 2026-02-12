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
            Console.SetWindowSize(125, 30);
            Console.SetBufferSize(125, 30);

            List<Conn> connections = new ConnController().GetConnList();
            new ConnView().ShowConnList(connections);

            Console.ReadLine();
        }

        static void NewConn() 
        {
            
        }

    }
}
