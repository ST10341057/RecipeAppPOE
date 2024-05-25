using System;
using System.Collections.Generic;

namespace RecipeAppPOE
{
    class Program
    {
        // List to store recipes
        static List<Recipe> recipes = new List<Recipe>();

        static void Main(string[] args)
        {
            while (true)
            {
                // Display main menu
                Console.WriteLine("\n------------------------------------");
                Console.WriteLine("========== Recipe App ^_^ ==========");
                Console.WriteLine("------------------------------------");

                Console.WriteLine("\n1. Enter Recipe Details");
                Console.WriteLine("2. Display List of Recipes");
                Console.WriteLine("3. Exit");
                Console.WriteLine("-------------------");
                Console.Write("\nChoose an option: ");

                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        EnterRecipeDetails(); // Option to enter recipe details
                        break;
                    case "2":
                        DisplayListOfRecipes(); // Option to display list of recipes
                        break;
                    case "3":
                        return; // Exit the program
                    default:
                        Console.WriteLine("\nInvalid option! Please choose again."); // Invalid option selected
                        break;
                }
            }
        }

        // Method to enter recipe details
        static void EnterRecipeDetails()
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("\n------------------------------------");
                    Console.WriteLine("---------- Recipe Details ----------");
                    Console.WriteLine("------------------------------------");

                    // Prompt user to enter recipe name
                    Console.Write("\nEnter the name of the recipe: ");
                    string recipeName = Console.ReadLine();

                    // Create a new recipe
                    Recipe recipe = new Recipe(recipeName);

                    // Subscribe to events
                    recipe.CaloriesExceed += Recipe_CaloriesExceed;
                    recipe.CaloriesWarning += Recipe_CaloriesWarning;

                    // Loop to add ingredients to the recipe
                    while (true)
                    {
                        Ingredient ingredient = GetIngredientDetails(); // Get ingredient details from user
                        recipe.AddIngredient(ingredient.Name, ingredient.Quantity, ingredient.Unit, ingredient.Calories, ingredient.FoodGroup);

                        if (!PromptForMore("ingredient")) // Check if user wants to add more ingredients
                            break;
                    }

                    // Loop to add steps to the recipe
                    while (true)
                    {
                        Console.Write("\nEnter Step: ");
                        string step = Console.ReadLine();
                        recipe.Steps.Add(step); // Add step to the recipe

                        if (!PromptForMore("step")) // Check if user wants to add more steps
                            break;
                    }

                    recipes.Add(recipe); // Add the recipe to the list
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}"); // Catch and display any exceptions
                }
            }
        }

        // Method to prompt user if they want to add more items (ingredients or steps)
        static bool PromptForMore(string item)
        {
            while (true)
            {
                Console.Write($"\nDo you want to add another {item}? (yes/no): ");
                string input = Console.ReadLine().ToLower();
                if (input == "yes") return true; // Continue adding
                if (input == "no") return false; // Stop adding
                Console.WriteLine("Invalid input! Please enter 'yes' or 'no'."); // Invalid input
            }
        }

        // Method to get ingredient details from user
        static Ingredient GetIngredientDetails()
        {
            Console.WriteLine("\nAdd Ingredient:");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            double quantity = ReadDouble("Quantity: "); // Get quantity
            Console.Write("Unit: ");
            string unit = Console.ReadLine();
            double calories = ReadDouble("Calories: "); // Get calories
            Console.Write("Food Group: ");
            string foodGroup = Console.ReadLine();

            return new Ingredient(name, quantity, unit, calories, foodGroup);
        }

        // Method to read a double value from user with validation
        static double ReadDouble(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                if (double.TryParse(Console.ReadLine(), out double value))
                {
                    return value; // Return valid input
                }
                Console.WriteLine("Invalid input! Please enter a valid number."); // Invalid input
            }
        }

        // Method to display the list of recipes
        static void DisplayListOfRecipes()
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("\n------------------------------------");
                    Console.WriteLine("-------- List of Recipes -----------");
                    Console.WriteLine("------------------------------------");

                    if (recipes.Count == 0)
                    {
                        Console.WriteLine("\nNo recipes found."); // No recipes in the list
                        return;
                    }

                    recipes.Sort((r1, r2) => r1.Name.CompareTo(r2.Name)); // Sort recipes by name

                    for (int i = 0; i < recipes.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {recipes[i].Name}"); // Display recipe names
                    }

                    // Prompt user to choose a recipe to display details
                    Console.Write("\nEnter the number of the recipe to display details (0 to cancel): ");
                    int recipeIndex = Convert.ToInt32(Console.ReadLine()) - 1;

                    if (recipeIndex >= 0 && recipeIndex < recipes.Count)
                    {
                        DisplayRecipeDetails(recipes[recipeIndex]); // Display details of the selected recipe
                        break;
                    }
                    else if (recipeIndex == -1)
                    {
                        return; // Cancel option selected
                    }
                    else
                    {
                        Console.WriteLine("\nInvalid recipe number."); // Invalid recipe number
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input! Please enter a valid number."); // Handle format exception for numeric input
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}"); // Catch and display any other exceptions
                }
            }
        }

        // Method to display recipe details
        static void DisplayRecipeDetails(Recipe recipe)
        {
            Console.WriteLine("\n------------------------------------");
            Console.WriteLine($"Recipe: {recipe.Name}");
            Console.WriteLine("------------------------------------");

            // Display ingredients of the recipe
            Console.WriteLine("\nIngredients:");
            foreach (var ingredient in recipe.Ingredients)
            {
                Console.WriteLine($"- {ingredient.Name}: {ingredient.Quantity} {ingredient.Unit}, {ingredient.Calories} calories, {ingredient.FoodGroup}");
            }

            // Display steps of the recipe
            Console.WriteLine("\nSteps:");
            for (int i = 0; i < recipe.Steps.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {recipe.Steps[i]}");
            }

            // Display total calories of the recipe
            Console.WriteLine($"\nTotal Calories: {recipe.CalculateTotalCalories()}");
            Console.WriteLine("------------------------------------");

            // Display options for additional actions
            Console.WriteLine("\nOptions:");
            Console.WriteLine("1. Scale Recipe");
            Console.WriteLine("2. Reset Quantities");
            Console.WriteLine("3. Clear All Data");
            Console.WriteLine("4. Go Back to Recipe List");
            Console.Write("\nChoose an option: ");

            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    ScaleRecipe(recipe); // Option to scale the recipe
                    break;
                case "2":
                    ResetQuantities(recipe); // Option to reset quantities of the recipe
                    break;
                case "3":
                    ClearAllData(recipe); // Option to clear all data of the recipe
                    break;
                case "4":
                    DisplayListOfRecipes(); // Option to go back to the list of recipes
                    break;
                default:
                    Console.WriteLine("\nInvalid option! Please choose again."); // Invalid option selected
                    DisplayRecipeDetails(recipe); // Prompt again for option
                    break;
            }

            if (recipe.CalculateTotalCalories() > 300)
            {
                recipe.OnCaloriesExceed(recipe.Name); // Trigger CaloriesExceed event if calories exceed 300
            }
        }

        // Method to scale a recipe
        static void ScaleRecipe(Recipe recipe)
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("\n------------------------------------");
                    Console.WriteLine("---------- Scale Recipe ------------");
                    Console.WriteLine("------------------------------------");

                    // Prompt user to enter scaling factor
                    double factor = ReadDouble("\nEnter the scaling factor (0.5 for half, 2 for double, 3 for triple): ");
                    recipe.ScaleRecipe(factor); // Scale the recipe

                    Console.WriteLine("\nRecipe scaled successfully!");
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}"); // Catch and display any exceptions
                }
            }

            DisplayRecipeDetails(recipe); // After scaling, display recipe details again
        }

        // Method to reset ingredient quantities
        static void ResetQuantities(Recipe recipe)
        {
            recipe.ResetQuantities(); // Reset quantities of the recipe
            Console.WriteLine("\nQuantities reset to original values.");
            DisplayRecipeDetails(recipe); // After resetting, display recipe details again
        }

        // Method to clear all data of a recipe
        static void ClearAllData(Recipe recipe)
        {
            recipe.ClearAllData(); // Clear all data of the recipe
            Console.WriteLine("\nAll data cleared.");
            DisplayRecipeDetails(recipe); // After clearing, display recipe details again
        }

        // Event handler for CaloriesExceed event
        static void Recipe_CaloriesExceed(string recipeName)
        {
            Console.WriteLine($"WARNING: Total calories of {recipeName} exceed 300!");
        }

        // Event handler for CaloriesWarning event
        static void Recipe_CaloriesWarning(string recipeName, double calories)
        {
            Console.WriteLine($"WARNING: Total calories of {recipeName} are approaching 300! Current calories: {calories}");
        }
    }
}
