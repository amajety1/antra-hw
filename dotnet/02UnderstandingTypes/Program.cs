// Understanding Types in C#
// This program displays the number of bytes, minimum and maximum values for various numeric types

using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("C# Numeric Types - Memory Size and Value Ranges\n");
        Console.WriteLine("{0,-10} {1,-10} {2,-30} {3,-30}", "Type", "Bytes", "Minimum Value", "Maximum Value");
        Console.WriteLine(new string('-', 80));

        // sbyte
        Console.WriteLine("{0,-10} {1,-10} {2,-30} {3,-30}", 
            "sbyte", sizeof(sbyte), sbyte.MinValue, sbyte.MaxValue);
        
        // byte
        Console.WriteLine("{0,-10} {1,-10} {2,-30} {3,-30}", 
            "byte", sizeof(byte), byte.MinValue, byte.MaxValue);
        
        // short
        Console.WriteLine("{0,-10} {1,-10} {2,-30} {3,-30}", 
            "short", sizeof(short), short.MinValue, short.MaxValue);
        
        // ushort
        Console.WriteLine("{0,-10} {1,-10} {2,-30} {3,-30}", 
            "ushort", sizeof(ushort), ushort.MinValue, ushort.MaxValue);
        
        // int
        Console.WriteLine("{0,-10} {1,-10} {2,-30} {3,-30}", 
            "int", sizeof(int), int.MinValue, int.MaxValue);
        
        // uint
        Console.WriteLine("{0,-10} {1,-10} {2,-30} {3,-30}", 
            "uint", sizeof(uint), uint.MinValue, uint.MaxValue);
        
        // long
        Console.WriteLine("{0,-10} {1,-10} {2,-30} {3,-30}", 
            "long", sizeof(long), long.MinValue, long.MaxValue);
        
        // ulong
        Console.WriteLine("{0,-10} {1,-10} {2,-30} {3,-30}", 
            "ulong", sizeof(ulong), ulong.MinValue, ulong.MaxValue);
        
        // float
        Console.WriteLine("{0,-10} {1,-10} {2,-30} {3,-30}", 
            "float", sizeof(float), float.MinValue, float.MaxValue);
        
        // double
        Console.WriteLine("{0,-10} {1,-10} {2,-30} {3,-30}", 
            "double", sizeof(double), double.MinValue, double.MaxValue);
        
        // decimal
        Console.WriteLine("{0,-10} {1,-10} {2,-30} {3,-30}", 
            "decimal", sizeof(decimal), decimal.MinValue, decimal.MaxValue);
        
        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }
}
