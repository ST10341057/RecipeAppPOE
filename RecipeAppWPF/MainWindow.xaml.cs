using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RecipeAppWPF
{
        public partial class MainWindow : Window
        {
            // Static list to store recipes
            public static List<Recipe> Recipes = new List<Recipe>();

            public MainWindow()
            {
                InitializeComponent();
            }

            // Event handler for Add Recipe button click
            private void AddRecipeButton_Click(object sender, RoutedEventArgs e)
            {
                AddRecipeWindow addRecipeWindow = new AddRecipeWindow();
                addRecipeWindow.Show();
            }

            // Event handler for View Recipes button click
            private void ViewRecipesButton_Click(object sender, RoutedEventArgs e)
            {
                ViewRecipesWindow viewRecipesWindow = new ViewRecipesWindow();
                viewRecipesWindow.Show();
            }

            // Event handler for Quit button click
            private void QuitButton_Click(object sender, RoutedEventArgs e)
            {
                // Close the application
                Application.Current.Shutdown();
            }
        }
 }
