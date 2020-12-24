using System;
using System.IO;
using System.Linq;

using AdventOfCode2020.Day12;

var lines = await File.ReadAllLinesAsync("input.txt");

var instructions = lines.Select(InstructionsUtil.Parse).ToArray();

var direction = 0; // 0 = E, 1 = S, 2 = W, 3 = N

var (x, y) = (0, 0);

foreach (var instruction in instructions)
{
    instruction.Apply(ref direction, ref x, ref y);
}

var solution1 = Math.Abs(x) + Math.Abs(y);

Console.WriteLine($"Day 12 - Puzzle 1: {solution1}");
