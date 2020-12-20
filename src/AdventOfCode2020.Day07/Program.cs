using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using AdventOfCode2020.Day07;

var lines = await File.ReadAllLinesAsync("input.txt");

var rules = lines.Select(RulesUtil.ParseRule).ToArray();

var containedBy = new Dictionary<string, HashSet<string>>();

foreach (var rule in rules)
{
    foreach (var (color, _) in rule.contains)
    {
        if (!containedBy.ContainsKey(color))
        {
            containedBy[color] = new();
        }

        containedBy[color].Add(rule.color);
    }
}

var canContainShinyGold = new HashSet<string>();

var todo = new Queue<string>();

todo.Enqueue("shiny gold");

while (todo.Any())
{
    var color = todo.Dequeue();

    if (!containedBy.TryGetValue(color, out var containingColors))
    {
        continue;
    }

    foreach (var containingColor in containingColors)
    {
        if (canContainShinyGold.Contains(containingColor))
        {
            continue;
        }

        canContainShinyGold.Add(containingColor);

        todo.Enqueue(containingColor);
    }
}

var solution1 = canContainShinyGold.Count;

Console.WriteLine($"Day 7 - Puzzle 1: {solution1}");

var containing = rules.ToDictionary(r => r.color, r => r.contains);

var solution2 = containing.GetContainingCountForColor("shiny gold") - 1; // exclude the outer-most bag

Console.WriteLine($"Day 7 - Puzzle 2: {solution2}"); // FIXME 21214 is too low, 30900 is too high
