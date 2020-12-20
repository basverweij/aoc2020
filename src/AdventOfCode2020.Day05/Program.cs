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
    .ToArray();

var solution1 = seatIds.Max();

Console.WriteLine($"Day 5 - Puzzle 1: {solution1}");
