using System;

using AdventOfCode2020.Day23;

var input = "963275481";

var cups = CupsUtil.Play(input, 100);

var result = new char[cups.Length - 1];

var index = Array.IndexOf(cups, 1);

for (var i = 0; i < cups.Length - 1; i++)
{
    result[i] = (char)( cups[( index + i + 1 ) % cups.Length] + '0' );
}

var solution1 = new string(result);

Console.WriteLine($"Day 23 - Puzzle 1: {solution1}");

cups = CupsUtil.Play(input, 10_000_000, 1_000_000);

index = Array.IndexOf(cups, 1);

checked
{
    var solution2 = (long)cups[( index + 1 ) % cups.Length] * (long)cups[( index + 2 ) % cups.Length];

    Console.WriteLine($"Day 23 - Puzzle 2: {solution2}");
}
