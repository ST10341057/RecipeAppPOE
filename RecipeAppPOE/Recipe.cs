using System;
using System.Collections.Generic;
using System.Globalization;
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
        private double[] originalQuantities; // Array to store original ingredient quantities

        // Method to enter recipe details
        public void EnterRecipeDetails()
        {
            int numIngredients;
            while (true)
            {
                Console.WriteLine("\n------------------------------------");
                Console.WriteLine("----------Recipe Details------------");
                Console.WriteLine("------------------------------------");
                Console.Write("\nEnter the number of ingredients: ");
                if (!int.TryParse(Console.ReadLine(), out numIngredients) || numIngredients <= 0)
                {
                    Console.WriteLine("\nInvalid input! Please enter a positive integer.\n");
                }
                else
                {
                    break; // Exit the loop if a valid number of ingredients is entered
                }
            }

            ingredients = new string[numIngredients];
            quantities = new double[numIngredients];
            units = new string[numIngredients];

            // Loop to enter details for each ingredient
            for (int i = 0; i < numIngredients; i++)
            {
                Console.Write($"Enter name of ingredient {i + 1}: ");
                ingredients[i] = Console.ReadLine();

                while (true)
                {
                    Console.Write($"Enter quantity of ingredient {i + 1}: ");
                    if (double.TryParse(Console.ReadLine(), out quantities[i]) && quantities[i] > 0)
                    {
                        break; // Exit the loop if a valid quantity is entered
                    }
                    else
                    {
                        Console.WriteLine("\nInvalid input! Please enter a positive number for quantity.\n");
                    }
                }

                Console.Write($"Enter unit of measurement for ingredient {i + 1}: ");
                units[i] = Console.ReadLine();
            }

            int numSteps;
            while (true)
            {
                Console.Write("Enter the number of steps: ");
                if (int.TryParse(Console.ReadLine(), out numSteps) && numSteps > 0)
                {
                    break; // Exit the loop if a valid number of steps is entered
                }
                else
                {
                    Console.WriteLine("\nInvalid input! Please enter a positive integer.\n");
                }
            }

            steps = new string[numSteps];

            // Loop to enter recipe steps
            for (int i = 0; i < numSteps; i++)
            {
                Console.Write($"Enter step {i + 1}: ");
                steps[i] = Console.ReadLine();
            }

            Console.WriteLine("Recipe details entered successfully!");

            // Store original quantities
            originalQuantities = quantities.ToArray(); // Copy the current quantities into originalQuantities
        }


        // Method to display the recipe
        public void DisplayRecipe()
        {
            Console.WriteLine("\n------------------------------------");
            Console.WriteLine("---------------RECIPE---------------");
            Console.WriteLine("------------------------------------\n");
            Console.WriteLine("Ingredients:\n");

            if (ingredients == null || ingredients.Length == 0)
            {
                Console.WriteLine("\\" +
                    "\nNo recipe details found. Please enter recipe details first.\n");
                return;
            }

            // Loop to display ingredients
            for (int i = 0; i < ingredients.Length; i++)
            {
                Console.WriteLine($"{quantities[i]} {units[i]} of {ingredients[i]}");
            }

            Console.Write("\nSteps:\n");

            if (steps == null || steps.Length == 0)
            {
                Console.WriteLine("\nNo recipe steps found.");
                return;
            }

            // Loop to display recipe steps
            for (int i = 0; i < steps.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {steps[i]}");
            }
        }

        // Method to scale the recipe by a factor
        public void ScaleRecipe()
        {
            if (ingredients == null || ingredients.Length == 0)
            {
                Console.WriteLine("\nNo recipe details found. Please enter recipe details first.");
                return;
            }

            double factor;
            while (true)
            {
                Console.WriteLine("\n------------------------------------");
                Console.WriteLine("----------Scale Recipe-------------");
                Console.WriteLine("------------------------------------\n");
                Console.Write("Enter the scaling factor (0.5 for half, 2 for double, 3 for triple): ");
                string input = Console.ReadLine();

                // Replace commas with dots in the input string
                input = input.Replace(',', '.');

                if (double.TryParse(input, NumberStyles.Any, CultureInfo.InvariantCulture, out factor) && factor > 0)
                {
                    break; // Exit the loop if a valid factor is entered
                }
                else
                {
                    Console.WriteLine("\nInvalid input! Please enter a valid positive number for the scaling factor.\n");
                }
            }

            // Loop to scale ingredient quantities
            for (int i = 0; i < quantities.Length; i++)
            {
                quantities[i] *= factor;
            }

            Console.WriteLine("\nRecipe scaled successfully!");
        }

        // Method to reset ingredient quantities to original values
        public void ResetQuantities()
        {
            if (originalQuantities != null)
            {
                // Copy original quantities back to quantities array
                originalQuantities.CopyTo(quantities, 0);
                Console.WriteLine("\nQuantities reset to original values.");
            }
            else
            {
                Console.WriteLine("\nNo original quantities found. Please enter recipe details first.");
            }
        }

    
        // Method to clear all recipe data
        public void ClearAllData()
        {
            ingredients = null;
            quantities = null;
            units = null;
            steps = null;

            Console.WriteLine("\nAll data cleared.");
        }
    } 
    
}
