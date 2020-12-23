using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using AdventOfCode2020.Day10;

var lines = await File.ReadAllLinesAsync("input.txt");

var values = lines
    .Select(int.Parse)
    .OrderBy(a => a)
    .ToList();

values.Insert(0, 0); // charging outlet, used for solution 2

values.Add(values.Max() + 3); // built-in adapter is always 3 jolts higher than the highest adapter

var adapters = values.ToArray();

var differences = new Dictionary<int, int>();

var jolts = 0;

foreach (var adapter in adapters.Skip(1))
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

var arrangements = 1L;

for (var i = 0; i < adapters.Length - 1;)
{
    // find next anchor (i.e. two adapters that have a 3 jolt rating difference)

    var j = i + 1;

    while (adapters[j] - adapters[j - 1] != 3)
    {
        j++;
    }

    if (j - i > 2)
    {
        // get arrangements between previous and next anchors

        arrangements *= adapters[i..j].GetArrangements();
    }

    i = j;
}

Console.WriteLine($"Day 10 - Puzzle 2: {arrangements}");
