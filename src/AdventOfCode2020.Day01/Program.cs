using System;
using System.IO;
using System.Linq;

var lines = await File.ReadAllLinesAsync("input.txt");

var numbers = lines
    .Select(int.Parse)
    .ToArray();

var (solution1, solution2) = (0, 0);

for (var i = 0; i < numbers.Length; i++)
{
    for (var j = i + 1; j < numbers.Length; j++)
    {
        if (numbers[i] + numbers[j] == 2020)
        {
            solution1 = numbers[i] * numbers[j];
        }

        for (var k = j + 1; k < numbers.Length; k++)
        {
            if (numbers[i] + numbers[j] + numbers[k] == 2020)
            {
                solution2 = numbers[i] * numbers[j] * numbers[k];
            }
        }
    }
}

Console.WriteLine($"Day 1 - Puzzle 1: {solution1}");

Console.WriteLine($"Day 1 - Puzzle 2: {solution2}");
