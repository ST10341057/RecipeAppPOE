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