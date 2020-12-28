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

for (var y = 0; y < lines.Length; y++)
{
    for (var x = 0; x < lines[y].Length; x++)
    {
        world[cycles + 1, y + cycles + 1, x + cycles + 1] = lines[y][x] == '#';
    }
}

for (var cycle = 1; cycle <= cycles; cycle++)
{
    var newWorld = new bool[depth, height, width];

    for (var z = cycles - cycle + 1; z <= depth - cycles - 2 + cycle; z++)
    {
        for (var y = cycles - cycle + 1; y <= height - cycles - 2 + cycle; y++)
        {
            for (var x = cycles - cycle + 1; x <= width - cycles - 2 + cycle; x++)
            {
                newWorld[z, y, x] = world.IsActiveAfterCycle(z, y, x);
            }
        }
    }

    world = newWorld;
}

var solution1 = 0;

for (var z = 1; z < depth - 1; z++)
{
    for (var y = 1; y < height - 1; y++)
    {
        for (var x = 1; x < width - 1; x++)
        {
            if (world[z, y, x])
            {
                solution1++;
            }
        }
    }
}

Console.WriteLine($"Day 17 - Puzzle 1: {solution1}");

var world4d = new bool[depth, depth, height, width];

for (var y = 0; y < lines.Length; y++)
{
    for (var x = 0; x < lines[y].Length; x++)
    {
        world4d[cycles + 1, cycles + 1, y + cycles + 1, x + cycles + 1] = lines[y][x] == '#';
    }
}

for (var cycle = 1; cycle <= cycles; cycle++)
{
    var newWorld4d = new bool[depth, depth, height, width];

    for (var w = cycles - cycle + 1; w <= depth - cycles - 2 + cycle; w++)
    {
        for (var z = cycles - cycle + 1; z <= depth - cycles - 2 + cycle; z++)
        {
            for (var y = cycles - cycle + 1; y <= height - cycles - 2 + cycle; y++)
            {
                for (var x = cycles - cycle + 1; x <= width - cycles - 2 + cycle; x++)
                {
                    newWorld4d[w, z, y, x] = world4d.IsActiveAfterCycle(w, z, y, x);
                }
            }
        }
    }

    world4d = newWorld4d;
}

var solution2 = 0;

for (var w = 1; w < depth - 1; w++)
{
    for (var z = 1; z < depth - 1; z++)
    {
        for (var y = 1; y < height - 1; y++)
        {
            for (var x = 1; x < width - 1; x++)
            {
                if (world4d[w, z, y, x])
                {
                    solution2++;
                }
            }
        }
    }
}

Console.WriteLine($"Day 17 - Puzzle 2: {solution2}");
