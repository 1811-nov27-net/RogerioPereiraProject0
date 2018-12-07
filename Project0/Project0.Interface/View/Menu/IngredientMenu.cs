﻿using Project0.Interface.View.Ingredients;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project0.Interface.View.Menu
{
    public class IngredientMenu
    {
        /// <summary>
        /// Show Ingredients Main Menu
        /// </summary>
        public static void ShowIngredientsMenu()
        {
            string menuOption = new string("");
            string menu = "Ingredients\n\n" +
                            "1 - New\n" +
                            "2 - Invetory\n" +
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
                        IngredientForm.ShowForm();
                        break;
                    case "2":
                        ClearHelper.Clear();
                        ShowAll.Show();
                        break;
                    case "3":
                        ClearHelper.Clear();
                        SearchForm.Search();
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
