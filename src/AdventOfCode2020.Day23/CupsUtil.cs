using System.Collections.Generic;
using System.Diagnostics;

namespace AdventOfCode2020.Day23
{
    public static class CupsUtil
    {
        public static int[] Play(
            string start,
            int rounds,
            int totalCups = 9)
        {
            var cups = new Dictionary<int, Cup>();

            cups[start[0] - '0'] = new Cup(start[0] - '0');

            for (var i = 1; i < start.Length; i++)
            {
                cups[start[i - 1] - '0'].Next = cups[start[i] - '0'] = new(start[i] - '0');
            }

            if (start.Length < totalCups)
            {
                cups[start[^1] - '0'].Next = cups[start.Length + 1] = new Cup(start.Length + 1);

                for (var i = start.Length + 2; i <= totalCups; i++)
                {
                    cups[i - 1].Next = cups[i] = new(i);
                }

                cups[totalCups].Next = cups[start[0] - '0']; // link back to first cup
            }
            else
            {
                cups[start[^1] - '0'].Next = cups[start[0] - '0']; // link back to first cup
            }

            Cup move0, move1, move2;

            var current = cups[start[0] - '0'];

            for (var i = 0; i < rounds; i++)
            {
                // cups to move

                move0 = current.Next;

                move1 = move0.Next;

                move2 = move1.Next;

                // determine destination cup

                var destinationLabel = current.Label.NextDestination(totalCups);

                while (( move0.Label == destinationLabel ) || ( move1.Label == destinationLabel ) || ( move2.Label == destinationLabel ))
                {
                    destinationLabel = destinationLabel.NextDestination(totalCups);
                }

                var destination = cups[destinationLabel];

                // exchange cups

                current.Next = move2.Next;

                (destination.Next, move2.Next) = (move0, destination.Next);

                // update current cup

                current = current.Next;
            }

            var result = new int[totalCups];

            for (var i = 0; i < totalCups; i++)
            {
                result[i] = current.Label;

                current = current.Next;
            }

            return result;
        }

        private static int NextDestination(
            this int @this,
            int totalCups)
        {
            return
                @this == 1 ?
                    totalCups :
                    @this - 1;
        }

        [DebuggerDisplay("{Label} -> {Next.Label}")]
        private class Cup
        {
            public int Label { get; set; }

            public Cup Next { get; set; }

            public Cup(
                int label)
            {
                Label = label;
            }
        }
    }
}
