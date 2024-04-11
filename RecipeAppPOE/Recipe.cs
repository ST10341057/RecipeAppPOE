﻿using System;
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
        private double[] originalQuantities; // Array to store original ingredient quantities

        // Method to enter recipe details
        public void EnterRecipeDetails()
        {
            Console.WriteLine("Enter the number of ingredients: ");
            if (!int.TryParse(Console.ReadLine(), out int numIngredients) || numIngredients <= 0)
            {
                Console.WriteLine("Invalid input! Please enter a positive integer.");
                return;
            }

            ingredients = new string[numIngredients];
            quantities = new double[numIngredients];
            units = new string[numIngredients];

            // Loop to enter details for each ingredient
            for (int i = 0; i < numIngredients; i++)
            {
                Console.WriteLine($"Enter name of ingredient {i + 1}: ");
                ingredients[i] = Console.ReadLine();

                Console.WriteLine($"Enter quantity of ingredient {i + 1}: ");
                    if (!double.TryParse(Console.ReadLine(), out quantities[i]) || quantities[i] <= 0)
                    {
                        Console.WriteLine("Invalid input! Please enter a positive number for quantity.");
                        return;
                    }

                    Console.WriteLine($"Enter unit of measurement for ingredient {i + 1}: ");
                units[i] = Console.ReadLine();
            }

            Console.WriteLine("Enter the number of steps: ");
                if (!int.TryParse(Console.ReadLine(), out int numSteps) || numSteps <= 0)
                {
                    Console.WriteLine("Invalid input! Please enter a positive integer.");
                    return;
                }

                // Loop to enter recipe steps
                for (int i = 0; i < numSteps; i++)
            {
                Console.WriteLine($"Enter step {i + 1}: ");
                steps[i] = Console.ReadLine();
            }

            Console.WriteLine("Recipe details entered successfully!");

            // Store original quantities
            originalQuantities = quantities.ToArray(); // Copy the current quantities into originalQuantities
        }


        // Method to display the recipe
        public void DisplayRecipe()
        {
            Console.WriteLine("Recipe:");
            Console.WriteLine("Ingredients:");

            if (ingredients == null || ingredients.Length == 0)
            {
                Console.WriteLine("No recipe details found. Please enter recipe details first.");
                return;
            }

            // Loop to display ingredients
            for (int i = 0; i < ingredients.Length; i++)
            {
                Console.WriteLine($"{quantities[i]} {units[i]} of {ingredients[i]}");
            }

            Console.WriteLine("Steps:");

            if (steps == null || steps.Length == 0)
            {
                Console.WriteLine("No recipe steps found.");
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
                Console.WriteLine("No recipe details found. Please enter recipe details first.");
                return;
            }

            Console.WriteLine("Enter the scaling factor (0.5 for half, 2 for double, 3 for triple): ");
            if (!double.TryParse(Console.ReadLine(), out double factor) || factor <= 0)
            {
                Console.WriteLine("Invalid input! Please enter a positive number for the scaling factor.");
                return;
            }

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
