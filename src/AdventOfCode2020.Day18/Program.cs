using System;
using System.IO;
using System.Linq;

using AdventOfCode2020.Day18;

var lines = await File.ReadAllLinesAsync("input.txt");

var solution1 = lines.Select(MathUtil.Evaluate).Sum();

Console.WriteLine($"Day 18 - Puzzle 1: {solution1}");
