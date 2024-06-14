# Recipe GUI App

This is a WPF (Windows Presentation Foundation) application for managing recipes. Users can add, view, scale, reset, and delete recipes. Additionally, users can filter recipes based on ingredients, food groups, and calorie limits. The application also provides a notification if the total calories of a recipe exceed 300 while adding ingredients.

## Features
- Add new recipes with ingredients and steps.
- View all recipes.
- Scale ingredients and calories.
- Reset ingredients to original values.
- Delete recipes.
- Filter recipes based on ingredients, food groups, and calorie limits.
- Notification for recipes exceeding 300 calories.

## Prerequisites
- Visual Studio 2022 or later
- .NET 8.0 SDK or later

## Setup Instructions

### Cloning the Repository

[GitHub Repository] https://github.com/ST10341057/RecipeAppPOE/tree/RecipeAppGUI

1. Open your terminal or command prompt.
2. Clone the repository using the following command:
   ```bash
   git clone https://github.com/ST10341057/RecipeAppPOE/tree/RecipeAppGUI
   ```
3. Navigate to the project directory:
   ```bash
   cd RecipeAppWPF
   ```

### Opening the Project
1. Open Visual Studio.
2. Click on `Open a project or solution`.
3. Navigate to the `RecipeAppWPF` directory and select the `RecipeAppPOE.sln` file.

### Building the Project
1. Once the project is opened in Visual Studio, build the solution by:
   - Clicking on `Build` in the menu bar.
   - Selecting `Build Solution` (or press `Ctrl+Shift+B`).

### Running the Project
1. After successfully building the solution, run the application by:
   - Clicking on `Debug` in the menu bar.
   - Selecting `Start Debugging` (or press `F5`).


### Using the Application
1. **Add Recipe:**
   - Click on `Add New Recipe`.
   - Fill in the recipe details, add ingredients and steps, then click `Save Recipe`.
2. **View Recipes:**
   - Click on `View All Recipes`.
   - Select a recipe to view its details.
   - Use the buttons to scale, reset, or delete the recipe.
3. **Filter Recipes:**
   - Use the filter options to filter recipes by ingredient, food group, or maximum calories.

### Notifying for High-Calorie Recipes
While adding ingredients in the `AddRecipeWindow`, if the total calories exceed 300, a notification will be shown to the user once.

## Project Structure
- `MainWindow.xaml` and `MainWindow.xaml.cs`: Main window with options to add, view, or quit the application.
- `AddRecipeWindow.xaml` and `AddRecipeWindow.xaml.cs`: Window for adding new recipes.
- `ViewRecipesWindow.xaml` and `ViewRecipesWindow.xaml.cs`: Window for viewing and managing recipes.
- `RecipeDetailWindow.xaml` and `RecipeDetailWindow.xaml.cs`: Window for viewing and editing the details of a selected recipe.
- `Recipe.cs`: Model class for recipes.
- `RecipeRepository.cs`: Static class for storing and managing recipes.

## Troubleshooting
- **Debug Executable Not Found Error:**
  - Ensure the build was successful.
  - Check if the executable is being blocked by an antivirus or other security software.
  - Try cleaning the solution and rebuilding it:
    - `Build > Clean Solution`
    - `Build > Rebuild Solution`

- **Recipes Not Displaying Properly:**
  - Make sure the data bindings in the XAML files are correctly set.
  - Check the `LoadRecipes` method to ensure it correctly populates the `ListBox`.

## Feedback from lecture (part 2 fixes)

Summary of Changes
1. Event Handling: Added a new event CaloriesWarning to give a warning when calories are approaching 300.
2. Modularization: Broke down larger methods into smaller, more manageable ones.
3. Error Handling: Improved error handling for numeric inputs.
4. User Interaction: Enhanced user interaction prompts for adding ingredients and steps.