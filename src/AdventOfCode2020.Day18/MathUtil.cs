using System;
using System.Linq;

namespace AdventOfCode2020.Day18
{
    public static class MathUtil
    {
        public static long Evaluate(
            string expression)
        {
            var members = expression
                .ToCharArray()
                .Where(m => m != ' ')
                .Select(m => m.ToString())
                .ToArray();

            while (true)
            {
                var closingIndex = Array.IndexOf(members, ")");

                if (closingIndex == -1)
                {
                    break;
                }

                // find opening parenthesis

                var openingIndex = closingIndex - 2;

                for (; openingIndex >= 0; openingIndex--)
                {
                    if (members[openingIndex] == "(")
                    {
                        break;
                    }
                }

                // evaluate nested expressions first

                var value = EvaluateSimple(members[( openingIndex + 1 )..closingIndex]);

                members[openingIndex] = value.ToString();

                Array.Copy(members, closingIndex + 1, members, openingIndex + 1, members.Length - closingIndex - 1);

                Array.Resize(ref members, members.Length - ( closingIndex - openingIndex ));
            }

            return EvaluateSimple(members);
        }

        private static long EvaluateSimple(
            string[] members)
        {
            var value = long.Parse(members[0]);

            for (var i = 1; i < members.Length; i += 2)
            {
                var rhs = long.Parse(members[i + 1]);

                checked
                {
                    value = members[i] switch
                    {
                        "+" => value + rhs,
                        "*" => value * rhs,
                        _ => throw new ArgumentException($"invalid operator: '{members[i]}'"),
                    };
                }
            }

            return value;
        }
    }
}
