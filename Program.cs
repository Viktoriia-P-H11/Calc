using System;

class Calculator
{
    // Overloaded method for two numbers
    static double PerformOperation(string operation, double num1, double num2)
    {
        return operation switch
        {
            "+" => num1 + num2,
            "-" => num1 - num2,
            "*" => num1 * num2,
            "/" => num2 != 0 ? num1 / num2 : throw new DivideByZeroException("Division by zero is not allowed."),
            _ => throw new InvalidOperationException("Invalid operation.")
        };
    }

    // Overloaded method for multiple numbers
    static double PerformOperation(string operation, params double[] numbers)
    {
        if (numbers.Length < 2)
            throw new ArgumentException("At least two numbers are required for the operation.");

        double result = numbers[0];
        for (int i = 1; i < numbers.Length; i++)
        {
            result = operation switch
            {
                "+" => result + numbers[i],
                "-" => result - numbers[i],
                "*" => result * numbers[i],
                "/" => numbers[i] != 0 ? result / numbers[i] : throw new DivideByZeroException("Division by zero is not allowed."),
                _ => throw new InvalidOperationException("Invalid operation.")
            };
        }
        return result;
    }

    static void Main()
    {
        string? input;
        string? operation;
        double result;

        // Infinite loop for continuous user input
        while (true)
        {
            // Ask for the operation
            Console.WriteLine("Enter the operation (+, -, *, /) or 'exit' to quit: ");
            operation = Console.ReadLine();

            if (operation != null && operation.ToLower() == "exit")
                break;

            // Ask for the numbers
            Console.WriteLine("Enter numbers separated by commas (e.g., 1,2,3): ");
            input = Console.ReadLine();

            string[] stringNumbers = input?.Split(',') ?? new string[0];
            double[] numbers = new double[stringNumbers.Length];

            try
            {
                // Parsing the numbers
                for (int i = 0; i < stringNumbers.Length; i++)
                {
                    numbers[i] = double.Parse(stringNumbers[i].Trim());
                }

                // Call overloaded PerformOperation method
                if (operation != null)
                {
                    try
                    {
                        if (numbers.Length == 2) // Use the overloaded method for two numbers
                        {
                            result = PerformOperation(operation, numbers[0], numbers[1]);
                        }
                        else // Use the overloaded method for multiple numbers
                        {
                            result = PerformOperation(operation, numbers);
                        }
                        Console.WriteLine($"Result: {string.Join(" " + operation + " ", numbers)} = {result}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid operation. Please enter a valid operation.");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. Please enter valid numbers separated by commas.");
            }
        }

        Console.WriteLine("Ha det bra Håkon!Vær oppmerksom, kommentarer skrives overalt😊"); // Message when exiting
    }
}
