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
        public string Name { get; set; } // Name of the recipe
        public List<Ingredient> Ingredients { get; set; } // List of ingredients
        public List<string> Steps { get; set; } // List of steps

        public delegate void CaloriesExceedHandler(string recipeName); // Delegate for handling calories exceeding 300
        public event CaloriesExceedHandler CaloriesExceed; // Event triggered when calories exceed 300


        // Constructor
        public Recipe(string name)
        {
            Name = name;
            Ingredients = new List<Ingredient>(); // Initialize ingredients list
            Steps = new List<string>(); // Initialize steps list
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


      
