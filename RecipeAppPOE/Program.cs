using RecipeAppPOE;
using System;

namespace RecipeApp

{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a Recipe object and a boolean variable to control the loop
            Recipe recipe = new Recipe();
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("1. Enter Recipe Details");
                Console.WriteLine("2. Display Recipe");
                Console.WriteLine("3. Scale Recipe");
                Console.WriteLine("4. Reset Quantities");
                Console.WriteLine("5. Clear All Data");
                Console.WriteLine("6. Exit");
                Console.WriteLine("\nChoose an option: ");
                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        recipe.EnterRecipeDetails();
                        break;
                    case "2":
                        recipe.DisplayRecipe();
                        break;
                    case "3":
                        recipe.ScaleRecipe();
                        break;
                    case "4":
                        recipe.ResetQuantities();
                        break;
                    case "5":
                        recipe.ClearAllData();
                        break;
                    case "6":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid option! Please choose again.");
                        break;
                }
            }
        }
    }
}          