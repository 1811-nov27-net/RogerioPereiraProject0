using Project0.Interface.View.Address;
using Project0.Interface.View.Customers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project0.Interface.View.Menu
{
    public class AddressMenu
    {
        /// <summary>
        /// Show Address Main Menu
        /// </summary>
        public static void ShowAddressMenu()
        {
            string menuOption = new string("");
            string menu = "Adresses\n\n" +
                            "1 - New\n" +
                            "2 - Show all\n" +
                            "3 - Find\n" +
                            "4 - Update\n" +
                            "\nb - Back\n\n" +
                            "Option: ";
            do
            {
                Console.Write(menu);
                menuOption = Console.ReadLine();

                switch (menuOption)
                {
                    case "1":
                        ClearHelper.Clear();
                        AddressForm.ShowForm();
                        break;
                    case "2":
                        ClearHelper.Clear();
                        ShowAllWithAddress.Show();
                        Console.WriteLine();
                        Console.ReadKey();
                        ClearHelper.Clear();
                        break;
                    case "3":
                        ClearHelper.Clear();
                        Console.WriteLine("Find Address!");
                        Console.ReadKey();
                        ClearHelper.Clear();
                        break;
                    case "4":
                        ClearHelper.Clear();
                        Console.WriteLine("Update Address!");
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
