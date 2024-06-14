using System.Collections.Generic;

namespace RecipeAppWPF
{
    public static class RecipeManager
    {
        private static List<Recipe> recipes = new List<Recipe>();

        public static List<Recipe> Recipes => recipes;

        public static void AddRecipe(Recipe recipe)
        {
            recipes.Add(recipe);
        }

        public static void DeleteRecipe(int index)
        {
            if (index >= 0 && index < recipes.Count)
            {
                recipes.RemoveAt(index);
            }
        }
    }
}
