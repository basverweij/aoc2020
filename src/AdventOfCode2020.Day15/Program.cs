using System;
using System.Collections.Generic;
using System.Linq;

using AdventOfCode2020.Day15;

var input = "5,2,8,16,18,0,1";

var start = input.Split(',').Select(int.Parse).ToArray();

var numbers = new Dictionary<int, NumberStats>();

var turn = 0;

foreach (var n in start)
{
    numbers[n] = new(1, ++turn);
}

var number = 0;

while (++turn <= 2020)
{
    if (numbers.TryGetValue(number, out var stats))
    {
        number = turn - stats.LastTurn;

        stats.Count++;

        stats.LastTurn = turn;
    }
    else
    {
        numbers[number] = new(1, turn);

        number = 0;
    }
}

var solution1 = numbers.Single(kvp => kvp.Value.LastTurn == turn - 1).Key;

Console.WriteLine($"Day 15 - Puzzle 1: {solution1}");

--turn;

while (++turn <= 30_000_000)
{
    if (numbers.TryGetValue(number, out var stats))
    {
        number = turn - stats.LastTurn;

        stats.Count++;

        stats.LastTurn = turn;
    }
    else
    {
        numbers[number] = new(1, turn);

        number = 0;
    }
}

var solution2 = numbers.Single(kvp => kvp.Value.LastTurn == turn - 1).Key;

Console.WriteLine($"Day 15 - Puzzle 2: {solution2}");
