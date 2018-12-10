using Project0.Interface.View.Menu;
using Project0.Library.Control.Model;
using System;
using System.Collections.Generic;
using System.Text;
using PizzasDataAcess = Project0.DataAccess.Pizzas;

namespace Project0.Interface.View.Pizzas
{
    public class PizzaForm
    {
        public static void ShowForm()
        {
            PizzasDataAcess Pizza = new PizzasDataAcess();

            Console.Write("Pizzae Name:\n");
            Pizza.Name = Console.ReadLine();

            Console.Write("Pizza Price:\n");
            Pizza.Price = Decimal.Parse(Console.ReadLine());

            PizzaController controller = new PizzaController();
            controller.Save(Pizza);

            Console.WriteLine("\nPizza saved!\n");
            Console.ReadKey();
            ClearHelper.Clear();
        }
    }
}
