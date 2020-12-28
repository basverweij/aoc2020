using System;
using System.Linq;

namespace AdventOfCode2020.Day18
{
    public static class MathUtil
    {
        public static long Evaluate(
            string expression,
            bool advancedPrecedence)
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

                var value = Evaluate(
                    members[( openingIndex + 1 )..closingIndex],
                    advancedPrecedence);

                Replace(ref members, openingIndex, closingIndex + 1, value.ToString());
            }

            return Evaluate(
                members,
                advancedPrecedence);
        }

        private static long Evaluate(
            string[] members,
            bool advancedPrecedence)
        {
            return advancedPrecedence ?
                EvaluateAdvanced(members) :
                EvaluateSimple(members);
        }

        private static long EvaluateSimple(
            string[] members)
        {
            var value = long.Parse(members[0]);

            for (var i = 1; i < members.Length - 1; i += 2)
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

        private static long EvaluateAdvanced(
            string[] members)
        {
            // pass 1 - addition

            for (var i = 1; i < members.Length - 1;)
            {
                if (members[i] == "+")
                {
                    checked
                    {
                        var value = long.Parse(members[i - 1]) + long.Parse(members[i + 1]);

                        Replace(ref members, i - 1, i + 2, value.ToString());
                    }
                }
                else
                {
                    i += 2;
                }
            }

            // pass 2 - multiplication

            var result = 1L;

            for (var i = 0; i < members.Length; i += 2)
            {
                checked
                {
                    result *= long.Parse(members[i]);
                }
            }

            return result;
        }

        private static void Replace<T>(
            ref T[] array,
            int fromInclusive,
            int toExclusive,
            T with)
        {
            array[fromInclusive] = with;

            Array.Copy(array, toExclusive, array, fromInclusive + 1, array.Length - toExclusive);

            Array.Resize(ref array, array.Length - ( toExclusive - fromInclusive - 1 ));
        }
    }
}
