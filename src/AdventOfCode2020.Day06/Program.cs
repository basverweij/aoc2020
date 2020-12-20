using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

var lines = await File.ReadAllLinesAsync("input.txt");

var counts = new List<int>();

var answers = new HashSet<char>();

foreach (var line in lines)
{
    if (string.IsNullOrWhiteSpace(line))
    {
        counts.Add(answers.Count);

        answers.Clear();

        continue;
    }

    foreach (var answer in line)
    {
        answers.Add(answer);
    }
}

counts.Add(answers.Count);

var solution1 = counts.Sum();

Console.WriteLine($"Day 6 - Puzzle 1: {solution1}");
