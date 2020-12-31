using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using AdventOfCode2020.Day22;

var lines = await File.ReadAllLinesAsync("input.txt");

var (player1, player2) = (new Queue<int>(), new Queue<int>());

var i = 0;

while (!string.IsNullOrEmpty(lines[++i]))
{
    player1.Enqueue(int.Parse(lines[i]));
}

i++;

while (++i < lines.Length)
{
    player2.Enqueue(int.Parse(lines[i]));
}

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
