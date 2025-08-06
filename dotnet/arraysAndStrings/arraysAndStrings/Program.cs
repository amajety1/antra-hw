// Arrays and Strings Exercises
// Tasks:
// 1. Copy an array.
// 2. Simple interactive list manager.
// 3. Find primes in range.
// 4. Rotate array k times and sum arrays.

using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        Console.WriteLine("=== Arrays and Strings ===\n");

        // Task 1
        CopyArrayDemo();
        Console.WriteLine();

        // Task 2
        ListManager();

        // Task 3 demo
        Console.WriteLine("\n--- Find Primes in Range Demo ---");
        Console.Write("Enter start number: ");
        int start = int.Parse(Console.ReadLine()!);
        Console.Write("Enter end number: ");
        int end = int.Parse(Console.ReadLine()!);
        int[] primes = FindPrimesInRange(start, end);
        Console.WriteLine($"Primes between {start} and {end}: {string.Join(", ", primes)}\n");

        // Task 4 demo
        RotateAndSumDemo();

        // Task 5 demo
        LongestEqualSequenceDemo();
        // Task 6 demo
        MostFrequentNumberDemo();
        // Task 7 string reversal demos
        ReverseStringDemo();
        // Task 8 reverse sentence words
        ReverseSentenceDemo();
        // Task 9 extract palindromes
        PalindromesDemo();
        // Task 10 parse URL
        ParseUrlDemo();

        Console.WriteLine("\nAll tasks complete. Press any key to exit …");
        Console.ReadKey();
    }

    /* ---------------- Task 1 ---------------- */
    private static void CopyArrayDemo()
    {
        Console.WriteLine("--- Array Copy Demo ---");
        int[] original = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        int[] copy = new int[original.Length];

        for (int i = 0; i < original.Length; i++)
        {
            copy[i] = original[i];
        }

        Console.WriteLine("Original: " + string.Join(", ", original));
        Console.WriteLine("Copy    : " + string.Join(", ", copy));
    }

    /* ---------------- Task 2 ---------------- */
    private static void ListManager()
    {
        Console.WriteLine("--- List Manager (Enter blank line to exit) ---");
        var items = new List<string>();
        while (true)
        {
            Console.WriteLine("Enter command (+ item, - item, or -- to clear):");
            string? input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input)) break;

            if (input.StartsWith("+ "))
            {
                string itemToAdd = input.Substring(2);
                if (!string.IsNullOrWhiteSpace(itemToAdd)) items.Add(itemToAdd.Trim());
            }
            else if (input.StartsWith("- "))
            {
                string itemToRemove = input.Substring(2).Trim();
                items.Remove(itemToRemove);
            }
            else if (input.Trim() == "--")
            {
                items.Clear();
            }
            else
            {
                Console.WriteLine("Invalid command.");
            }

            Console.WriteLine("Current list: " + (items.Count == 0 ? "<empty>" : string.Join(", ", items)));
            Console.WriteLine();
        }
    }

    /* ---------------- Task 3 ---------------- */
    static int[] FindPrimesInRange(int startNum, int endNum)
    {
        if (endNum < 2 || endNum < startNum) return Array.Empty<int>();

        bool[] isComposite = new bool[endNum + 1];
        for (int p = 2; p * p <= endNum; p++)
        {
            if (!isComposite[p])
            {
                for (int multiple = p * p; multiple <= endNum; multiple += p)
                    isComposite[multiple] = true;
            }
        }
        var primes = new List<int>();
        for (int i = Math.Max(2, startNum); i <= endNum; i++)
            if (!isComposite[i]) primes.Add(i);
        return primes.ToArray();
    }

    /* ---------------- Task 4 ---------------- */
    private static void RotateAndSumDemo()
    {
        Console.WriteLine("--- Rotate and Sum Demo ---");
        Console.WriteLine("Enter array elements separated by space:");
        int[] arr = Console.ReadLine()!.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
        Console.Write("Enter k rotations: ");
        int k = int.Parse(Console.ReadLine()!);

        int[] sum = new int[arr.Length];
        int[] temp = arr.ToArray();

        for (int r = 1; r <= k; r++)
        {
            RotateRightByOne(temp);
            for (int i = 0; i < arr.Length; i++)
                sum[i] += temp[i];
        }

        Console.WriteLine("Sum after rotations: " + string.Join(" ", sum));
    }

        /* ---------------- Task 5 ---------------- */
    private static void LongestEqualSequenceDemo()
    {
        Console.WriteLine("--- Longest Equal Sequence Demo ---");
        Console.WriteLine("Enter integers separated by space:");
        int[] nums = Console.ReadLine()!.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

        int bestStart = 0, bestLen = 1, currentStart = 0, currentLen = 1;
        for (int i = 1; i < nums.Length; i++)
        {
            if (nums[i] == nums[i - 1])
            {
                currentLen++;
                if (currentLen > bestLen)
                {
                    bestLen = currentLen;
                    bestStart = currentStart;
                }
            }
            else
            {
                currentStart = i;
                currentLen = 1;
            }
        }
        Console.WriteLine("Longest sequence: " + string.Join(" ", nums.Skip(bestStart).Take(bestLen)));
    }

    /* ---------------- Task 6 ---------------- */
    private static void MostFrequentNumberDemo()
    {
        Console.WriteLine("--- Most Frequent Number Demo ---");
        Console.WriteLine("Enter integers separated by space:");
        int[] nums = Console.ReadLine()!.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

        var counts = new Dictionary<int, int>();
        foreach (var n in nums)
        {
            if (!counts.ContainsKey(n)) counts[n] = 0;
            counts[n]++;
        }
        int maxFreq = counts.Values.Max();
        int mostFreq = nums.First(n => counts[n] == maxFreq); // leftmost with max freq
        Console.WriteLine($"The number {mostFreq} is the most frequent (occurs {maxFreq} times)");
    }

    /* ---------------- Task 7 ---------------- */
    private static void ReverseStringDemo()
    {
        Console.WriteLine("--- Reverse String Demo ---");
        Console.Write("Enter a string: ");
        string text = Console.ReadLine()!;

        // Method 1: char array
        char[] arr = text.ToCharArray();
        Array.Reverse(arr);
        string reversed1 = new string(arr);

        // Method 2: for loop backwards
        string reversed2 = string.Empty;
        for (int i = text.Length - 1; i >= 0; i--)
            reversed2 += text[i];

        Console.WriteLine("Reversed (method1): " + reversed1);
        Console.WriteLine("Reversed (method2): " + reversed2);
    }

    /* ---------------- Task 8 ---------------- */
    private static readonly char[] Separators = ".,:;=()&[]\"'\\/!? ".ToCharArray();

    private static void ReverseSentenceDemo()
    {
        Console.WriteLine("--- Reverse Sentence Words Demo ---");
        Console.WriteLine("Enter sentence:");
        string sentence = Console.ReadLine()!;

        var words = sentence.Split(Separators, StringSplitOptions.RemoveEmptyEntries);
        Array.Reverse(words);

        // Rebuild keeping separators order
        var result = new System.Text.StringBuilder();
        int wordIdx = 0;
        foreach (char c in sentence)
        {
            if (Separators.Contains(c))
                result.Append(c);
            else
            {
                // start of word: append reversed word when first char reached
                if (wordIdx < words.Length)
                {
                    result.Append(words[wordIdx]);
                    wordIdx++;
                }
                // skip remainder letters of original word in sentence iterator
                while (result.Length < sentence.Length && !Separators.Contains(sentence[result.Length]))
                {
                    // Advance original index by doing nothing (handled).
                    result.Append('\0');
                }
            }
        }
        // Simplify: easiest: use regex
        // To keep this simpler, we'll output joined reversed words with original separators using splitting.
        var parts = System.Text.RegularExpressions.Regex.Split(sentence, "([.,:;=()&\[\]\"'\\/!? ]+)");
        var outSb = new System.Text.StringBuilder();
        int w = 0;
        foreach (var part in parts)
        {
            if (part.Length == 0) continue;
            if (Separators.Contains(part[0]))
                outSb.Append(part);
            else
                outSb.Append(words[w++]);
        }
        Console.WriteLine(outSb.ToString());
    }

    /* ---------------- Task 9 ---------------- */
    private static void PalindromesDemo()
    {
        Console.WriteLine("--- Palindromes Extraction Demo ---");
        Console.WriteLine("Enter text:");
        string text = Console.ReadLine()!;
        var tokens = text.Split(Separators, StringSplitOptions.RemoveEmptyEntries);
        var palSet = new SortedSet<string>(StringComparer.OrdinalIgnoreCase);
        bool IsPalindrome(string s)
        {
            int l = 0, r = s.Length - 1;
            while (l < r)
            {
                if (char.ToLower(s[l]) != char.ToLower(s[r])) return false;
                l++; r--;
            }
            return true;
        }
        foreach (var t in tokens)
            if (t.Length > 0 && IsPalindrome(t)) palSet.Add(t);
        Console.WriteLine(string.Join(", ", palSet));
    }

    /* ---------------- Task 10 ---------------- */
    private static void ParseUrlDemo()
    {
        Console.WriteLine("--- URL Parser Demo ---");
        Console.Write("Enter URL: ");
        string url = Console.ReadLine()!;
        string protocol = string.Empty;
        string server;
        string resource = string.Empty;

        int protoIdx = url.IndexOf("://");
        if (protoIdx != -1)
        {
            protocol = url.Substring(0, protoIdx);
            url = url.Substring(protoIdx + 3);
        }
        int slashIdx = url.IndexOf('/');
        if (slashIdx != -1)
        {
            server = url.Substring(0, slashIdx);
            resource = url.Substring(slashIdx + 1);
        }
        else
        {
            server = url;
        }
        Console.WriteLine($"[protocol] = \"{protocol}\"");
        Console.WriteLine($"[server] = \"{server}\"");
        Console.WriteLine($"[resource] = \"{resource}\"");
    }

    private static void RotateRightByOne(int[] array)
    {
        int last = array[^1];
        for (int i = array.Length - 1; i > 0; i--)
            array[i] = array[i - 1];
        array[0] = last;
    }
}
