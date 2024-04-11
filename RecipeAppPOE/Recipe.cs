using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeAppPOE
{
    internal class Recipe
    {
        private string[] ingredients;
        private double[] quantities;
        private string[] units;
        private string[] steps;

        public void EnterRecipeDetails()
        {
            Console.WriteLine("Enter the number of ingredients: ");
            int numIngredients = int.Parse(Console.ReadLine());

            ingredients = new string[numIngredients];
            quantities = new double[numIngredients];
            units = new string[numIngredients];

            for (int i = 0; i < numIngredients; i++)
            {
                Console.WriteLine($"Enter name of ingredient {i + 1}: ");
                ingredients[i] = Console.ReadLine();

                Console.WriteLine($"Enter quantity of ingredient {i + 1}: ");
                quantities[i] = double.Parse(Console.ReadLine());

                Console.WriteLine($"Enter unit of measurement for ingredient {i + 1}: ");
                units[i] = Console.ReadLine();
            }

        } 
    }
}
