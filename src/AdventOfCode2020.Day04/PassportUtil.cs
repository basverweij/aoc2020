using System;
using System.Linq;

namespace AdventOfCode2020.Day04
{
    public static class PassportUtil
    {
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

        // "cid",

        public static bool IsValid(
            string passport)
        {
            var fields = passport
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToDictionary(
                    f => f.Split(':')[0],
                    f => f.Split(':')[1]);

            return _requiredFieldNames.All(fields.ContainsKey);
        }
    }
}
