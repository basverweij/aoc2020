using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using AdventOfCode2020.Day24;

var lines = await File.ReadAllLinesAsync("input.txt");

var tilesToFlip = lines.Select(TilesUtil.Parse).ToArray();

var flippedTiles = new HashSet<Coordinates>();

foreach (var tileToFlip in tilesToFlip)
{
    var coordinates = tileToFlip.GetCoordinates();

    if (flippedTiles.Contains(coordinates))
    {
        flippedTiles.Remove(coordinates);
    }
    else
    {
        flippedTiles.Add(coordinates);
    }
}

var solution1 = flippedTiles.Count;

Console.WriteLine($"Day 24 - Puzzle 1: {solution1}");

for (var i = 1; i <= 100; i++)
{
    flippedTiles = flippedTiles.Flip();
}

var solution2 = flippedTiles.Count;

Console.WriteLine($"Day 24 - Puzzle 2: {solution2}");
