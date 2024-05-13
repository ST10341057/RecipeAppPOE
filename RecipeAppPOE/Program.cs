using RecipeAppPOE;

{
    class Program
{
    static List<Recipe> recipes = new List<Recipe>();

    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("\n------------------------------------");
            Console.WriteLine("========== Recipe App ^_^ ==========");
            Console.WriteLine("------------------------------------");

            Console.WriteLine("\n1. Enter Recipe Details");
            Console.WriteLine("2. Display List of Recipes");
            Console.WriteLine("3. Exit");
            Console.WriteLine("-------------------");
            Console.Write("\nChoose an option: ");

            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    EnterRecipeDetails();
                    break;
                case "2":
                    DisplayListOfRecipes();
                    break;
                case "3":
                    return;
                default:
                    Console.WriteLine("\nInvalid option! Please choose again.");
                    break;
            }
        }
    }