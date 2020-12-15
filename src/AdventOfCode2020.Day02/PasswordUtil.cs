using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2020.Day02
{
    public static class PasswordUtil
    {
        private static readonly Regex _passwordPattern = new Regex(
            "^(?<min>[0-9]+)-(?<max>[0-9]+) (?<letter>[a-z]): (?<password>[a-z]+)$",
            RegexOptions.Compiled);

        public static bool IsValid(
            string line)
        {
            var match = _passwordPattern.Match(line);

            if (!match.Success)
            {
                throw new InvalidOperationException($"invalid password: {line}");
            }

            var min = int.Parse(match.Groups[1].Value);

            var max = int.Parse(match.Groups[2].Value);

            var letter = match.Groups[3].Value[0];

            var password = match.Groups[4].Value;

            var count = password.Count(c => c == letter);

            return count >= min && count <= max;
        }
    }
}
