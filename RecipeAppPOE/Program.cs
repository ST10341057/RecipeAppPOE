using RecipeAppPOE;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RecipeApp
{
    class Program
    {
        static List<Recipe> recipes = new List<Recipe>(); // List to store recipes

        static void Main(string[] args)
        {
            try
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
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}"); // Catch and display any unhandled exceptions
            }
        }

        // Method to enter recipe details
        static void EnterRecipeDetails()
        {
            try
            {
                Console.WriteLine("\n------------------------------------");
                Console.WriteLine("---------- Recipe Details ----------");
                Console.WriteLine("------------------------------------");

                // Prompt user to enter recipe name
                Console.Write("\nEnter the name of the recipe: ");
                string recipeName = Console.ReadLine();

                Recipe recipe = new Recipe(recipeName); // Create a new recipe

                // Loop to add ingredients to the recipe
                while (true)
                {
                    Console.WriteLine("\nAdd Ingredient:");
                    Console.Write("Name: ");
                    string name = Console.ReadLine();
                    Console.Write("Quantity: ");
                    double quantity = Convert.ToDouble(Console.ReadLine());
                    Console.Write("Unit: ");
                    string unit = Console.ReadLine();
                    Console.Write("Calories: ");
                    double calories = Convert.ToDouble(Console.ReadLine());
                    Console.Write("Food Group: ");
                    string foodGroup = Console.ReadLine();

                    recipe.AddIngredient(name, quantity, unit, calories, foodGroup); // Add ingredient to the recipe

                    Console.Write("\nDo you want to add another ingredient? (yes/no): ");
                    string addAnother = Console.ReadLine().ToLower();
                    if (addAnother != "yes")
                        break;
                }

                // Loop to add steps to the recipe
                while (true)
                {
                    Console.Write("\nEnter Step: ");
                    string step = Console.ReadLine();
                    recipe.Steps.Add(step); // Add step to the recipe

                    Console.Write("\nDo you want to add another step? (yes/no): ");
                    string addAnother = Console.ReadLine().ToLower();
                    if (addAnother != "yes")
                        break;
                }

                recipes.Add(recipe); // Add the recipe to the list of recipes
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

}