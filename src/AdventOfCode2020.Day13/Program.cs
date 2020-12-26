using System;
using System.IO;
using System.Linq;

using AdventOfCode2020.Day13;

var lines = await File.ReadAllLinesAsync("input.txt");

var timestamp = int.Parse(lines[0]);

var ids = lines[1]
    .Split(',')
    .Where(s => s != "x")
    .Select(int.Parse)
    .ToArray();

var solution1 = 0;

for (var t = timestamp; solution1 == 0; t++)
{
    foreach (var id in ids)
    {
        if (t % id == 0)
        {
            solution1 = ( t - timestamp ) * id;
        }
    }
}

Console.WriteLine($"Day 13 - Puzzle 1: {solution1}");

var idsWithIndex = lines[1]
    .Split(',')
    .Select((s, i) => (s, i))
    .Where(id => id.s != "x")
    .Select(id => (id: int.Parse(id.s), index: id.i))
    .ToArray();

var solution2 = EuclidUtil.Solution2(idsWithIndex);

Console.WriteLine($"Day 13 - Puzzle 2: {solution2}");
