using System.Collections.Generic;

namespace AdventOfCode2020.Day12
{
    public static class InstructionsUtil
    {
        public static (char instruction, int number) Parse(
            string s)
        {
            var i = s[0];

            var n = int.Parse(s[1..]);

            if (i == 'L')
            {
                n = 4 - ( n / 90 ); // rotate counter clock-wise
            }
            else if (i == 'R')
            {
                n /= 90; // rotate clock-wise
            }

            return (i, n);
        }

        private static readonly int[,] _directionVectors = new int[4, 2]
        {
            { 1, 0 }, // E
            { 0, 1 }, // S
            { -1, 0 }, // W
            { 0, -1 }, // N
        };

        private static readonly Dictionary<char, int> _instructionLookup = new Dictionary<char, int>
        {
            ['E'] = 0,
            ['S'] = 1,
            ['W'] = 2,
            ['N'] = 3,
        };

        public static void Apply(
            this (char instruction, int number) @this,
            ref int direction,
            ref int x,
            ref int y)
        {
            int d;

            switch (@this.instruction)
            {
                case 'L' or 'R':

                    // only change direction

                    direction = ( direction + @this.number ) % 4;

                    return;

                case 'F':

                    // move forward

                    d = direction;

                    break;

                default:

                    // move in specified direction

                    d = _instructionLookup[@this.instruction];

                    break;
            }

            x += _directionVectors[d, 0] * @this.number;

            y += _directionVectors[d, 1] * @this.number;
        }
    }
}
