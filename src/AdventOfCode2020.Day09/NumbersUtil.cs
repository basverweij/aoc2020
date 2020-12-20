using System.Collections.Generic;

namespace AdventOfCode2020.Day09
{
    public static class NumbersUtil
    {
        public static bool IsValid(
            this ISet<long> @this,
            long number)
        {
            foreach (var i in @this)
            {
                foreach (var j in @this)
                {
                    if (i == j)
                    {
                        // numbers must be different

                        continue;
                    }

                    if (i + j == number)
                    {
                        // valid number

                        return true;
                    }

                    if (i + j > number)
                    {
                        // no more valid combinations w/ current i

                        break;
                    }
                }
            }

            return false;
        }
    }
}
