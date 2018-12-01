using System;
using System.Collections.Generic;
using System.Text;

namespace Project0.Interface.View.Menu
{
    class MainMenu
    {
        public static void ShowMainMenu()
        {
            string menuOption = new string("");
            string menu = "Pizza Manager\n\n" +
                            "1 - Costumers\n" +
                            "2 - Orders\n" +
                            "3 - Pizzas\n" +
                            "e - Exit\n" +
                            "Option: ";
            do
            {
                Console.Write(menu);
                menuOption = Console.ReadLine();

                switch (menuOption)
                {
                    case "1":
                        ClearHelper.Clear();
                        Console.WriteLine("Costumer!");
                        Console.ReadKey();
                        ClearHelper.Clear();
                        break;
                    case "2":
                        ClearHelper.Clear();
                        Console.WriteLine("Orders!");
                        Console.ReadKey();
                        ClearHelper.Clear();
                        break;
                    case "3":
                        ClearHelper.Clear();
                        Console.WriteLine("Pizzas!");
                        Console.ReadKey();
                        ClearHelper.Clear();
                        break;
                    case "e":
                        Console.WriteLine("Bye!");
                        Console.ReadKey();
                        break;
                    default:
                        Console.WriteLine("Wrong option!");
                        Console.ReadKey();
                        ClearHelper.Clear();
                        break;
                }
            } while (menuOption != "e");
        }
    }
}
