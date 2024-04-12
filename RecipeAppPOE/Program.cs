﻿using RecipeAppPOE;
using System;

namespace RecipeApp

{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new Recipe object
            Recipe recipe = new Recipe();

            while (true)
            {   
                // Display menu options
                Console.WriteLine("\n------------------------------------");
                Console.WriteLine("========== Recipe App ^_^ ==========");
                Console.WriteLine("------------------------------------");
                
                Console.WriteLine("\n1. Enter Recipe Details");
                Console.WriteLine("2. Display Recipe");
                Console.WriteLine("3. Scale Recipe");
                Console.WriteLine("4. Reset Quantities");
                Console.WriteLine("5. Clear All Data");
                Console.WriteLine("6. Exit");
                Console.WriteLine("-------------------");
                Console.Write("Choose an option: ");
                

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
                        return; // Exit the program
                    default:
                        Console.WriteLine("\nInvalid option! Please choose again.");
                        break;
                }
            }
        }
    }
}