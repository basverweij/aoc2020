using System;
using System.IO;
using System.Linq;

using AdventOfCode2020.Day02;

var lines = await File.ReadAllLinesAsync("input.txt");

var solution1 = lines.Count(PasswordUtil.IsValid);

Console.WriteLine($"Day 2 - Puzzle 1: {solution1}");

