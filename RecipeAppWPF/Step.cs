namespace RecipeAppWPF
{
    public class Step
    {
        private int stepNumber;
        private string description;

        // Method that runs upon instance creation
        public Step (int number)
        {
            stepNumber = number;
        }

        // Setter and getter methods for private attributes
        public int StepNumber
        {
            get { return stepNumber; }
            set { stepNumber = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }
    }
}
