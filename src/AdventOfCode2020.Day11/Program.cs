using System;
using System.IO;
using System.Linq;

using AdventOfCode2020.Day11;

var lines = ( await File
    .ReadAllLinesAsync("input.txt") )
    .Select(s => $".{s}.") // add floor tiles left and right to remove need for boundary checks
    .ToList();

// add floor tiles above and below to remove need for boundary checks

lines.Insert(0, new string('.', lines[0].Length));

lines.Add(new string('.', lines[0].Length));

var current = lines.Select(s => s.ToCharArray()).ToArray();

var next = lines.Select(s => s.ToCharArray()).ToArray();

while (current.ApplyRules(next) > 0)
{
    (current, next) = (next, current);
}

var solution1 = current.GetOccupied();

Console.WriteLine($"Day 11 - Puzzle 1: {solution1}");
