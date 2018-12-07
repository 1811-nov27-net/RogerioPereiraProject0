﻿using Microsoft.EntityFrameworkCore;
using Project0.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project0.Interface.View.Menu
{
    public class MainMenu
    {
        /// <summary>
        /// Displays MainMenu
        /// </summary>
        public static void ShowMainMenu()
        {
            string menuOption = new string("");
            string menu = "Pizza Manager\n\n" +
                            "1 - Costumers\n" +
                            "2 - Orders\n" +
                            "3 - Ingredients\n" +
                            "4 - Pizzas\n" +
                            "\ne - Exit\n\n" +
                            "Option: ";
            do
            {
                Console.Write(menu);
                menuOption = Console.ReadLine();

                switch (menuOption)
                {
                    case "1":
                        ClearHelper.Clear();
                        CustomerMenu.ShowCustomersMenu();
                        break;
                    case "2":
                        ClearHelper.Clear();
                        OrderMenu.ShowOrderMenu();
                        break;
                    case "3":
                        ClearHelper.Clear();
                        IngredientMenu.ShowIngredientsMenu();
                        break;
                    case "4":
                        ClearHelper.Clear();
                        PizzaMenu.ShowPizzaMenu();
                        break;
                    case "e":
                        Console.WriteLine("Bye!");
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
