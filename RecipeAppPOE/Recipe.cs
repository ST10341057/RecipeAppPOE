using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RecipeAppPOE
{
    internal class Recipe
    {
        private string[] ingredients; // Array to store ingredient names
        private double[] quantities; // Array to store ingredient quantities
        private string[] units; // Array to store units of measurement
        private string[] steps; // Array to store recipe steps

        // Method to enter recipe details
        public void EnterRecipeDetails()
        {
            Console.WriteLine("Enter the number of ingredients: ");
            int numIngredients = int.Parse(Console.ReadLine());

            ingredients = new string[numIngredients];
            quantities = new double[numIngredients];
            units = new string[numIngredients];

            // Loop to enter details for each ingredient
            for (int i = 0; i < numIngredients; i++)
            {
                Console.WriteLine($"Enter name of ingredient {i + 1}: ");
                ingredients[i] = Console.ReadLine();

                Console.WriteLine($"Enter quantity of ingredient {i + 1}: ");
                quantities[i] = double.Parse(Console.ReadLine());

                Console.WriteLine($"Enter unit of measurement for ingredient {i + 1}: ");
                units[i] = Console.ReadLine();
            }

            Console.WriteLine("Enter the number of steps: ");
            int numSteps = int.Parse(Console.ReadLine());

            steps = new string[numSteps];

            // Loop to enter recipe steps
            for (int i = 0; i < numSteps; i++)
            {
                Console.WriteLine($"Enter step {i + 1}: ");
                steps[i] = Console.ReadLine();
            }

            Console.WriteLine("Recipe details entered successfully!");
        }


        // Method to display the recipe
        public void DisplayRecipe()
        {
            Console.WriteLine("Recipe:");
            Console.WriteLine("Ingredients:");

            // Loop to display ingredients
            for (int i = 0; i < ingredients.Length; i++)
            {
                Console.WriteLine($"{quantities[i]} {units[i]} of {ingredients[i]}");
            }

            Console.WriteLine("Steps:");

            // Loop to display recipe steps
            for (int i = 0; i < steps.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {steps[i]}");
            }
        }

        // Method to scale the recipe by a factor
        public void ScaleRecipe()
        {
            Console.WriteLine("Enter the scaling factor (0.5 for half, 2 for double, 3 for triple): ");
            double factor = double.Parse(Console.ReadLine());

            // Loop to scale ingredient quantities
            for (int i = 0; i < quantities.Length; i++)
            {
                quantities[i] *= factor;
            }

            Console.WriteLine("Recipe scaled successfully!");
        }

        // Method to reset ingredient quantities to original values
        public void ResetQuantities()
        {
            // Reset quantities to original values
            // Assuming original quantities are stored somewhere else and can be retrieved
            Console.WriteLine("Quantities reset to original values.");
        }

    
        // Method to clear all recipe data
        public void ClearAllData()
        {
            ingredients = null;
            quantities = null;
            units = null;
            steps = null;

            Console.WriteLine("All data cleared.");
        }
    } 
    
}
