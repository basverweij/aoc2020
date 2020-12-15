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
            ParseLine(line, out var min, out var max, out var letter, out var password);

            var count = password.Count(c => c == letter);

            return count >= min && count <= max;
        }

        public static bool IsValid2(
            string line)
        {
            ParseLine(line, out var min, out var max, out var letter, out var password);

            return password[min - 1] == letter ^ password[max - 1] == letter;
        }

        #region Helpers
        private static void ParseLine(string line, out int min, out int max, out char letter, out string password)
        {
            var match = _passwordPattern.Match(line);

            if (!match.Success)
            {
                throw new InvalidOperationException($"invalid password: {line}");
            }

            min = int.Parse(match.Groups[1].Value);

            max = int.Parse(match.Groups[2].Value);

            letter = match.Groups[3].Value[0];

            password = match.Groups[4].Value;
        }

        #endregion
    }
}
