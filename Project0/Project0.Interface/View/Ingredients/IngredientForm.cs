using System;
using System.Collections.Generic;
using System.Text;
using Project0.Library.Model;

namespace Project0.Interface.View.Ingredients
{
    public class IngredientForm
    {
        public static void ShowForm()
        {
            Ingredient ingredient = new Ingredient();

            Console.Write("Ingrediente Name:\n");
            ingredient.Name = Console.ReadLine();

            Console.Write("Quantity in Stock:\n");
            ingredient.Quantity = Int32.Parse(Console.ReadLine());
        }
    }
}
