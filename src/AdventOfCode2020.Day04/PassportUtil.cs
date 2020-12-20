using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace AdventOfCode2020.Day04
{
    public static class PassportUtil
    {
        public static bool IsValid(
            string passport,
            bool validateContents = false)
        {
            var fields = passport
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToDictionary(
                    f => f.Split(':')[0],
                    f => f.Split(':')[1]);

            if (!_requiredFieldNames.All(fields.ContainsKey))
            {
                return false;
            }

            if (!validateContents)
            {
                // all required fields are _present_

                return true;
            }

            return fields.All(kvp => _fieldValidators[kvp.Key](kvp.Value));
        }

        #region Helpers

        private static readonly string[] _requiredFieldNames =
            {
                "byr",
                "iyr",
                "eyr",
                "hgt",
                "hcl",
                "ecl",
                "pid",
            };

        private static readonly Dictionary<string, Func<string, bool>> _fieldValidators = new Dictionary<string, Func<string, bool>>
        {
            ["byr"] = BuildIntegerValidator(1920, 2002),
            ["iyr"] = BuildIntegerValidator(2010, 2020),
            ["eyr"] = BuildIntegerValidator(2020, 2030),
            ["hgt"] = BuildLengthValidator(150, 193, 59, 76),
            ["hcl"] = BuildColorValidator(),
            ["ecl"] = BuildValuesValidator("amb", "blu", "brn", "gry", "grn", "hzl", "oth"),
            ["pid"] = BuildIdValidator(9),
            ["cid"] = s => true,
        };

        private static Func<string, bool> BuildIntegerValidator(
            int fromInclusive,
            int toInclusive)
        {
            return s => IsValidInteger(s, fromInclusive, toInclusive);
        }

        private static Func<string, bool> BuildLengthValidator(
            int fromCmInclusive,
            int toCmInclusive,
            int fromInInclusive,
            int toInInclusive)
        {
            return s =>
            {
                if (s.EndsWith("cm"))
                {
                    return IsValidInteger(s[..^2], fromCmInclusive, toCmInclusive);
                }

                if (s.EndsWith("in"))
                {
                    return IsValidInteger(s[..^2], fromInInclusive, toInInclusive);
                }

                return false;
            };
        }

        private static Func<string, bool> BuildColorValidator()
        {
            return s =>
            {
                if (s.Length < 7 || s[0] != '#')
                {
                    return false;
                }

                return int.TryParse(s[1..], NumberStyles.HexNumber, null, out _);
            };
        }

        private static Func<string, bool> BuildValuesValidator(
            params string[] values)
        {
            var lookup = new HashSet<string>(values);

            return lookup.Contains;
        }

        private static Func<string, bool> BuildIdValidator(int digits)
        {
            return s =>
            {
                if (s.Length != digits)
                {
                    return false;
                }

                return int.TryParse(s, out _);
            };
        }

        private static bool IsValidInteger(
            string s,
            int fromInclusive,
            int toInclusive)
        {
            if (!int.TryParse(s, out var i))
            {
                return false;
            }

            return i >= fromInclusive && i <= toInclusive;
        }

        #endregion
    }
}
