using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise4 Project.");
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        List<int> numbers = new List<int>();
        int input;

        do
        {
            Console.Write("Enter number: ");
            input = int.Parse(Console.ReadLine());

            if (input != 0)
            {
                numbers.Add(input);
            }
        } while (input != 0);

        if (numbers.Count > 0)
        {
            Console.WriteLine($"The sum is: {numbers.Sum()}");
            Console.WriteLine($"The average is: {numbers.Average()}");
            Console.WriteLine($"The Largest number: {numbers.Max()}");

            var positiveNumbers = numbers.Where(n => n > 0);
            if (positiveNumbers.Any())
            {
                Console.WriteLine($"The smallest positive number is: {positiveNumbers.Min()}");
            }

            numbers.Sort();
            Console.WriteLine("The sorted list is:");
            foreach (int num in numbers)
            {
                Console.WriteLine(num);
            }
        }
        else
        {
            Console.WriteLine("No numbers were entered.");
        }
    }
}