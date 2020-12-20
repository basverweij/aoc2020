using System;
using System.IO;

using AdventOfCode2020.Day03;

var geo = await File.ReadAllLinesAsync("input.txt");

var solution1 = TreeUtil.Trees(geo);

Console.WriteLine($"Day 3 - Puzzle 1: {solution1}");

var slopes = new int[][]
{
    new int[] { 1, 1 },
    new int[] { 3, 1 },
    new int[] { 5, 1 },
    new int[] { 7, 1 },
    new int[] { 1, 2 },
};

var solution2 = 1L;

for (var i = 0; i < slopes.Length; i++)
{
    var trees = TreeUtil.Trees(geo, slopes[i][0], slopes[i][1]);

    solution2 *= trees;
}

Console.WriteLine($"Day 3 - Puzzle 2: {solution2}");
