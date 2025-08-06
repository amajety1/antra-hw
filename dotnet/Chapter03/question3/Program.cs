// Exercise03 - Chapter 03 Solutions
// 1. FizzBuzz up to 100.
// 2. Demonstrate byte overflow in a for-loop and warn the user.
// 3. Number guessing game between 1 and 3.

using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        Console.WriteLine("=== Exercise03 Solutions ===\n");
        GreetUser();

        RunFizzBuzz();
        PrintStarPattern();
        CountTo24ByIncrements();
        DemonstrateByteOverflow();
        PlayGuessingGame();
        CalculateDaysOld();

        Console.WriteLine("\nAll tasks complete. Press any key to exit …");
        Console.ReadKey();
    }

        private static void CountTo24ByIncrements()
    {
        Console.WriteLine("--- Count to 24 by increments 1-4 ---");
        for (int outer = 1; outer <= 4; outer++)
        {
            for (int inner = 0; inner <= 24; inner += outer)
            {
                Console.Write(inner);
                if (inner + outer <= 24) Console.Write(", ");
            }
            Console.WriteLine("\n");
        }
    }

    private static void RunFizzBuzz()
    {
        Console.WriteLine("--- FizzBuzz up to 100 ---");
        for (int n = 1; n <= 100; n++)
        {
            bool fizz = n % 3 == 0;
            bool buzz = n % 5 == 0;

            if (fizz && buzz)
                Console.Write("fizzbuzz");
            else if (fizz)
                Console.Write("fizz");
            else if (buzz)
                Console.Write("buzz");
            else
                Console.Write(n);

            if (n < 100) Console.Write(", ");
        }
        Console.WriteLine("\n");
    }

    private static void DemonstrateByteOverflow()
    {
        Console.WriteLine("--- Byte Overflow Demonstration ---");
        int max = 500;
        byte previous = 0;
        for (byte i = 0; i < max; i++)
        {
            Console.Write(i + " ");
            if (i < previous)
            {
                Console.Write("\nWARNING: byte overflow occurred after 255!\n");
                break;
            }
            previous = i;
        }
        Console.WriteLine("\n");
    }

    private static void PrintStarPattern()
    {
        Console.WriteLine("--- Star Pattern ---");
        int totalLines = 5;
        for (int row = 0; row < totalLines; row++)
        {
            int starCount = 1 + row * 2;
            int spaceCount = totalLines - row - 1;

            for (int s = 0; s < spaceCount; s++)
            {
                Console.Write(' ');
            }
            for (int s = 0; s < starCount; s++)
            {
                Console.Write('*');
            }
            Console.WriteLine("\n");
        }
        Console.WriteLine();
    }

            private static void GreetUser()
    {
        Console.WriteLine("--- Greeting ---");
        DateTime current = DateTime.Now;
        int hour = current.Hour;

        if (hour >= 5 && hour < 12)
            Console.WriteLine("Good Morning\n");
        if (hour >= 12 && hour < 17)
            Console.WriteLine("Good Afternoon\n");
        if (hour >= 17 && hour < 22)
            Console.WriteLine("Good Evening\n");
        if (hour >= 22 || hour < 5)
            Console.WriteLine("Good Night\n");
    }

    private static void CalculateDaysOld()
    {
        Console.WriteLine("--- Days Old Calculator ---");
        Console.Write("Enter your birth date (yyyy-mm-dd): ");
        string? input = Console.ReadLine();
        if (!DateTime.TryParse(input, out DateTime birthDate))
        {
            Console.WriteLine("Invalid date format.");
            return;
        }

        DateTime today = DateTime.Today;
        int daysOld = (today - birthDate.Date).Days;
        Console.WriteLine($"You are {daysOld:N0} days old.");

        int daysToNextAnniversary = 10000 - (daysOld % 10000);
        DateTime nextAnniversaryDate = today.AddDays(daysToNextAnniversary);
        Console.WriteLine($"Your next 10,000-day anniversary is in {daysToNextAnniversary:N0} days on {nextAnniversaryDate:yyyy-MM-dd}.");
        Console.WriteLine();
    }

    private static void PlayGuessingGame()
    {
        Console.WriteLine("--- Guess the Number (1-3) ---");
        int correctNumber = new Random().Next(3) + 1;

        Console.Write("Guess the number (1-3): ");
        int guessedNumber = int.Parse(Console.ReadLine()!);

        if (guessedNumber < 1 || guessedNumber > 3)
        {
            Console.WriteLine("Your guess is out of range. Valid guesses are 1, 2, or 3.");
        }
        else if (guessedNumber < correctNumber)
        {
            Console.WriteLine("Too low!");
        }
        else if (guessedNumber > correctNumber)
        {
            Console.WriteLine("Too high!");
        }
        else
        {
            Console.WriteLine("Correct! Well done.");
        }
        Console.WriteLine();
    }
}
