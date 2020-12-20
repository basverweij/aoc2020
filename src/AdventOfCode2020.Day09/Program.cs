using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using AdventOfCode2020.Day09;

var lines = await File.ReadAllLinesAsync("input.txt");

var preamble = lines.Take(25).Select(long.Parse).ToArray();

var numbers = lines.Skip(25).Select(long.Parse).ToArray();

var window = new Queue<long>(preamble);

var sorted = new SortedSet<long>(preamble);

var solution1 = 0L;

foreach (var number in numbers)
{
    // check whether number is valid

    if (!sorted.IsValid(number))
    {
        solution1 = number;

        break;
    }

    // advance window

    sorted.Remove(window.Dequeue());

    window.Enqueue(number);

    sorted.Add(number);
}

Console.WriteLine($"Day 9 - Puzzle 1: {solution1}");
