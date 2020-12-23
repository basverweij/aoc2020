using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020.Day10
{
    public static class AdaptersUtil
    {
        public static long GetArrangements(
            this int[] @this)
        {
            var n = 0;

            var todo = new Queue<int>();

            todo.Enqueue(0);

            while (todo.Any())
            {
                var i = todo.Dequeue();

                for (var j = i + 1; j < i + 4; j++)
                {
                    if (j == @this.Length - 1)
                    {
                        n++;

                        break;
                    }

                    if (@this[j] - @this[i] > 3)
                    {
                        break;
                    }

                    todo.Enqueue(j);
                }
            }

            return n;
        }
    }
}
