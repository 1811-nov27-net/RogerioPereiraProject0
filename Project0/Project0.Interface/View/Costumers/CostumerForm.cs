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

            Console.Write("Street:\n");
            costumer.Address.Street = Console.ReadLine();

            Console.Write("City:\n");
            costumer.Address.City = Console.ReadLine();

            Console.Write("State:\n");
            costumer.Address.State = Console.ReadLine();

            Console.Write("ZipCode:\n");
            costumer.Address.ZipCode = Int32.Parse(Console.ReadLine());
        }
    }
}
