using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeAppWPF
{
    public static class RecipeManager
    {
        private static List<Recipe> recipes = new List<Recipe>();

        public static void AddRecipe(string name, string ingredients, string instructions)
        {
            recipes.Add(new Recipe { Name = name, Ingredients = ingredients, Instructions = instructions });
        }

        public static List<Recipe> GetRecipes()
        {
            return recipes;
        }

        public static void ScaleRecipe(string recipeName, double scaleFactor)
        {
            var recipe = recipes.Find(r => r.Name == recipeName);
            if (recipe != null)
            {
                // Assuming ingredients are stored in a specific format
                var scaledIngredients = recipe.Ingredients.Split(',')
                    .Select(i => {
                        var parts = i.Trim().Split(' ');
                        var quantity = double.Parse(parts[0]);
                        var unit = parts[1];
                        var ingredientName = string.Join(" ", parts.Skip(2));
                        return $"{quantity * scaleFactor} {unit} {ingredientName}";
                    });
                recipe.Ingredients = string.Join(", ", scaledIngredients);
            }
        }

        public static List<Recipe> FilterRecipes(string ingredient, string foodGroup, int maxCalories)
        {
            return recipes.Where(r =>
                (string.IsNullOrEmpty(ingredient) || r.Ingredients.Contains(ingredient, StringComparison.OrdinalIgnoreCase)) &&
                (string.IsNullOrEmpty(foodGroup) || r.FoodGroup.Equals(foodGroup, StringComparison.OrdinalIgnoreCase)) &&
                (maxCalories <= 0 || r.Calories <= maxCalories))
                .ToList();
        }
        
        public static Dictionary<string, double> CalculateFoodGroupPercentages(List<Recipe> selectedRecipes)
        {
            var totalCalories = selectedRecipes.Sum(r => r.Calories);
            var foodGroupCalories = selectedRecipes.GroupBy(r => r.FoodGroup)
                .ToDictionary(g => g.Key, g => g.Sum(r => r.Calories) / (double)totalCalories * 100);
            return foodGroupCalories;
        }
        
        public static List<string> GetFoodGroups()
        {
            return new List<string> { "Dairy", "Protein", "Vegetables", "Fruits", "Grains" };
        }
    }

    public class Recipe
    {
        public string Name { get; set; }
        public string Ingredients { get; set; }
        public string Instructions { get; set; }
        public int Calories { get; set; }
        public string FoodGroup { get; set; }
    }
}
