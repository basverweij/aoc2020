using System;
using System.IO;

using AdventOfCode2020.Day17;

var lines = await File.ReadAllLinesAsync("input.txt");

const int cycles = 6;

// calculate dimensions, adding 2 for padding to skip index checks

var height = lines.Length + 2 * cycles + 2;

var width = lines[0].Length + 2 * cycles + 2;

var depth = 1 + 2 * cycles + 2;

var world = new bool[depth, height, width];

for (var h = 0; h < lines.Length; h++)
{
    for (var w = 0; w < lines[h].Length; w++)
    {
        world[cycles + 1, h + cycles + 1, w + cycles + 1] = lines[h][w] == '#';
    }
}

for (var cycle = 1; cycle <= cycles; cycle++)
{
    var newWorld = new bool[depth, height, width];

    for (var d = cycles - cycle + 1; d <= depth - cycles - 2 + cycle; d++)
    {
        for (var h = cycles - cycle + 1; h <= height - cycles - 2 + cycle; h++)
        {
            for (var w = cycles - cycle + 1; w <= width - cycles - 2 + cycle; w++)
            {
                newWorld[d, h, w] = world.IsActiveAfterCycle(d, h, w);
            }
        }
    }

    world = newWorld;
}

var solution1 = 0;

for (var d = 1; d < depth - 1; d++)
{
    for (var h = 1; h < height - 1; h++)
    {
        for (var w = 1; w < width - 1; w++)
        {
            if (world[d, h, w])
            {
                solution1++;
            }
        }
    }
}

Console.WriteLine($"Day 17 - Puzzle 1: {solution1}");
