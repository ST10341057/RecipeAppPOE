using NUnit.Framework;

namespace RecipeAppPOE.Tests
{
    [TestFixture]
    public class RecipeTests
    {
        [Test]
        public void CalculateTotalCalories_WithIngredients_ReturnsCorrectTotalCalories()
        {
            // Arrange
            var recipe = new Recipe("Test Recipe");
            recipe.AddIngredient("Ingredient 1", 100, "g", 50, "Food Group 1");
            recipe.AddIngredient("Ingredient 2", 200, "g", 70, "Food Group 2");

            // Expected total calories calculation: (100 * 50) + (200 * 70) = 5000 + 14000 = 19000
            double expectedTotalCalories = 19000;

            // Act
            double actualTotalCalories = recipe.CalculateTotalCalories();

            // Assert
            Assert.AreEqual(expectedTotalCalories, actualTotalCalories, "Total calories should be calculated correctly");
        }
    }
}