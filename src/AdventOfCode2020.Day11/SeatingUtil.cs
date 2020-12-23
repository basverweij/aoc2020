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

        public static int GetOccupied(
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
    }
}
