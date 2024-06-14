using RecipeAppWPF;
using System.Windows;
using System.Windows.Controls;

namespace RecipeAppWPF
{
    public partial class RecipeDetailWindow : Window
    {
        private Recipe currentRecipe;

        public RecipeDetailWindow(Recipe recipe)
        {
            InitializeComponent();
            currentRecipe = recipe;
            DisplayRecipeDetails();
        }

        // Display the details of the selected recipe
        private void DisplayRecipeDetails()
        {
            RecipeNameTextBlock.Text = currentRecipe.RecipeName;
            IngredientsStackPanel.Children.Clear();
            foreach (var ingredient in currentRecipe.Ingredients)
            {
                TextBlock ingredientTextBlock = new TextBlock
                {
                    Text = $"- {ingredient.Quantity} {ingredient.UnitOfMeasurement} of {ingredient.Name} ({ingredient.Calories} calories) ({ingredient.FoodGroup})"
                };
                IngredientsStackPanel.Children.Add(ingredientTextBlock);
            }

            StepsStackPanel.Children.Clear();
            foreach (var step in currentRecipe.Steps)
            {
                TextBlock stepTextBlock = new TextBlock
                {
                    Text = $"{step.StepNumber}. {step.Description}"
                };
                StepsStackPanel.Children.Add(stepTextBlock);
            }

            TotalCaloriesTextBlock.Text = currentRecipe.TotalCalories.ToString();
        }
        // Event handler for the Scale button click
        private void ScaleButton_Click(object sender, RoutedEventArgs e)
        {
            ScaleRecipeWindow scaleWindow = new ScaleRecipeWindow(currentRecipe);
            if (scaleWindow.ShowDialog() == true)
            {
                double scaleFactor = scaleWindow.ScaleFactor;
                currentRecipe.Scale(scaleFactor);
                DisplayRecipeDetails();
            }
        }
        // Event handler for the Reset button click
        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            currentRecipe.ResetIngredientValues();
            DisplayRecipeDetails();
        }
        // Event handler for the Delete button click
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            RecipeRepository.Recipes.Remove(currentRecipe);
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            ViewRecipesWindow viewRecipesWindow = new ViewRecipesWindow();
            viewRecipesWindow.Show();
            this.Close();
        }
    }
}
