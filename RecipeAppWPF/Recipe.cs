using System;
using System.Collections.Generic;

namespace RecipeAppPOE
{
    internal class Recipe
    {
        // Properties
        public string Name { get; set; } // Name of the recipe
        public List<Ingredient> Ingredients { get; set; } // List of ingredients
        public List<string> Steps { get; set; } // List of steps

        // Delegates and events for handling calorie thresholds
        public delegate void CaloriesExceedHandler(string recipeName);
        public event CaloriesExceedHandler CaloriesExceed;

        public delegate void CaloriesWarningHandler(string recipeName, double calories);
        public event CaloriesWarningHandler CaloriesWarning;

        // Constructor
        public Recipe(string name)
        {
            Name = name;
            Ingredients = new List<Ingredient>(); // Initialize ingredients list
            Steps = new List<string>(); // Initialize steps list
        }

        // Method to add an ingredient to the recipe
        public void AddIngredient(string name, double quantity, string unit, double calories, string foodGroup)
        {
            // Create a new Ingredient object and add it to the ingredients list
            Ingredients.Add(new Ingredient(name, quantity, unit, calories, foodGroup));

            double totalCalories = CalculateTotalCalories();
            // Trigger warning if calories are approaching 300
            if (totalCalories > 250 && totalCalories <= 300)
            {
                CaloriesWarning?.Invoke(Name, totalCalories);
            }
            // Trigger exceed event if calories exceed 300
            else if (totalCalories > 300)
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

        // Method to scale the recipe by a factor
        public void ScaleRecipe(double factor)
        {
            // Scale the quantity and calories of each ingredient by the given factor
            foreach (var ingredient in Ingredients)
            {
                ingredient.Quantity *= factor;
                ingredient.Calories *= factor;
            }
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
            Ingredients.Clear();
            Steps.Clear();
        }

        // Method to raise the CaloriesExceed event
        public virtual void OnCaloriesExceed(string recipeName)
        {
            CaloriesExceed?.Invoke(recipeName);
        }

        // Method to raise the CaloriesWarning event
        public virtual void OnCaloriesWarning(string recipeName, double calories)
        {
            CaloriesWarning?.Invoke(recipeName, calories);
        }
    }

    internal class Ingredient
    {
        // Properties
        public string Name { get; set; }
        public double Quantity { get; set; }
        public double OriginalQuantity { get; set; }
        public string Unit { get; set; }
        public double Calories { get; set; }
        public double OriginalCalories { get; set; }
        public string FoodGroup { get; set; }

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
