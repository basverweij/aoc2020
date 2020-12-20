using System;
using System.IO;
using System.Linq;

var lines = await File.ReadAllLinesAsync("input.txt");

var seatIds = lines
    .Select(
        s => Convert.ToInt32(
            s.Replace('F', '0')
                .Replace('B', '1')
                .Replace('L', '0')
                .Replace('R', '1'),
            2))
    .OrderBy(i => i)
    .ToArray();

var solution1 = seatIds.Max();

Console.WriteLine($"Day 5 - Puzzle 1: {solution1}");

var solution2 = 0;

for (var i = 0; i < seatIds.Length - 1; i++)
{
    if (seatIds[i + 1] - seatIds[i] == 2)
    {
        solution2 = seatIds[i] + 1;

        break;
    }
}

Console.WriteLine($"Day 5 - Puzzle 2: {solution2}");
