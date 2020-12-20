using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

var lines = await File.ReadAllLinesAsync("input.txt");

var counts = new List<int>();

var answers = new HashSet<char>();

var everyoneCounts = new List<int>();

var everyoneAnswers = new HashSet<char>();

foreach (var line in lines)
{
    if (string.IsNullOrWhiteSpace(line))
    {
        counts.Add(answers.Count);

        answers.Clear();

        everyoneCounts.Add(everyoneAnswers.Count);

        everyoneAnswers.Clear();

        continue;
    }

    if (answers.Any())
    {
        everyoneAnswers.IntersectWith(line);
    }
    else
    {
        // first line of new group

        everyoneAnswers.UnionWith(line);
    }


    answers.UnionWith(line);
}

counts.Add(answers.Count);

everyoneCounts.Add(everyoneAnswers.Count);

var solution1 = counts.Sum();

Console.WriteLine($"Day 6 - Puzzle 1: {solution1}");

var solution2 = everyoneCounts.Sum();

Console.WriteLine($"Day 6 - Puzzle 2: {solution2}");
