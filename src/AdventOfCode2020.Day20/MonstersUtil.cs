using System.Linq;

namespace AdventOfCode2020.Day20
{
    public static class MonstersUtil
    {
        public static bool FindMonsters(
            this char[][] @this)
        {
            bool found = false;

            for (var i = 0; i < @this.Length; i++)
            {
                for (var j = 0; j < @this[i].Length; j++)
                {
                    if (_monsterPattern.All(p => @this.Matches(i, j, p)))
                    {
                        // found a monster

                        found = true;

                        // mark monster

                        foreach (var (y, x) in _monsterPattern)
                        {
                            @this[i + y][j + x] = 'O';
                        }
                    }
                }
            }

            return found;
        }

        private static bool Matches(
            this char[][] @this,
            int i,
            int j,
            (int y, int x) pattern)
        {
            if (( i + pattern.y >= @this.Length ) ||
                ( j + pattern.x >= @this[i + pattern.y].Length ))
            {
                // pattern outside image bounds

                return false;
            }

            return @this[i + pattern.y][j + pattern.x] == '#';
        }

        private static readonly (int x, int y)[] _monsterPattern = new (int y, int x)[]
            {
                ( 0, 18 ),
                ( 1, 0 ),
                ( 1, 5 ),
                ( 1, 6 ),
                ( 1, 11 ),
                ( 1, 12 ),
                ( 1, 17 ),
                ( 1, 18 ),
                ( 1, 19 ),
                ( 2, 1 ),
                ( 2, 4 ),
                ( 2, 7 ),
                ( 2, 10 ),
                ( 2, 13 ),
                ( 2, 16 ),
            };
    }
}
