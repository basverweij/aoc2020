using System;
using System.Collections.Generic;
using System.Linq;

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

        public static long EncryptionWeakness(
            this long[] @this,
            long invalid)
        {
            for (var i = 0; i < @this.Length; i++)
            {
                var sum = @this[i];

                for (var j = i + 1; j < @this.Length; j++)
                {
                    sum += @this[j];

                    if (sum == invalid)
                    {
                        var min = @this[i..j].Min();

                        var max = @this[i..j].Max();

                        return min + max;
                    }

                    if (sum > invalid)
                    {
                        break;
                    }
                }
            }

            throw new InvalidOperationException("encryption weakness not found");
        }
    }
}
