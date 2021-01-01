using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020.Day24
{
    public static class TilesUtil
    {
        public static HexDirections[] Parse(
            string s)
        {
            var directions = new List<HexDirections>();

            for (var i = 0; i < s.Length; i++)
            {
                directions.Add(
                    s[i] switch
                    {
                        'n' => s[++i] == 'e' ? HexDirections.NorthEast : HexDirections.NorthWest,

                        's' => s[++i] == 'e' ? HexDirections.SouthEast : HexDirections.SouthWest,

                        'e' => HexDirections.East,

                        'w' => HexDirections.West,

                        _ => throw new ArgumentException($"invalid direction '{s[i]}'", nameof(s)),
                    });
            }

            return directions.ToArray();
        }

        public static Coordinates GetCoordinates(
            this HexDirections[] @this)
        {
            return @this.Aggregate(
                new Coordinates(0, 0),
                (a, b) => new(a.X + _directionOffsets[b].x, a.Y + _directionOffsets[b].y));
        }

        #region Helpers

        private static readonly Dictionary<HexDirections, (int x, int y)> _directionOffsets = new Dictionary<HexDirections, (int x, int y)>
        {
            [HexDirections.NorthEast] = (x: 0, y: 1),
            [HexDirections.East] = (x: 1, y: 0),
            [HexDirections.SouthEast] = (x: 1, y: -1),
            [HexDirections.SouthWest] = (x: 0, y: -1),
            [HexDirections.West] = (x: -1, y: 0),
            [HexDirections.NorthWest] = (x: -1, y: 1),
        };

        #endregion
    }

    public enum HexDirections
    {
        NorthEast, // ne
        East,      // e
        SouthEast, // se
        SouthWest, // sw
        West,      // w
        NorthWest, // nw
    }

    public record Coordinates(int X, int Y);
}
