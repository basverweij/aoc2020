using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using AdventOfCode2020.Day09;

var lines = await File.ReadAllLinesAsync("input.txt");

var preamble = lines.Take(25).Select(long.Parse).ToArray();

var numbers = lines.Select(long.Parse).ToArray();

var window = new Queue<long>(preamble);

var sorted = new SortedSet<long>(preamble);

var solution1 = 0L;

foreach (var number in numbers.Skip(25))
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

var solution2 = numbers.EncryptionWeakness(solution1);

Console.WriteLine($"Day 9 - Puzzle 2: {solution2}");
