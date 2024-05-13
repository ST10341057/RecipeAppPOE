using RecipeAppPOE;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;


namespace RecipeAppPOE
{
    internal class Recipe
    {
        // Properties
        public string Name { get; set; }                     // Name of the recipe
        public List<Ingredient> Ingredients { get; set; }    // List of ingredients
        public List<string> Steps { get; set; }              // List of steps

        // Delegate for notification when calories exceed 300
        public delegate void CaloriesExceedHandler(string recipeName);
        public event CaloriesExceedHandler CaloriesExceed;

        // Method to enter recipe details
        public void EnterRecipeDetails()
        {
            int numIngredients;
            while (true)
            {
                Console.WriteLine("\n\u001b[34m------------------------------------");
                Console.WriteLine("----------Recipe Details------------");
                Console.WriteLine("------------------------------------\u001b[0m");
                Console.Write("\nEnter the number of ingredients: ");
                if (!int.TryParse(Console.ReadLine(), out numIngredients) || numIngredients <= 0)
                {
                    Console.WriteLine("\n\u001b[31mInvalid input! Please enter a positive integer.\u001b[0m\n");
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
                        Console.WriteLine("\n\u001b[31mInvalid input! Please enter a positive number for quantity.\u001b[0m\n");
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
                    Console.WriteLine("\n\u001b[31mInvalid input! Please enter a positive integer.\u001b[0m\n");
                }
            }

            steps = new string[numSteps];

            // Loop to enter recipe steps
            for (int i = 0; i < numSteps; i++)
            {
                Console.Write($"Enter step {i + 1}: ");
                steps[i] = Console.ReadLine();
            }

            Console.WriteLine("\u001b[2mRecipe details entered successfully!\u001b[0m");

            // Store original quantities
            originalQuantities = quantities.ToArray(); // Copy the current quantities into originalQuantities
        }


        // Method to display the recipe
        public void DisplayRecipe()
        {
            Console.WriteLine("\n\u001b[34m------------------------------------");
            Console.WriteLine("---------------RECIPE---------------");
            Console.WriteLine("------------------------------------\u001b[0m\n");
            Console.WriteLine("\u001b[31mIngredients:\u001b[0m\n");

            if (ingredients == null || ingredients.Length == 0)
            {
                Console.WriteLine("\\" +
                    "\n\u001b[31mNo recipe details found. Please enter recipe details first.\u001b[0m\n");
                return;
            }

            // Loop to display ingredients
            for (int i = 0; i < ingredients.Length; i++)
            {
                Console.WriteLine($"{quantities[i]} {units[i]} of {ingredients[i]}");
            }

            Console.Write("\n\u001b[31mSteps:\u001b[0m\n");

            if (steps == null || steps.Length == 0)
            {
                Console.WriteLine("\n\u001b[31mNo recipe steps found.\u001b[0m");
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
                Console.WriteLine("\n\u001b[31mNo recipe details found. Please enter recipe details first.\u001b[0m");
                return;
            }

            double factor;
            while (true)
            {
                Console.WriteLine("\n\u001b[34m------------------------------------");
                Console.WriteLine("----------Scale Recipe-------------");
                Console.WriteLine("------------------------------------\u001b[0m\n");
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
                    Console.WriteLine("\n\u001b[31mInvalid input! Please enter a valid positive number for the scaling factor.\u001b[0m\n");
                }
            }

            // Loop to scale ingredient quantities
            for (int i = 0; i < quantities.Length; i++)
            {
                quantities[i] *= factor;
            }

            Console.WriteLine("\n\u001b[2mRecipe scaled successfully!\u001b[0m");
        }

        // Method to reset ingredient quantities to original values
        public void ResetQuantities()
        {
            if (originalQuantities != null)
            {
                // Copy original quantities back to quantities array
                originalQuantities.CopyTo(quantities, 0);
                Console.WriteLine("\n\u001b[2mQuantities reset to original values.\u001b[0m");
            }
            else
            {
                Console.WriteLine("\n\u001b[31mNo original quantities found. Please enter recipe details first.\u001b[0m");
            }
        }


        // Method to clear all recipe data
        public void ClearAllData()
        {
            Console.WriteLine("\nAre you sure you want to clear all data? (yes/no)");

            string confirmation;
            while (true)
            {
                confirmation = Console.ReadLine().Trim().ToLower();

                if (confirmation == "yes" || confirmation == "no" || confirmation == "y" || confirmation == "n")
                {
                    break; // Exit the loop if a valid confirmation is entered
                }
                else
                {
                    Console.WriteLine("\u001b[31mInvalid input! Please enter 'yes' or 'no'.\u001b[0m");
                }
            }

            if (confirmation == "yes" || confirmation == "y")
            {
                ingredients = null;
                quantities = null;
                units = null;
                steps = null;

                Console.WriteLine("\n\u001b[2mAll data cleared.\u001b[0m");
            }
            else
            {
                Console.WriteLine("\u001b[2mClear all data operation cancelled.\u001b[0m");
            }
        }

        public Recipe(string name)
        {
            Name = name;
            Ingredients = new List<Ingredient>();
            Steps = new List<string>();
        }

        // Method to add an ingredient to the recipe
        public void AddIngredient(string name, double quantity, string unit, double calories, string foodGroup)
        {
            Ingredients.Add(new Ingredient(name, quantity, unit, calories, foodGroup));
            // Check if total calories exceed 300
            if (CalculateTotalCalories() > 300)
            {
                // Notify the user
                CaloriesExceed?.Invoke(Name);
            }
        }

        // Method to calculate the total calories of the recipe
        public double CalculateTotalCalories()
        {
            double totalCalories = 0;
            foreach (var ingredient in Ingredients)
            {
                totalCalories += ingredient.Calories;
            }
            return totalCalories;
        }
    }

    // Class to represent an ingredient 
    internal class Ingredient
    {
        // Properties
        public string Name { get; set; }         // Name of the ingredient
        public double Quantity { get; set; }     // Quantity of the ingredient
        public string Unit { get; set; }         // Unit of measurement
        public double Calories { get; set; }     // Calories of the ingredient
        public string FoodGroup { get; set; }    // Food group of the ingredient

        // Constructor
        public Ingredient(string name, double quantity, string unit, double calories, string foodGroup)
        {
            Name = name;
            Quantity = quantity;
            Unit = unit;
            Calories = calories;
            FoodGroup = foodGroup;
        }
    }
}


      
