using System.Linq;

namespace AdventOfCode2020.Day11
{
    public static class SeatingUtil
    {
        public static int ApplyRules(
            this char[][] @this,
            char[][] next)
        {
            var n = 0;

            for (var i = 1; i < @this.Length - 1; i++)
            {
                for (var j = 1; j < @this[i].Length - 1; j++)
                {
                    next[i][j] = @this[i][j] switch
                    {
                        'L' => @this.GetOccupied(i, j) switch
                        {
                            0 => '#',
                            _ => 'L',
                        },
                        '#' => @this.GetOccupied(i, j) switch
                        {
                            >= 4 => 'L',
                            _ => '#',
                        },
                        char c => c,
                    };

                    if (@this[i][j] != next[i][j])
                    {
                        n++;
                    }
                }
            }

            return n;
        }

        public static int ApplyRules2(
            this char[][] @this,
            char[][] next)
        {
            var n = 0;

            for (var i = 1; i < @this.Length - 1; i++)
            {
                for (var j = 1; j < @this[i].Length - 1; j++)
                {
                    next[i][j] = @this[i][j] switch
                    {
                        'L' => @this.GetOccupied2(i, j) switch
                        {
                            0 => '#',
                            _ => 'L',
                        },
                        '#' => @this.GetOccupied2(i, j) switch
                        {
                            >= 5 => 'L',
                            _ => '#',
                        },
                        char c => c,
                    };

                    if (@this[i][j] != next[i][j])
                    {
                        n++;
                    }
                }
            }

            return n;
        }

        public static int OccupiedCount(
            this char[][] @this)
        {
            var n = 0;

            for (var i = 1; i < @this.Length - 1; i++)
            {
                for (var j = 1; j < @this[i].Length; j++)
                {
                    if (@this[i][j] == '#')
                    {
                        n++;
                    }
                }
            }

            return n;
        }

        private static int GetOccupied(
            this char[][] @this,
            int i,
            int j)
        {
            return
                ( @this[i - 1][j - 1] == '#' ? 1 : 0 ) +
                ( @this[i - 1][j] == '#' ? 1 : 0 ) +
                ( @this[i - 1][j + 1] == '#' ? 1 : 0 ) +
                ( @this[i][j - 1] == '#' ? 1 : 0 ) +
                ( @this[i][j + 1] == '#' ? 1 : 0 ) +
                ( @this[i + 1][j - 1] == '#' ? 1 : 0 ) +
                ( @this[i + 1][j] == '#' ? 1 : 0 ) +
                ( @this[i + 1][j + 1] == '#' ? 1 : 0 );
        }

        private static readonly int[][] _directions =
        {
            new int[] { -1, -1 },
            new int[] { -1, 0 },
            new int[] { -1, 1 },
            new int[] { 0, -1 },
            new int[] { 0, 1 },
            new int[] { 1, -1 },
            new int[] { 1, 0 },
            new int[] { 1, 1 },
        };

        private static int GetOccupied2(
            this char[][] @this,
            int i,
            int j)
        {
            return _directions.Sum(
                d =>
                {
                    var ii = i + d[0];

                    var jj = j + d[1];

                    for (var dd = 0; ii > 0 && ii < @this.Length - 1 && jj > 0 && jj < @this[ii].Length - 1; dd++)
                    {
                        switch (@this[ii][jj])
                        {
                            case '#': return 1;
                            case 'L': return 0;
                        }

                        ii += d[0];

                        jj += d[1];
                    }

                    return 0;
                });
        }
    }
}
