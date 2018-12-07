using Project0.Interface.View.Customers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project0.Interface.View.Menu
{
    public class CustomerMenu
    {
        /// <summary>
        /// Show Customer Main Menu
        /// </summary>
        public static void ShowCustomersMenu()
        {
            string menuOption = new string("");
            string menu = "Customers\n\n" +
                            "1 - New\n" +
                            "2 - Show All\n" +
                            "3 - Find\n" +
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
                        CustomerForm.ShowForm();
                        break;
                    case "2":
                        ClearHelper.Clear();
                        ShowAll.Show();
                        Console.WriteLine();
                        Console.ReadKey();
                        ClearHelper.Clear();
                        break;
                    case "3":
                        ClearHelper.Clear();
                        Console.WriteLine("Find Customer!");
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
