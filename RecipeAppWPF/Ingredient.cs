namespace RecipeAppWPF
{
    public class Ingredient
    {
        private string name;
        private double quantity;
        private double originalQuantity;
        private string unitOfMeasurement;
        private double calories;
        private double originalCalories;
        private string foodGroup;

        // Method to reset quantity to the original quantity
        public void ResetQuantity()
        {
            quantity = originalQuantity;
            calories = originalCalories;
        }

        // Getters and setters for private attributes
        public string Name 
        { 
            get { return name; } 
            set { name = value; }
        }

        public double Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

        public double OriginalQuantity
        {
            get { return originalQuantity; }
            set { originalQuantity = value; }
        }

        public string UnitOfMeasurement
        {
            get { return unitOfMeasurement; }
            set { unitOfMeasurement = value; }
        }

        public double Calories
        {
            get { return calories; }
            set { calories = value; }
        }

        public double OriginalCalories
        {
            get { return originalCalories; }
            set { originalCalories = value; }
        }

        public string FoodGroup
        {
            get { return foodGroup; }
            set { foodGroup = value; }
        }
    }
}
