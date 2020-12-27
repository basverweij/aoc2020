using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using AdventOfCode2020.Day14;

var lines = await File.ReadAllLinesAsync("input.txt");

var (andMask, orMask) = (( 1L << 36 ) - 1, 0L);

var memory = new Dictionary<long, long>();

foreach (var line in lines)
{
    if (line.StartsWith("mask = "))
    {
        // update mask

        andMask = Convert.ToInt64(new string(line[7..].Select(c => c == '0' ? '0' : '1').ToArray()), 2);

        orMask = Convert.ToInt64(new string(line[7..].Select(c => c == '1' ? '1' : '0').ToArray()), 2);
    }
    else
    {
        // update memory

        var address = long.Parse(line[4..line.IndexOf("]")]);

        var value = long.Parse(line[( line.IndexOf("] = ") + 4 )..]);

        value &= andMask;

        value |= orMask;

        memory[address] = value;
    }
}

var solution1 = memory.Values.Sum();

Console.WriteLine($"Day 14 - Puzzle 1: {solution1}");

memory.Clear();

var masks = new (long and, long or)[0];

foreach (var line in lines)
{
    if (line.StartsWith("mask = "))
    {
        // update masks

        masks = MaskUtil.GenerateMasks(line[7..]);
    }
    else
    {
        // update memory

        var address = long.Parse(line[4..line.IndexOf("]")]);

        var value = long.Parse(line[( line.IndexOf("] = ") + 4 )..]);

        foreach (var (and, or) in masks)
        {
            var a = address;

            a &= and;

            a |= or;

            memory[a] = value;
        }
    }
}

var solution2 = memory.Values.Sum();

Console.WriteLine($"Day 14 - Puzzle 2: {solution2}");
