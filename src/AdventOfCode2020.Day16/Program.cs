using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

var lines = await File.ReadAllLinesAsync("input.txt");

var i = 0;

// read rules

var rules = new Dictionary<string, HashSet<int>>();

var values = new Dictionary<int, HashSet<string>>();

for (; i < lines.Length; i++)
{
    if (string.IsNullOrEmpty(lines[i]))
    {
        break;
    }

    var validValues = new HashSet<int>();

    var r = lines[i].Split(": ");

    var rule = r[0];

    var ranges = r[1].Split(" or ");

    foreach (var range in ranges)
    {
        var v = range.Split('-').Select(int.Parse).ToArray();

        for (var j = v[0]; j <= v[1]; j++)
        {
            validValues.Add(j);

            if (values.TryGetValue(j, out var rs))
            {
                rs.Add(rule);
            }
            else
            {
                values[j] = new()
                {
                    rule,
                };
            }
        }
    }

    rules[rule] = validValues;
}

// read ticket

i += 2;

var ticket = lines[i].Split(',').Select(int.Parse).ToArray();

// read nearby tickets

var nearbyTickets = lines[( i + 3 )..].Select(s => s.Split(',').Select(int.Parse).ToArray()).ToArray();

// get all valid values

var allValidValues = rules.Values.Aggregate(new HashSet<int>(), (a, b) => { a.UnionWith(b); return a; });

var solution1 = 0;

var validTickets = new List<int[]>();

foreach (var nearbyTicket in nearbyTickets)
{
    var errors = nearbyTicket.Where(v => !allValidValues.Contains(v)).Sum();

    if (errors == 0)
    {
        validTickets.Add(nearbyTicket);
    }
    else
    {
        solution1 += errors;
    }
}

Console.WriteLine($"Day 16 - Puzzle 1: {solution1}");

// get matching rules per field

var options = new Dictionary<int, HashSet<string>>();

for (var j = 0; j < validTickets[0].Length; j++)
{
    var fieldOptions = new HashSet<string>(rules.Keys);

    for (i = 0; i < validTickets.Count; i++)
    {
        fieldOptions.IntersectWith(values[validTickets[i][j]]);
    }

    options[j] = fieldOptions;
}

// determine fields

var done = new HashSet<int>();

while (options.Values.Any(v => v.Count > 1))
{
    var single = options.First(kvp => kvp.Value.Count == 1 && !done.Contains(kvp.Key));

    var field = single.Value.Single();

    foreach (var option in options)
    {
        if (option.Key != single.Key)
        {
            option.Value.Remove(field);
        }
    }

    done.Add(single.Key);
}

// get value for ticket

var fieldLookup = options.ToDictionary(o => o.Value.Single(), o => o.Key);

var fields = rules.Keys.Where(f => f.StartsWith("departure"));

var solution2 = 1L;

foreach (var field in fields)
{
    checked
    {
        solution2 *= ticket[fieldLookup[field]];
    }
}

Console.WriteLine($"Day 16 - Puzzle 2: {solution2}");
