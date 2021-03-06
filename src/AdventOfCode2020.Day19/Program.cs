﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

var lines = await File.ReadAllLinesAsync("input.txt");

var rules = new Dictionary<int, string>();

var todo = new Dictionary<int, string>();

var i = 0;

for (; !string.IsNullOrEmpty(lines[i]); i++)
{
    var r = lines[i].Split(": ");

    var id = int.Parse(r[0]);

    if (r[1][0] == '"' && r[1][^1] == '"')
    {
        rules.Add(id, $"{r[1][1..^1]}");
    }
    else
    {
        todo.Add(id, r[1]);
    }
}

var messages = lines[i..];

while (todo.Any())
{
    foreach (var (id, rule) in todo.ToArray())
    {
        var subRules = rule.Split(" | ");

        var ids = subRules.SelectMany(s => s.Split(' ').Select(int.Parse));

        if (ids.All(rules.ContainsKey))
        {
            // all referenced rules have already been parsed

            var parsed = string.Join(
                "|",
                subRules.Select(s => string.Join("", s.Split(' ').Select(int.Parse).Select(i => rules[i]))));

            rules.Add(id, $"({parsed})");

            todo.Remove(id);
        }
    }
}

var rule0 = new Regex($"^{rules[0]}$", RegexOptions.Compiled | RegexOptions.Singleline);

var solution1 = messages.Count(rule0.IsMatch);

Console.WriteLine($"Day 19 - Puzzle 1: {solution1}");

// rule 8 is an at-least-once repeat of rule 42

// rule 11 is a symmetric match of rules 42 and 31, see https://docs.microsoft.com/en-us/dotnet/standard/base-types/grouping-constructs-in-regular-expressions#balancing-group-definitions

rule0 = new Regex($"^({rules[42]})+(((?'Rule42'{rules[42]})+(?'Rule31-Rule42'{rules[31]})+)+(?(Rule42)(?!)))$", RegexOptions.Compiled | RegexOptions.Singleline);

var solution2 = messages.Count(rule0.IsMatch);

Console.WriteLine($"Day 19 - Puzzle 2: {solution2}");
