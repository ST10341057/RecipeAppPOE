using System;
using System.Collections.Generic;
using System.Linq;

namespace RecipeAppPOE
{
    class Program
    {
        static List<Recipe> recipes = new List<Recipe>(); // List to store recipes

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

                        // Loop until valid input is provided for adding another ingredient
                        string addAnotherIngredient;
                        while (true)
                        {
                            Console.Write("\nDo you want to add another ingredient? (yes/no): ");
                            addAnotherIngredient = Console.ReadLine().ToLower();
                            if (addAnotherIngredient == "yes" || addAnotherIngredient == "no")
                                break; // Exit the loop if input is either "yes" or "no"
                            else
                                Console.WriteLine("Invalid input! Please enter 'yes' or 'no'.");
                        }

                        if (addAnotherIngredient == "no")
                            break; // Exit the loop if user does not want to add another ingredient
                    }

                    // Loop to add steps to the recipe
                    while (true)
                    {
                        Console.Write("\nEnter Step: ");
                        string step = Console.ReadLine();
                        recipe.Steps.Add(step); // Add step to the recipe

                        // Loop until valid input is provided for adding another step
                        string addAnotherStep;
                        while (true)
                        {
                            Console.Write("\nDo you want to add another step? (yes/no): ");
                            addAnotherStep = Console.ReadLine().ToLower();
                            if (addAnotherStep == "yes" || addAnotherStep == "no")
                                break; // Exit the loop if input is either "yes" or "no"
                            else
                                Console.WriteLine("Invalid input! Please enter 'yes' or 'no'.");
                        }

                        if (addAnotherStep == "no")
                            break; // Exit the loop if user does not want to add another step
                    }

                    recipes.Add(recipe); // Add the recipe to the list of recipes
                    break; // Exit the loop if recipe details are successfully entered
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
                        Console.WriteLine("\nNo recipes found.");
                        return;
                    }

                    recipes.Sort((r1, r2) => r1.Name.CompareTo(r2.Name)); // Sort recipes by name

                    // Display list of recipes
                    for (int i = 0; i < recipes.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {recipes[i].Name}");
                    }

                    // Prompt user to choose a recipe to display details
                    Console.Write("\nEnter the number of the recipe to display details (0 to cancel): ");
                    int recipeIndex = Convert.ToInt32(Console.ReadLine()) - 1;

                    if (recipeIndex >= 0 && recipeIndex < recipes.Count)
                    {
                        DisplayRecipeDetails(recipes[recipeIndex]); // Display details of the selected recipe
                        break; // Exit the loop after displaying recipe details
                    }
                    else if (recipeIndex == -1)
                    {
                        return; // Cancel option selected
                    }
                    else
                    {
                        Console.WriteLine("\nInvalid recipe number.");
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

            // After displaying recipe details, provide options for additional actions
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
        }

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
                    Console.Write("\nEnter the scaling factor (0.5 for half, 2 for double, 3 for triple): ");
                    double factor = Convert.ToDouble(Console.ReadLine());

                    recipe.ScaleRecipe(factor); // Scale the recipe

                    Console.WriteLine("\nRecipe scaled successfully!");
                    break; // Exit the loop after scaling the recipe
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

            DisplayRecipeDetails(recipe); // After scaling, display recipe details again
        }

        static void ResetQuantities(Recipe recipe)
        {
            recipe.ResetQuantities(); // Reset quantities of the recipe
            Console.WriteLine("\nQuantities reset to original values.");
            DisplayRecipeDetails(recipe); // After resetting, display recipe details again
        }

        static void ClearAllData(Recipe recipe)
        {
            recipe.ClearAllData(); // Clear all data of the recipe
            Console.WriteLine("\nAll data cleared.");
            DisplayRecipeDetails(recipe); // After clearing, display recipe details again
        }
    }
}
