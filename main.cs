using System;
using System.Linq;

class Program
{
    static void Main()
    {
        const int numDays = 5;
        const int minTemp = -30;
        const int maxTemp = 130;
        int[] temperatures = new int[numDays];

        for (int i = 0; i < numDays; i++)
        {
            int temp;
            while (true)
            {
                Console.WriteLine($"Enter temperature for day {i + 1}:");
                if (int.TryParse(Console.ReadLine(), out temp) && temp >= minTemp && temp <= maxTemp)
                {
                    temperatures[i] = temp;
                    break;
                }
                else
                {
                    Console.WriteLine($"Temperature {temp} is invalid, Please enter a valid temperature between {minTemp} and {maxTemp}");
                }
            }
        }

        bool gettingWarmer = true;
        bool gettingCooler = true;

        for (int i = 1; i < numDays; i++)
        {
            if (temperatures[i] <= temperatures[i - 1])
                gettingWarmer = false;
            if (temperatures[i] >= temperatures[i - 1])
                gettingCooler = false;
        }

        if (gettingWarmer)
        {
            Console.WriteLine("Getting warmer");
        }
        else if (gettingCooler)
        {
            Console.WriteLine("Getting cooler");
        }
        else
        {
            Console.WriteLine("It’s a mixed bag");
        }

        Console.WriteLine($"5-day Temperature [{string.Join(", ", temperatures)}]");
        double averageTemp = temperatures.Average();
        Console.WriteLine($"Average Temperature is {averageTemp:F1} degrees");
    }
}
