using RecipeAppWPF;
using System.Windows;

namespace RecipeAppWPF
{
    public partial class AddRecipeWindow : Window
    {
        public Recipe NewRecipe { get; private set; }

        public AddRecipeWindow()
        {
            InitializeComponent();
            NewRecipe = new Recipe(); // Initialize a new recipe object
        }

        // Event handler for adding an ingredient
        private void AddIngredientButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Create a new ingredient from the input fields
                Ingredient ingredient = new Ingredient
                {
                    Name = IngredientNameTextBox.Text,
                    Quantity = double.Parse(IngredientQuantityTextBox.Text),
                    Unit = IngredientUnitTextBox.Text,
                    Calories = double.Parse(IngredientCaloriesTextBox.Text),
                    FoodGroup = IngredientFoodGroupTextBox.Text
                };

                // Add the ingredient to the new recipe
                NewRecipe.AddIngredient(ingredient);
                // Clear input fields after adding the ingredient
                IngredientNameTextBox.Clear();
                IngredientQuantityTextBox.Clear();
                IngredientUnitTextBox.Clear();
                IngredientCaloriesTextBox.Clear();
                IngredientFoodGroupTextBox.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding ingredient: {ex.Message}");
            }
        }

        // Event handler for adding a step
        private void AddStepButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Add the step to the new recipe
                NewRecipe.Steps.Add(StepTextBox.Text);
                // Clear the input field after adding the step
                StepTextBox.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding step: {ex.Message}");
            }
        }

        // Event handler for saving the recipe
        private void SaveRecipeButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Set the recipe name
                NewRecipe.Name = RecipeNameTextBox.Text;
                // Add the new recipe to the main list
                MainWindow.Recipes.Add(NewRecipe);
                // Close the AddRecipeWindow
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving recipe: {ex.Message}");
            }
        }
    }
}
