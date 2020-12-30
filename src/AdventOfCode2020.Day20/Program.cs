using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using AdventOfCode2020.Day20;

var lines = await File.ReadAllLinesAsync("input.txt");

var tiles = new Dictionary<int, char[][]>();

for (var i = 0; i < lines.Length; i += 12)
{
    var id = int.Parse(lines[i][5..^1]);

    var tile = lines[( i + 1 )..( i + 11 )].Select(s => s.ToCharArray()).ToArray();

    tiles[id] = tile;
}

// build all tile options

var options = tiles.ToDictionary(
    kvp => kvp.Key,
    kvp => kvp.Value.BuildOptions(kvp.Key));

// group border values with tile ids

var borderValues = options
    .SelectMany(
        kvp => kvp.Value
            .SelectMany(o => o.Borders)
            .Distinct()
            .Select(b => (id: kvp.Key, border: b)))
    .GroupBy(b => b.border)
    .ToDictionary(g => g.Key, g => g.Select(b => b.id).ToArray());

// edge tiles have at least one border value that has a single id

var edgeBorderValues = borderValues.Where(kvp => kvp.Value.Length == 1).Select(kvp => kvp.Key).ToHashSet();

// corner tiles have exactly 2 borders with a unique value
// we're searching for 4 as there are two solutions (the complete puzzle can be flipped)

var cornerTiles = options.Where(kvp => kvp.Value.SelectMany(o => o.Borders).Distinct().Count(edgeBorderValues.Contains) == 4).Select(kvp => kvp.Key).ToArray();

checked
{
    var solution1 = cornerTiles.Aggregate(1L, (a, b) => a * b);

    Console.WriteLine($"Day 20 - Puzzle 1: {solution1}");
}

// start building the puzzle from the top-left corner

var topLeftCornerTile = cornerTiles.First(id => options[id].Any(o => edgeBorderValues.Contains(o.Borders[0]) && edgeBorderValues.Contains(o.Borders[3])));

var topLeftCornerOption = options[topLeftCornerTile].First(o => edgeBorderValues.Contains(o.Borders[0]) && edgeBorderValues.Contains(o.Borders[3]));

var n = (int)Math.Sqrt(tiles.Count);

var puzzle = new TileOption[n, n];

puzzle[0, 0] = topLeftCornerOption;

for (var i = 0; i < n; i++)
{
    if (i > 0)
    {
        // find first option in the next row

        var v = puzzle[i - 1, 0].Borders[2]; // bottom border value of first tile in previous row

        var id = borderValues[v].Single(t => t != puzzle[i - 1, 0].Id); // other tile with same border value

        puzzle[i, 0] = options[id].Single(o => o.Borders[0] == v); // option with matching top border value
    }

    for (var j = 1; j < n; j++)
    {
        var v = puzzle[i, j - 1].Borders[1]; // right border value of previous tile in current row

        var id = borderValues[v].Single(t => t != puzzle[i, j - 1].Id); // other tile with same border value

        puzzle[i, j] = options[id].Single(o => o.Borders[3] == v); // option with matching left border value
    }
}

var image = new char[8 * n][];

for (var i = 0; i < n; i++)
{
    for (var y = 0; y < 8; y++)
    {
        image[i * 8 + y] = new char[8 * n];

        for (var j = 0; j < n; j++)
        {
            for (var x = 0; x < 8; x++)
            {
                image[i * 8 + y][j * 8 + x] = puzzle[i, j].Tile[1 + y][1 + x];
            }
        }
    }
}

var permutation = Array.Empty<char[]>();

for (var flipped = 0; flipped < 2; flipped++)
{
    for (var rotated = 0; rotated < 4; rotated++)
    {
        permutation = image.Permutate(flipped == 1, rotated);

        if (permutation.FindMonsters())
        {
            break;
        }
    }
}

var solution2 = permutation.Sum(r => r.Count(c => c == '#'));

Console.WriteLine($"Day 20 - Puzzle 2: {solution2}");
