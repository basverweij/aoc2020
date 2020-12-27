using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020.Day14
{
    public static class MaskUtil
    {
        public static (long and, long or)[] GenerateMasks(
            string mask)
        {
            var masks = new List<(long and, long or)>();

            var todo = new Queue<(string and, string or)>();

            // prevent 'and' mask from zero-ing out bits

            todo.Enqueue((mask.Replace('0', '1'), mask));

            while (todo.Any())
            {
                var (and, or) = todo.Dequeue();

                var index = and.IndexOf('X');

                if (index >= 0)
                {
                    // replace floating bit

                    // '0' requires 'and' mask to be 0, 'or' mask can be either 0 or 1 (using 0 to have no effect)

                    todo.Enqueue(($"{and[0..index]}0{and[( index + 1 )..]}", $"{or[0..index]}0{or[( index + 1 )..]}"));

                    // '1' requires 'or' mask to be 1, 'and' mask can be either 0 or 1 (using 1 to have no effect)

                    todo.Enqueue(($"{and[0..index]}1{and[( index + 1 )..]}", $"{or[0..index]}1{or[( index + 1 )..]}"));
                }
                else
                {
                    // all floating bits have been replaced

                    masks.Add((Convert.ToInt64(and, 2), Convert.ToInt64(or, 2)));
                }
            }

            return masks.ToArray();
        }
    }
}
