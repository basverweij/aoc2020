using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020.Day07
{
    public static class RulesUtil
    {
        public static (string color, (string color, int count)[] contains) ParseRule(
            string line)
        {
            if (line[^1] != '.')
            {
                throw new ArgumentException($"invalid line '{line}'", nameof(line));
            }

            var parts = line[..^1].Split(" bags contain ");

            if (parts.Length != 2)
            {
                throw new ArgumentException($"invalid line '{line}'", nameof(line));
            }

            if (parts[1] == "no other bags")
            {
                return (parts[0], new (string color, int count)[0]);
            }

            var contains = parts[1]
                .Split(", ")
                .Select(c =>
                {
                    var containsParts = c.Split(' ');

                    if (!int.TryParse(containsParts[0], out var count))
                    {
                        throw new ArgumentException($"invalid contains part '{c}'", nameof(c));
                    }

                    return ($"{containsParts[1]} {containsParts[2]}", count);
                })
                .ToArray();

            return (parts[0], contains);
        }

        public static int GetContainingCountForColor(
            this IReadOnlyDictionary<string, (string color, int count)[]> @this,
            string color)
        {
            if (!@this.TryGetValue(color, out var contains) ||
                contains.Length == 0)
            {
                return 1;
            }

            return 1 + contains.Sum(c => c.count * @this.GetContainingCountForColor(c.color));
        }
    }
}
