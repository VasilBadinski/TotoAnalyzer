using System;
using System.Collections.Generic;
using System.Linq;

public class Visualizer
{
    public void PrintBarChart(
        Dictionary<int, int> numbers,
        int maxBarWidth = 20)
    {
        Console.WriteLine();

        if (!numbers.Any())
            return;

        int maxValue = numbers.Max(x => x.Value);

        foreach (var item in numbers)
        {
            int barLength = (int)Math.Round(
                (double)item.Value / maxValue * maxBarWidth);

            string bar = new string('#', barLength);

            Console.WriteLine(
                $"{item.Key,2} | {bar.PadRight(maxBarWidth)} {item.Value}");
        }

        Console.WriteLine();
    }

    public void PrintHeatMap(Dictionary<int, int> frequencies)
    {
        if (!frequencies.Any())
            return;

        var ordered = frequencies
            .OrderByDescending(x => x.Value)
            .ToList();

        int total = ordered.Count;

        int hotCount = (int)Math.Ceiling(total * 0.3);
        int coldCount = (int)Math.Ceiling(total * 0.3);

        var hotNumbers = ordered
            .Take(hotCount)
            .Select(x => x.Key)
            .ToHashSet();

        var coldNumbers = ordered
            .Skip(total - coldCount)
            .Select(x => x.Key)
            .ToHashSet();

        Console.WriteLine("Heat Map:");
        Console.WriteLine();

        for (int i = 1; i <= 49; i++)
        {
            if (hotNumbers.Contains(i))
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            else if (coldNumbers.Contains(i))
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }

            Console.Write($"{i,2} ");

            Console.ResetColor();

            if (i % 7 == 0)
                Console.WriteLine();
        }

        Console.WriteLine();
    }
}