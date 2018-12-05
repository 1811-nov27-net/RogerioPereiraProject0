using Project0.Library.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project0.Interface.View.Costumers
{
    class CostumerForm
    {
        public static void ShowForm()
        {
            Costumer costumer = new Costumer();

            Console.Write("Cosutmer First Name:\n");
            costumer.FirstName = Console.ReadLine();

            Console.Write("Cosutmer Last Name:\n");
            costumer.LastName = Console.ReadLine();

            Console.Write("Address Line 1:\n");
            costumer.Address.Address1 = Console.ReadLine();

            Console.Write("Address Line 2:\n");
            costumer.Address.Address2 = Console.ReadLine();

            Console.Write("City:\n");
            costumer.Address.City = Console.ReadLine();

            Console.Write("State:\n");
            costumer.Address.State = Console.ReadLine();

            Console.Write("ZipCode:\n");
            costumer.Address.ZipCode = Int32.Parse(Console.ReadLine());
        }
    }
}
