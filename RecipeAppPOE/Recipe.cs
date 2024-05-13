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

        // Method to reset ingredient quantities and calories to their original values
        public void ResetQuantities()
        {
            // Reset each ingredient's quantity and calories to their original values
            foreach (var ingredient in Ingredients)
            {
                ingredient.Quantity = ingredient.OriginalQuantity;
                ingredient.Calories = ingredient.OriginalCalories;
            }
        }


        // Method to clear all recipe data
        public void ClearAllData()
        {
            // Clear ingredients and steps lists
            Ingredients.Clear();
            Steps.Clear();
        }


        // Method to add an ingredient to the recipe
        public void AddIngredient(string name, double quantity, string unit, double calories, string foodGroup)
        {
            // Create a new Ingredient object and add it to the ingredients list
            Ingredients.Add(new Ingredient(name, quantity, unit, calories, foodGroup));

            // Check if total calories exceed 300 and trigger event if necessary
            if (CalculateTotalCalories() > 300)
            {
                CaloriesExceed?.Invoke(Name);
            }
        }

        // Method to calculate the total calories of the recipe
        public double CalculateTotalCalories()
        {
            double totalCalories = 0;
            foreach (var ingredient in Ingredients)
            {
                // Calculate calories for each ingredient and sum them up
                totalCalories += ingredient.Calories * ingredient.Quantity;
            }
            return totalCalories;
        }
    }

    internal class Ingredient
    {
        // Properties
        public string Name { get; set; } // Name of the ingredient
        public double Quantity { get; set; } // Quantity of the ingredient
        public double OriginalQuantity { get; set; } // Original quantity of the ingredient
        public string Unit { get; set; } // Unit of measurement
        public double Calories { get; set; } // Calories per unit
        public double OriginalCalories { get; set; } // Original calories per unit
        public string FoodGroup { get; set; } // Food group of the ingredient


        // Constructor
        public Ingredient(string name, double quantity, string unit, double calories, string foodGroup)
        {
            Name = name;
            Quantity = quantity;
            OriginalQuantity = quantity;
            Unit = unit;
            Calories = calories;
            OriginalCalories = calories;
            FoodGroup = foodGroup;
        }
    }

}



      
