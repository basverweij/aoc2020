using System.Linq;

namespace AdventOfCode2020.Day17
{
    public static class ConwayUtil
    {
        public static bool IsActiveAfterCycle(
            this bool[,,] @this,
            int d,
            int h,
            int w)
        {
            var activeNeighbours = _neighbours.Select(idx => @this[d + idx[0], h + idx[1], w + idx[2]] ? 1 : 0).Sum();

            if (@this[d, h, w])
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

        #endregion
    }
}
