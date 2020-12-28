using System;
using System.IO;
using System.Linq;

using AdventOfCode2020.Day18;

var lines = await File.ReadAllLinesAsync("input.txt");

var solution1 = lines.Select(s => MathUtil.Evaluate(s, false)).Sum();

Console.WriteLine($"Day 18 - Puzzle 1: {solution1}");

var solution2 = lines.Select(s => MathUtil.Evaluate(s, true)).Sum();

Console.WriteLine($"Day 18 - Puzzle 2: {solution2}");
