using System;
using System.Collections.Generic;
using System.Text;

namespace Project0.Interface.View.Menu
{
    public class IngredientMenu
    {
        /// <summary>
        /// Show Costumer Main Menu
        /// </summary>
        public static void ShowIngredientsMenu()
        {
            string menuOption = new string("");
            string menu = "Ingredients\n\n" +
                            "1 - New\n" +
                            "2 - Show All\n" +
                            "3 - Find\n" +
                            "4 - Invetory\n" +
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
                        Console.WriteLine("New Ingredient!");
                        Console.ReadKey();
                        ClearHelper.Clear();
                        break;
                    case "2":
                        ClearHelper.Clear();
                        Console.WriteLine("Show All Ingredients!");
                        Console.ReadKey();
                        ClearHelper.Clear();
                        break;
                    case "3":
                        ClearHelper.Clear();
                        Console.WriteLine("Find Ingredient!");
                        Console.ReadKey();
                        ClearHelper.Clear();
                        break;
                    case "4":
                        ClearHelper.Clear();
                        Console.WriteLine("Inventory!");
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
