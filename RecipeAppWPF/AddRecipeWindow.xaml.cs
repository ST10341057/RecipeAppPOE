using RecipeAppWPF;
using System.Windows.Controls;
using System.Windows;

public partial class AddRecipeWindow : Window
{
    private Recipe currentRecipe;
    private bool notificationShown;

    public AddRecipeWindow()
    {
        InitializeComponent();
        currentRecipe = new Recipe();
        currentRecipe.TotalCaloriesExceeded += OnTotalCaloriesExceeded;
        notificationShown = false;
    }

    private void AddIngredientButton_Click(object sender, RoutedEventArgs e)
    {
        // Collect ingredient details
        string name = IngredientNameTextBox.Text;
        if (int.TryParse(QuantityTextBox.Text, out int quantity) &&
            double.TryParse(CaloriesTextBox.Text, out double calories))
        {
            string unit = UnitTextBox.Text;
            string foodGroup = FoodGroupTextBox.Text;

            // Add ingredient to the recipe
            currentRecipe.AddIngredient(name, quantity, unit, calories, foodGroup, currentRecipe.Ingredients.Count);

            // Display the ingredient in the panel
            IngredientsStackPanel.Children.Add(new TextBlock { Text = name });

            // Clear form
            IngredientNameTextBox.Clear();
            QuantityTextBox.Clear();
            UnitTextBox.Clear();
            CaloriesTextBox.Clear();
            FoodGroupTextBox.Clear();
        }
        else
        {
            MessageBox.Show("Please enter valid numbers for Quantity and Calories.", "Input Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

    private void AddStepButton_Click(object sender, RoutedEventArgs e)
    {
        // Collect step details
        string description = StepDescriptionTextBox.Text;
        int stepNumber = currentRecipe.Steps.Count + 1;

        // Add step to the recipe
        currentRecipe.AddStep(stepNumber, description, currentRecipe.Steps.Count);

        // Display the step in the stack panel
        StepsStackPanel.Children.Add(new TextBlock { Text = description });

        // Clear the form
        StepDescriptionTextBox.Clear();
    }

    private void SaveRecipeButton_Click(object sender, RoutedEventArgs e)
    {
        // Collect recipe name
        string recipeName = RecipeNameTextBox.Text;
        currentRecipe.RecipeName = recipeName;

        // Save the recipe to the repository
        RecipeRepository.Recipes.Add(currentRecipe);

        // Close the window
        MainWindow mainWindow = new MainWindow();
        mainWindow.Show();
        this.Close();
    }

    private void OnTotalCaloriesExceeded(double totalCalories)
    {
        if (!notificationShown)
        {
            MessageBox.Show($"This recipe has exceeded 300 calories. Total calories: {totalCalories}", "Calorie Alert", MessageBoxButton.OK, MessageBoxImage.Warning);
            notificationShown = true;
        }
    }

    private void BackButton_Click(object sender, RoutedEventArgs e)
    {
        MainWindow mainWindow = new MainWindow();
        mainWindow.Show();
        this.Close();
    }
}
}