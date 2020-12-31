using System;
using System.Linq;

namespace AdventOfCode2020.Day23
{
    public static class CupsUtil
    {
        public static string Play(
            string start,
            int rounds)
        {
            var cups = start.ToCharArray().Select(c => c - '0').ToArray();

            var n = cups.Length;

            var move = new int[3];

            var current = 0;

            for (int i = 0; i < rounds; i++)
            {
                // cups to move

                move[0] = cups[( current + 1 ) % n];

                move[1] = cups[( current + 2 ) % n];

                move[2] = cups[( current + 3 ) % n];

                // determine destination cup

                var destination = cups[current].NextDestination(n);

                while (( move[0] == destination ) || ( move[1] == destination ) || ( move[2] == destination ))
                {
                    destination = destination.NextDestination(n);
                }

                // exchange cups

                for (var j = 1; j < n; j++)
                {
                    cups[( current + j ) % n] = cups[( current + j + 3 ) % n];

                    if (cups[( current + j ) % n] == destination)
                    {
                        cups[( current + j + 1 ) % n] = move[0];

                        cups[( current + j + 2 ) % n] = move[1];

                        cups[( current + j + 3 ) % n] = move[2];

                        break;
                    }
                }

                // update current cup

                current = ( current + 1 ) % n;
            }

            var result = new char[n - 1];

            var index = Array.IndexOf(cups, 1);

            for (var i = 0; i < n - 1; i++)
            {
                result[i] = (char)( cups[( index + i + 1 ) % n] + '0' );
            }

            return new string(result);
        }

        private static int NextDestination(
            this int @this,
            int n)
        {
            return
                @this == 1 ?
                    n :
                    @this - 1;
        }
    }
}
