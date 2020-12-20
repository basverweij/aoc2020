using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

var lines = await File.ReadAllLinesAsync("input.txt");

var adapters = lines
    .Select(int.Parse)
    .OrderBy(a => a)
    .ToArray();

var differences = new Dictionary<int, int>
{
    [3] = 1, // built-in adapter is always 3 jolts higher than the highest adapter
};

var jolts = 0;

foreach (var adapter in adapters)
{
    if (jolts < adapter - 3)
    {
        throw new InvalidOperationException($"no compatible adapter found for {jolts} jolts");
    }

    var difference = adapter - jolts;

    if (!differences.ContainsKey(difference))
    {
        differences[difference] = 0;
    }

    differences[difference]++;

    jolts = adapter;
}

var solution1 = differences[1] * differences[3];

Console.WriteLine($"Day 10 - Puzzle 1: {solution1}");
