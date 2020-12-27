using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

var lines = await File.ReadAllLinesAsync("input.txt");

var i = 0;

// read rules

var rules = new Dictionary<string, HashSet<int>>();

for (; i < lines.Length; i++)
{
    if (string.IsNullOrEmpty(lines[i]))
    {
        break;
    }

    var validValues = new HashSet<int>();

    var r = lines[i].Split(": ");

    var ranges = r[1].Split(" or ");

    foreach (var range in ranges)
    {
        var v = range.Split('-').Select(int.Parse).ToArray();

        for (var j = v[0]; j <= v[1]; j++)
        {
            validValues.Add(j);
        }
    }

    rules[r[0]] = validValues;
}

// read ticket

i += 2;

var ticket = lines[i];

// read nearby tickets

var nearbyTickets = lines[( i + 3 )..].Select(s => s.Split(',').Select(int.Parse).ToArray()).ToArray();

// get all valid values

var allValidValues = rules.Values.Aggregate(new HashSet<int>(), (a, b) => { a.UnionWith(b); return a; });

var solution1 = 0;

foreach (var nearbyTicket in nearbyTickets)
{
    solution1 += nearbyTicket.Where(v => !allValidValues.Contains(v)).Sum();
}

Console.WriteLine($"Day 16 - Puzzle 1: {solution1}");
