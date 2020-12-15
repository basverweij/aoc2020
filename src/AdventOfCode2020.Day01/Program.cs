using System;
using System.IO;
using System.Linq;

var lines = await File.ReadAllLinesAsync("input.txt");

var numbers = lines
    .Select(int.Parse)
    .ToArray();

for (var i = 0; i < numbers.Length; i++)
{
    for (var j = i + 1; j < numbers.Length; j++)
    {
        if (numbers[i] + numbers[j] == 2020)
        {
            var solution = numbers[i] * numbers[j];

            Console.WriteLine($"Day 01 - Puzzle 1: {solution}");

            return;
        }
    }
}