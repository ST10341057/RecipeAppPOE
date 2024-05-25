# RecipeApp by Gladwin Bapela ST10341057
Github Repository Link: https://github.com/ST10341057/RecipeAppPOE/commits/v.Part2

## Description
RecipeApp is a command-line application written in C# that allows users to manage recipe details, including ingredients and steps. 
Users can enter recipe details, display the recipe, scale the recipe by a factor, reset ingredient quantities, and clear all data.

## Features
Enter Recipe Details: Users can enter details for a recipe, including its name, ingredients, and steps.
Display List of Recipes: Users can view a list of all entered recipes in alphabetical order by name.
Scale Recipe: Users can scale the quantities of ingredients in a recipe by a given factor (e.g., double, triple).
Reset Quantities: Users can reset the quantities of ingredients in a recipe to their original values.
Clear All Data: Users can clear all data of a recipe, including ingredients and steps.
Notify User of Excessive Calories: The app notifies the user when the total calories of a recipe exceed 300.
Unit Testing: The app includes unit tests to verify the correctness of the total calorie calculation functionality.
Error Handling: The app includes error handling to handle invalid user inputs and other exceptions gracefully.
Event Handling: The app uses events and delegates to trigger notifications when the total calories exceed 300.
Organized Architecture: The code is organized into separate classes for recipes and ingredients, promoting code readability and maintainability.
Interactive Console Interface: The app interacts with users through a console-based interface, allowing them to input recipe details and select options.

## Usage
1. open the project using Visual Studio 2019 or later.
2. RecipeAppPOE.sln is the solution file that can be opened in visiua studio
3. . . Run the program using `Program.cs`. which can be found in the ``RecipeAppPOE\RecipeAppPOE\`` folder along with the rest of the source code.  
4. PATH: ``RecipeAppPOE\RecipeAppPOE\Program.cs``
5. Choose an option from the menu:
    - Enter Recipe Details
    - Display Recipe
    - Scale Recipe
    - Reset Quantities
    - Clear All Data
    - Exit

6. Follow the on-screen prompts to perform the desired action.


Changes implemented based on lecturer feedback:

  1. Didn't compress the project using .rar
  2. Referenced RecipeAppPOE.sln as the solution file that can be opened in Visual Studio to ensure that the project can be opened and run without any issues