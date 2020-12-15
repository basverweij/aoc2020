namespace AdventOfCode2020.Day03
{
    public static class TreeUtil
    {
        public static int Trees(
            string[] geo,
            int slopeX = 3,
            int slopeY = 1)
        {
            var (x, trees) = (0, 0);

            for (var y = slopeY; y < geo.Length; y += slopeY)
            {
                x = ( x + slopeX ) % geo[y].Length;

                if (geo[y][x] == '#')
                {
                    trees++;
                }
            }

            return trees;
        }
    }
}
