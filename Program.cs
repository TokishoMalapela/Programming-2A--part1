using System;

class Recipe
{
    private string[] ingredients;
    private string[] steps;

    public Recipe(int numIngredients, int numSteps)
    {
        ingredients = new string[numIngredients];
        steps = new string[numSteps];
    }

    public void InputIngredients()
    {
        Console.WriteLine("Enter ingredients:");
        for (int i = 0; i < ingredients.Length; i++)
        {
            Console.Write($"Ingredient {i + 1} name: ");
            ingredients[i] = Console.ReadLine();
            Console.Write($"Quantity of {ingredients[i]}: ");
            string quantity = Console.ReadLine();
            Console.Write($"Unit of measurement for {ingredients[i]}: ");
            string unit = Console.ReadLine();
            ingredients[i] += $" - {quantity} {unit}";
        }
    }

    public void InputSteps()
    {
        Console.WriteLine("\nEnter steps:");
        for (int i = 0; i < steps.Length; i++)
        {
            Console.Write($"Step {i + 1}: ");
            steps[i] = Console.ReadLine();
        }
    }

    public void DisplayRecipe()
    {
        Console.WriteLine("\nRecipe:");
        Console.WriteLine("Ingredients:");
        foreach (string ingredient in ingredients)
        {
            Console.WriteLine(ingredient);
        }
        Console.WriteLine("\nSteps:");
        foreach (string step in steps)
        {
            Console.WriteLine(step);
        }
    }

    public void ScaleRecipe(double factor)
    {
        Console.WriteLine($"\nScaling recipe by factor of {factor}...");
        for (int i = 0; i < ingredients.Length; i++)
        {
            string[] parts = ingredients[i].Split(" - ");
            double quantity = double.Parse(parts[1].Split(' ')[0]);
            quantity *= factor;
            ingredients[i] = $"{parts[0]} - {quantity} {parts[1].Split(' ')[1]}";
        }
        Console.WriteLine("Recipe scaled successfully!");
    }

    public void ResetQuantities()
    {
        InputIngredients();
        Console.WriteLine("Quantities reset to original values.");
    }

    public void ClearData()
    {
        ingredients = new string[ingredients.Length];
        steps = new string[steps.Length];
        Console.WriteLine("All data cleared. Enter a new recipe.");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to Recipe Manager!");

        Console.Write("Enter number of ingredients: ");
        int numIngredients = int.Parse(Console.ReadLine());
        Console.Write("Enter number of steps: ");
        int numSteps = int.Parse(Console.ReadLine());

        Recipe recipe = new Recipe(numIngredients, numSteps);

        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Input ingredients");
            Console.WriteLine("2. Input steps");
            Console.WriteLine("3. Display recipe");
            Console.WriteLine("4. Scale recipe");
            Console.WriteLine("5. Reset quantities");
            Console.WriteLine("6. Clear all data");
            Console.WriteLine("7. Exit");

            Console.Write("Enter your choice: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    recipe.InputIngredients();
                    break;
                case 2:
                    recipe.InputSteps();
                    break;
                case 3:
                    recipe.DisplayRecipe();
                    break;
                case 4:
                    Console.Write("Enter scaling factor (0.5, 2, or 3): ");
                    double factor = double.Parse(Console.ReadLine());
                    recipe.ScaleRecipe(factor);
                    break;
                case 5:
                    recipe.ResetQuantities();
                    break;
                case 6:
                    recipe.ClearData();
                    break;
                case 7:
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
}
