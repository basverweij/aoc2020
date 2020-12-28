using System.Linq;

namespace AdventOfCode2020.Day17
{
    public static class ConwayUtil
    {
        public static bool IsActiveAfterCycle(
            this bool[,,] @this,
            int z,
            int y,
            int x)
        {
            var activeNeighbours = _neighbours.Select(idx => @this[z + idx[0], y + idx[1], x + idx[2]] ? 1 : 0).Sum();

            if (@this[z, y, x])
            {
                // currently active

                return activeNeighbours == 2 || activeNeighbours == 3;
            }

            // currently inactive

            return activeNeighbours == 3;
        }

        public static bool IsActiveAfterCycle(
            this bool[,,,] @this,
            int w,
            int z,
            int y,
            int x)
        {
            var activeNeighbours = _neighbours4d.Select(idx => @this[w + idx[0], z + idx[1], y + idx[2], x + idx[3]] ? 1 : 0).Sum();

            if (@this[w, z, y, x])
            {
                // currently active

                return activeNeighbours == 2 || activeNeighbours == 3;
            }

            // currently inactive

            return activeNeighbours == 3;
        }

        #region Helpers

        private static readonly int[][] _neighbours = new int[][]
        {
            new int[] { -1, -1, -1 },
            new int[] { -1, -1, 0 },
            new int[] { -1, -1, 1 },
            new int[] { -1, 0, -1 },
            new int[] { -1, 0, 0 },
            new int[] { -1, 0, 1 },
            new int[] { -1, 1, -1 },
            new int[] { -1, 1, 0 },
            new int[] { -1, 1, 1 },
            new int[] { 0, -1, -1 },
            new int[] { 0, -1, 0 },
            new int[] { 0, -1, 1 },
            new int[] { 0, 0, -1 },
            new int[] { 0, 0, 1 },
            new int[] { 0, 1, -1 },
            new int[] { 0, 1, 0 },
            new int[] { 0, 1, 1 },
            new int[] { 1, -1, -1 },
            new int[] { 1, -1, 0 },
            new int[] { 1, -1, 1 },
            new int[] { 1, 0, -1 },
            new int[] { 1, 0, 0 },
            new int[] { 1, 0, 1 },
            new int[] { 1, 1, -1 },
            new int[] { 1, 1, 0 },
            new int[] { 1, 1, 1 },
        };

        private static readonly int[][] _neighbours4d = new int[][]
        {
            new int[] { -1, -1, -1, -1 },
            new int[] { -1, -1, -1, 0 },
            new int[] { -1, -1, -1, 1 },
            new int[] { -1, -1, 0, -1 },
            new int[] { -1, -1, 0, 0 },
            new int[] { -1, -1, 0, 1 },
            new int[] { -1, -1, 1, -1 },
            new int[] { -1, -1, 1, 0 },
            new int[] { -1, -1, 1, 1 },
            new int[] { -1, 0, -1, -1 },
            new int[] { -1, 0, -1, 0 },
            new int[] { -1, 0, -1, 1 },
            new int[] { -1, 0, 0, -1 },
            new int[] { -1, 0, 0, 0 },
            new int[] { -1, 0, 0, 1 },
            new int[] { -1, 0, 1, -1 },
            new int[] { -1, 0, 1, 0 },
            new int[] { -1, 0, 1, 1 },
            new int[] { -1, 1, -1, -1 },
            new int[] { -1, 1, -1, 0 },
            new int[] { -1, 1, -1, 1 },
            new int[] { -1, 1, 0, -1 },
            new int[] { -1, 1, 0, 0 },
            new int[] { -1, 1, 0, 1 },
            new int[] { -1, 1, 1, -1 },
            new int[] { -1, 1, 1, 0 },
            new int[] { -1, 1, 1, 1 },
            new int[] { 0, -1, -1, -1 },
            new int[] { 0, -1, -1, 0 },
            new int[] { 0, -1, -1, 1 },
            new int[] { 0, -1, 0, -1 },
            new int[] { 0, -1, 0, 0 },
            new int[] { 0, -1, 0, 1 },
            new int[] { 0, -1, 1, -1 },
            new int[] { 0, -1, 1, 0 },
            new int[] { 0, -1, 1, 1 },
            new int[] { 0, 0, -1, -1 },
            new int[] { 0, 0, -1, 0 },
            new int[] { 0, 0, -1, 1 },
            new int[] { 0, 0, 0, -1 },
            new int[] { 0, 0, 0, 1 },
            new int[] { 0, 0, 1, -1 },
            new int[] { 0, 0, 1, 0 },
            new int[] { 0, 0, 1, 1 },
            new int[] { 0, 1, -1, -1 },
            new int[] { 0, 1, -1, 0 },
            new int[] { 0, 1, -1, 1 },
            new int[] { 0, 1, 0, -1 },
            new int[] { 0, 1, 0, 0 },
            new int[] { 0, 1, 0, 1 },
            new int[] { 0, 1, 1, -1 },
            new int[] { 0, 1, 1, 0 },
            new int[] { 0, 1, 1, 1 },
            new int[] { 1, -1, -1, -1 },
            new int[] { 1, -1, -1, 0 },
            new int[] { 1, -1, -1, 1 },
            new int[] { 1, -1, 0, -1 },
            new int[] { 1, -1, 0, 0 },
            new int[] { 1, -1, 0, 1 },
            new int[] { 1, -1, 1, -1 },
            new int[] { 1, -1, 1, 0 },
            new int[] { 1, -1, 1, 1 },
            new int[] { 1, 0, -1, -1 },
            new int[] { 1, 0, -1, 0 },
            new int[] { 1, 0, -1, 1 },
            new int[] { 1, 0, 0, -1 },
            new int[] { 1, 0, 0, 0 },
            new int[] { 1, 0, 0, 1 },
            new int[] { 1, 0, 1, -1 },
            new int[] { 1, 0, 1, 0 },
            new int[] { 1, 0, 1, 1 },
            new int[] { 1, 1, -1, -1 },
            new int[] { 1, 1, -1, 0 },
            new int[] { 1, 1, -1, 1 },
            new int[] { 1, 1, 0, -1 },
            new int[] { 1, 1, 0, 0 },
            new int[] { 1, 1, 0, 1 },
            new int[] { 1, 1, 1, -1 },
            new int[] { 1, 1, 1, 0 },
            new int[] { 1, 1, 1, 1 },
        };
        #endregion
    }
}
