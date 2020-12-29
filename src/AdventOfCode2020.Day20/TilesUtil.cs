using System;
using System.Diagnostics;
using System.Linq;

namespace AdventOfCode2020.Day20
{
    [DebuggerDisplay("Top = {Borders[0]}, Right = {Borders[1]}, Bottom = {Borders[2]}, Left = {Borders[3]}")]
    public record TileOption(int[] Borders);

    public static class TilesUtil
    {
        public static TileOption[] BuildOptions(
            this string[] @this)
        {
            // rotated 0, 90, 180, 270 degrees x original, flipped = 8 options

            var options = new TileOption[8];

            for (var f = 0; f < 2; f++) // flip
            {
                var borders = new int[4];

                for (var i = 0; i < 4; i++)
                {
                    borders[i] = @this.GetBorder(i, f == 1);
                }

                for (var i = 0; i < 4; i++) // rotate
                {
                    var optionBorders = new int[4];

                    for (var j = 0; j < 4; j++)
                    {
                        optionBorders[j] = borders[( i + j ) % 4];
                    }

                    options[4 * f + i] = new(optionBorders);
                }
            }

            return options;
        }

        private static int GetBorder(
            this string[] @this,
            int index,
            bool flipped)
        {
            var border = index switch
            {
                // top
                0 => @this[0],

                // right
                1 => new string(Enumerable.Range(0, @this.Length).Select(i => @this[i][^1]).ToArray()),

                // bottom
                2 => @this[^1],

                // left
                3 => new string(Enumerable.Range(0, @this.Length).Select(i => @this[i][0]).ToArray()),

                _ => throw new ArgumentException($"invalid index: '{index}'", nameof(index)),
            };

            if (flipped)
            {
                var c = border.ToCharArray();

                Array.Reverse(c);

                border = new string(c);
            }

            return Convert.ToInt32(new string(border.Select(c => c == '#' ? '1' : '0').ToArray()), 2);
        }
    }
}
