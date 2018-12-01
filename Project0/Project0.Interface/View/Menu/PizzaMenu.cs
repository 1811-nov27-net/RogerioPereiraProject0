﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Project0.Interface.View.Menu
{
    public class PizzaMenu
    {
        /// <summary>
        /// Show Pizza Main Menu
        /// </summary>
        public static void ShowPizzaMenu()
        {
            string menuOption = new string("");
            string menu = "Pizzas\n\n" +
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
                        Console.WriteLine("New Pizza!");
                        Console.ReadKey();
                        ClearHelper.Clear();
                        break;
                    case "2":
                        ClearHelper.Clear();
                        Console.WriteLine("Show All Pizzas!");
                        Console.ReadKey();
                        ClearHelper.Clear();
                        break;
                    case "3":
                        ClearHelper.Clear();
                        Console.WriteLine("Find Pizza!");
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