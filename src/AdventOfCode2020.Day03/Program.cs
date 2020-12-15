using System;
using System.IO;

var geo = await File.ReadAllLinesAsync("input.txt");

var (x, trees) = (0, 0);

for (var y = 1; y < geo.Length; y++)
{
    x = ( x + 3 ) % geo[y].Length;

    if (geo[y][x] == '#')
    {
        trees++;
    }
}

Console.WriteLine($"Day 3 - Puzzle 1: {trees}");
