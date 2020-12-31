using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using AdventOfCode2020.Day22;

var lines = await File.ReadAllLinesAsync("input.txt");

var (stack1, stack2) = (new List<int>(), new List<int>());

var i = 0;

while (!string.IsNullOrEmpty(lines[++i]))
{
    stack1.Add(int.Parse(lines[i]));
}

i++;

while (++i < lines.Length)
{
    stack2.Add(int.Parse(lines[i]));
}

var (player1, player2) = (new Queue<int>(stack1), new Queue<int>(stack2));

GameUtil.Play(player1, player2);

var winner = player1.Any() ? player1 : player2;

var solution1 = 0;

checked
{
    for (i = winner.Count; i > 0; i--)
    {
        solution1 += i * winner.Dequeue();
    }
}

Console.WriteLine($"Day 22 - Puzzle 1: {solution1}");

(player1, player2) = (new Queue<int>(stack1), new Queue<int>(stack2));

GameUtil.PlayRecursive(player1, player2);

winner = player1.Any() ? player1 : player2;

var solution2 = 0;

checked
{
    for (i = winner.Count; i > 0; i--)
    {
        solution2 += i * winner.Dequeue();
    }
}

Console.WriteLine($"Day 22 - Puzzle 2: {solution2}");
