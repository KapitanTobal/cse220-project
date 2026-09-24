using System;
using System.Collections.Generic;
using System.Data;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();

        int userNum = -1;
        while (userNum != 0)
        {
            Console.Write("Enter a number (type 0 to quit): ");
            
            string userResponse = Console.ReadLine();
            userNum = int.Parse(userResponse);

            if (userNum != 0)
            {
                numbers.Add(userNum);
            }
        }

        //Part 1 Compute the Sum
        int sum = 0;
        foreach (int number in numbers)
        {
            sum += number;
        }

        Console.WriteLine($"The sum is: {sum}");

        //Part 2 Compute the Average
        float average = ((float)sum) / numbers.Count;
        Console.WriteLine($"The average is: {average}");

        //Part 3 Find the Max
        int max = numbers[0];

        foreach (int number in numbers)
        {
            if (number > max)
            {
                max = number;
            }
        }
        Console.WriteLine($"The max is: {max}");

    }
}