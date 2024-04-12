// Importing the System namespace for using Console class
using System;

// Declaring a class named Recipe
class Recipe
{
    // Private variables to hold ingredients and steps of the recipe
    private string[] ingredients;
    private string[] steps;
    
    // Constructor for creating a Recipe object with given number of ingredients and steps
    public Recipe(int numIngredients, int numSteps)
    {
        // Initializing arrays for ingredients and steps based on the given counts
        ingredients = new string[numIngredients];
        steps = new string[numSteps];
    }

    // Method to input ingredients for the recipe
    public void InputIngredients()
    {
        Console.WriteLine("Enter ingredients:");
        for (int i = 0; i < ingredients.Length; i++)
        {
            // Prompting user to input ingredient name, quantity, and unit
            Console.Write($"Ingredient {i + 1} name: ");
            ingredients[i] = Console.ReadLine();
            Console.Write($"Quantity of {ingredients[i]}: ");
            string quantity = Console.ReadLine();
            Console.Write($"Unit of measurement for {ingredients[i]}: ");
            string unit = Console.ReadLine();
            // Combining name, quantity, and unit into a single string and storing it in the ingredients array
            ingredients[i] += $" - {quantity} {unit}";
        }
    }

    // Method to input steps for the recipe
    public void InputSteps()
    {
        Console.WriteLine("\nEnter steps:");
        for (int i = 0; i < steps.Length; i++)
        {
            // Prompting user to input each step of the recipe
            Console.Write($"Step {i + 1}: ");
            steps[i] = Console.ReadLine();
        }
    }

    // Method to display the recipe
    public void DisplayRecipe()
    {
        Console.WriteLine("\nRecipe:");
        // Displaying ingredients
        Console.WriteLine("Ingredients:");
        foreach (string ingredient in ingredients)
        {
            Console.WriteLine(ingredient);
        }
        // Displaying steps
        Console.WriteLine("\nSteps:");
        foreach (string step in steps)
        {
            Console.WriteLine(step);
        }
    }

    // Method to scale the recipe by a given factor
    public void ScaleRecipe(double factor)
    {
        Console.WriteLine($"\nScaling recipe by factor of {factor}...");
        // Scaling each ingredient's quantity
        for (int i = 0; i < ingredients.Length; i++)
        {
            string[] parts = ingredients[i].Split(" - ");
            double quantity = double.Parse(parts[1].Split(' ')[0]);
            quantity *= factor;
            ingredients[i] = $"{parts[0]} - {quantity} {parts[1].Split(' ')[1]}";
        }
        Console.WriteLine("Recipe scaled successfully!");
    }

    // Method to reset quantities of ingredients to their original values
    public void ResetQuantities()
    {
        // Re-prompting user to input ingredient quantities
        InputIngredients();
        Console.WriteLine("Quantities reset to original values.");
    }

    // Method to clear all data of the recipe
    public void ClearData()
    {
        // Creating new empty arrays for ingredients and steps
        ingredients = new string[ingredients.Length];
        steps = new string[steps.Length];
        Console.WriteLine("All data cleared. Enter a new recipe.");
    }
}

// Main class of the program
class Program
{
    // Main method, entry point of the program
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to Recipe Manager!");

        // Prompting user to input number of ingredients and steps for the recipe
        Console.Write("Enter number of ingredients: ");
        int numIngredients = int.Parse(Console.ReadLine());
        Console.Write("Enter number of steps: ");
        int numSteps = int.Parse(Console.ReadLine());

        // Creating a Recipe object with the provided counts of ingredients and steps
        Recipe recipe = new Recipe(numIngredients, numSteps);

        // Main program loop
        bool exit = false;
        while (!exit)
        {
            // Displaying menu options
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Input ingredients");
            Console.WriteLine("2. Input steps");
            Console.WriteLine("3. Display recipe");
            Console.WriteLine("4. Scale recipe");
            Console.WriteLine("5. Reset quantities");
            Console.WriteLine("6. Clear all data");
            Console.WriteLine("7. Exit");

            // Prompting user to choose an option
            Console.Write("Enter your choice: ");
            int choice = int.Parse(Console.ReadLine());

            // Switch statement to handle user's choice
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
