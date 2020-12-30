using System;
using System.Diagnostics;
using System.Linq;

namespace AdventOfCode2020.Day20
{
    [DebuggerDisplay("Top = {Borders[0]}, Right = {Borders[1]}, Bottom = {Borders[2]}, Left = {Borders[3]}")]
    public record TileOption(int Id, int[] Borders, char[][] Tile);

    public static class TilesUtil
    {
        public static TileOption[] BuildOptions(
            this char[][] @this,
            int id)
        {
            var options = new TileOption[8];

            for (var flipped = 0; flipped < 2; flipped++)
            {
                for (var rotated = 0; rotated < 4; rotated++)
                {
                    var permutation = @this.Permutate(flipped == 1, rotated);

                    var borders = Enumerable.Range(0, 4).Select(permutation.GetBorder).ToArray();

                    options[flipped * 4 + rotated] = new(
                        id,
                        borders,
                        permutation);
                }
            }

            return options;
        }

        #region Helpers

        public static char[][] Permutate(
            this char[][] @this,
            bool flipped,
            int rotated)
        {
            var n = @this.Length;

            var permutation = flipped switch
            {
                // original
                false => rotated switch
                {
                    // 0 degrees
                    0 => @this,

                    // 90 degrees clock-wise
                    1 => Enumerable
                        .Range(0, n)
                        .Select(
                            i => Enumerable
                                .Range(1, n)
                                .Select(j => @this[n - j][i])
                                .ToArray())
                        .ToArray(),

                    // 180 degrees
                    2 => Enumerable
                        .Range(1, n)
                        .Select(
                            i => Enumerable
                                .Range(1, n)
                                .Select(j => @this[n - i][n - j])
                                .ToArray())
                        .ToArray(),

                    // 270 degrees clock-wise
                    3 => Enumerable
                        .Range(1, n)
                        .Select(
                            i => Enumerable
                                .Range(0, n)
                                .Select(j => @this[j][n - i])
                                .ToArray())
                        .ToArray(),

                    _ => throw new ArgumentException($"invalid value '{rotated}'", nameof(rotated)),
                },

                // flipped
                true => rotated switch
                {
                    // 0 degrees
                    0 => Enumerable
                        .Range(0, n)
                        .Select(
                            i => Enumerable
                                .Range(1, n)
                                .Select(j => @this[i][n - j])
                                .ToArray())
                        .ToArray(),

                    // 90 degrees clock-wise
                    1 => Enumerable
                        .Range(1, n)
                        .Select(
                            i => Enumerable
                                .Range(1, n)
                                .Select(j => @this[n - j][n - i])
                                .ToArray())
                        .ToArray(),

                    // 180 degrees
                    2 => Enumerable
                        .Range(1, n)
                        .Select(
                            i => Enumerable
                                .Range(0, n)
                                .Select(j => @this[n - i][j])
                                .ToArray())
                        .ToArray(),

                    // 270 degrees clock-wise
                    3 => Enumerable
                        .Range(0, n)
                        .Select(
                            i => Enumerable
                                .Range(0, n)
                                .Select(j => @this[j][i])
                                .ToArray())
                        .ToArray(),

                    _ => throw new ArgumentException($"invalid value '{rotated}'", nameof(rotated)),
                },
            };

            return permutation;
        }

        private static int GetBorder(
            this char[][] @this,
            int index)
        {
            var border = index switch
            {
                // top
                0 => @this[0],

                // right
                1 => Enumerable.Range(0, @this.Length).Select(i => @this[i][^1]).ToArray(),

                // bottom
                2 => @this[^1],

                // left
                3 => Enumerable.Range(0, @this.Length).Select(i => @this[i][0]).ToArray(),

                _ => throw new ArgumentException($"invalid index: '{index}'", nameof(index)),
            };

            return Convert.ToInt32(new string(border.Select(c => c == '#' ? '1' : '0').ToArray()), 2);
        }

        #endregion
    }
}
