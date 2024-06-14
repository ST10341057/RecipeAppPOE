using RecipeAppWPF;
using System.Windows;

namespace RecipeAppWPF
{
    public partial class ScaleRecipeWindow : Window
    {
        public double ScaleFactor { get; private set; }

        public ScaleRecipeWindow(Recipe recipe)
        {
            InitializeComponent();
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(ScaleFactorTextBox.Text, out double scaleFactor) && scaleFactor > 0)
            {
                ScaleFactor = scaleFactor;
                DialogResult = true;
                Close();
            }
            else
            {
                MessageBox.Show("Please enter a valid scale factor.", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
