﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using AdventOfCode2020.Day04;

var lines = await File.ReadAllLinesAsync("input.txt");

var passports = new List<string>();

var passport = new StringBuilder();

foreach (var line in lines)
{
    if (string.IsNullOrWhiteSpace(line))
    {
        passports.Add(passport.ToString().Trim());

        passport.Clear();
    }

    passport.Append(' ');

    passport.Append(line);
}

passports.Add(passport.ToString().Trim());

var solution1 = passports.Count(p => PassportUtil.IsValid(p, false));

Console.WriteLine($"Day 4 - Puzzle 1: {solution1}");

var solution2 = passports.Count(p => PassportUtil.IsValid(p, true));

Console.WriteLine($"Day 4 - Puzzle 2: {solution2}");
