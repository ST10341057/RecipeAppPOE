using RecipeAppWPF;
using RecipeAppWPF;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace RecipeAppWPF
{
    public partial class ViewRecipesWindow : Window
    {
        public ViewRecipesWindow()
        {
            InitializeComponent();
            LoadRecipes();
        }

        private void LoadRecipes()
        {
            
            var sortedRecipes = RecipeRepository.Recipes.OrderBy(recipe => recipe.RecipeName).ToList();

            // Bind the sorted recipes to the ListBox
            RecipesListBox.ItemsSource = sortedRecipes;
        }

        private void ApplyFilterButton_Click(object sender, RoutedEventArgs e)
        {
            // Get filter values
            string ingredient = IngredientTextBox.Text.ToLower();
            string foodGroup = FoodGroupTextBox.Text.ToLower();
            bool isCaloriesValid = double.TryParse(MaxCaloriesTextBox.Text, out double maxCalories);

            // Apply filters to the recipe list
            var filteredRecipes = RecipeRepository.Recipes.Where(recipe =>
                (string.IsNullOrEmpty(ingredient) || recipe.Ingredients.Any(ing => ing.Name.ToLower().Contains(ingredient))) &&
                (string.IsNullOrEmpty(foodGroup) || recipe.Ingredients.Any(ing => ing.FoodGroup.ToLower().Contains(foodGroup))) &&
                (!isCaloriesValid || recipe.TotalCalories <= maxCalories)
            ).OrderBy(recipe => recipe.RecipeName).ToList();

            // Bind the filtered recipes to the ListBox
            RecipesListBox.ItemsSource = filteredRecipes;
        }
        
        // Event handler for the SelectionChanged event of the ListBox
        private void RecipesListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Recipe selectedRecipe = (Recipe)RecipesListBox.SelectedItem;
            if (selectedRecipe != null)
            {
                RecipeDetailWindow recipeDetailWindow = new RecipeDetailWindow(selectedRecipe);
                recipeDetailWindow.Show();
                this.Close();
                // Refresh the recipes list after a recipe might be deleted
                ApplyFilterButton_Click(null, null); 
            }
        }
        // Event handler for the Back button click
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
