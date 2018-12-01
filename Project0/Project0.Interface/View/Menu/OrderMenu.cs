using System;
using System.Collections.Generic;
using System.Text;

namespace Project0.Interface.View.Menu
{
    public class OrderMenu
    {
        /// <summary>
        /// Show Order Main Menu
        /// </summary>
        public static void ShowOrderMenu()
        {
            string menuOption = new string("");
            string menu = "Orders\n\n" +
                            "1 - New\n" +
                            "2 - Show All\n" +
                            "3 - Show All by Location\n" +
                            "4 - Show All by Costumer\n" +
                            "5 - Find\n" +
                            "b - Back\n" +
                            "Option: ";
            do
            {
                Console.Write(menu);
                menuOption = Console.ReadLine();

                switch (menuOption)
                {
                    case "1":
                        ClearHelper.Clear();
                        Console.WriteLine("New Order!");
                        Console.ReadKey();
                        ClearHelper.Clear();
                        break;
                    case "2":
                        ClearHelper.Clear();
                        Console.WriteLine("Show All Orders!");
                        Console.ReadKey();
                        ClearHelper.Clear();
                        break;
                    case "3":
                        ClearHelper.Clear();
                        Console.WriteLine("Show All Orders by Location!");
                        Console.ReadKey();
                        ClearHelper.Clear();
                        break;
                    case "4":
                        ClearHelper.Clear();
                        Console.WriteLine("Show All Orders by Costumer!");
                        Console.ReadKey();
                        ClearHelper.Clear();
                        break;
                    case "5":
                        ClearHelper.Clear();
                        Console.WriteLine("Find Order!");
                        Console.ReadKey();
                        ClearHelper.Clear();
                        break;
                    case "b":
                        ClearHelper.Clear();
                        break;
                    default:
                        Console.WriteLine("Wrong option!");
                        Console.ReadKey();
                        ClearHelper.Clear();
                        break;
                }
            } while (menuOption != "b");
        }
    }
}
