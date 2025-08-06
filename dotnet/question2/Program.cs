// Century Converter Program
// Converts centuries to years, days, hours, minutes, seconds, milliseconds, microseconds, nanoseconds

using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Century Converter");
        Console.WriteLine("=================\n");
        
        Console.WriteLine("Input: 1");
        Console.Write("Output: ");
        ConvertCenturies(1);
        Console.WriteLine();
        
        Console.WriteLine("Input: 5");
        Console.Write("Output: ");
        ConvertCenturies(5);
        
        Console.WriteLine("\nEnter a number of centuries to convert (or press Enter to exit): ");
        string input = Console.ReadLine();
        
        while (!string.IsNullOrEmpty(input))
        {
            if (int.TryParse(input, out int centuries) && centuries > 0)
            {
                Console.Write("Output: ");
                ConvertCenturies(centuries);
            }
            else
            {
                Console.WriteLine("Please enter a valid positive integer.");
            }
            
            Console.WriteLine("\nEnter a number of centuries to convert (or press Enter to exit): ");
            input = Console.ReadLine();
        }
    }
    
    static void ConvertCenturies(int centuries)
    {
        
        long years = (long)centuries * 100;
        
        long days = (long)(years * 365.2425);
        
        long hours = days * 24;
        long minutes = hours * 60;
        long seconds = minutes * 60;
        
        decimal milliseconds = seconds * 1000m;
        decimal microseconds = milliseconds * 1000m;
        decimal nanoseconds = microseconds * 1000m;
        
        Console.Write($"{centuries} centuries = {years} years = {days} days = {hours} hours = {minutes} minutes = {seconds} seconds = {milliseconds} milliseconds = {microseconds} microseconds = {nanoseconds} nanoseconds");
    }
}
