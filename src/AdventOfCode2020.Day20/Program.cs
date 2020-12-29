using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using AdventOfCode2020.Day20;

var lines = await File.ReadAllLinesAsync("input.txt");

var tiles = new Dictionary<int, string[]>();

for (var i = 0; i < lines.Length; i += 12)
{
    var id = int.Parse(lines[i][5..^1]);

    var tile = lines[( i + 1 )..( i + 11 )];

    tiles[id] = tile;
}

var options = tiles.ToDictionary(
    kvp => kvp.Key,
    kvp => kvp.Value.BuildOptions());

var borderCounts = options.Values.SelectMany(o => o.SelectMany(o => o.Borders).Distinct()).GroupBy(b => b).ToDictionary(g => g.Key, g => g.Count());

// border tiles have at least one border that has a unique value

var borderTiles = borderCounts.Where(kvp => kvp.Value == 1).Select(kvp => kvp.Key).ToHashSet();

// corner tiles have exactly 2 borders with a unique value
// we're searching for 4 as there are two solutions (the complete puzzle can be flipped)

var cornerTiles = options.Where(kvp => kvp.Value.SelectMany(o => o.Borders).Distinct().Count(borderTiles.Contains) == 4).Select(kvp => kvp.Key).ToArray();

var solution1 = cornerTiles.Aggregate(1L, (a, b) => a * b);

Console.WriteLine($"Day 20 - Puzzle 1: {solution1}");
