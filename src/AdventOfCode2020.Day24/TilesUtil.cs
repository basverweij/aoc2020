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
                (a, b) => new(a.X + _directionOffsets[a.Y % 2 == 0 ? 0 : 1][(int)b].x, a.Y + _directionOffsets[a.Y % 2 == 0 ? 0 : 1][(int)b].y));
        }

        public static HashSet<Coordinates> Flip(
            this HashSet<Coordinates> @this)
        {
            var flipped = new HashSet<Coordinates>();

            // process black tiles

            foreach (var tile in @this)
            {
                var neighbourCount = @this.NeighbourCount(tile);

                if (neighbourCount == 1 || neighbourCount == 2)
                {
                    // remains black

                    flipped.Add(tile);
                }
            }

            // process white tiles (i.e. inspect all neighbours of the black tiles)

            foreach (var tile in @this)
            {
                foreach (var (x, y) in _directionOffsets[tile.Y % 2 == 0 ? 0 : 1])
                {
                    var neighbour = new Coordinates(tile.X + x, tile.Y + y);

                    if (@this.Contains(neighbour) ||
                        flipped.Contains(neighbour))
                    {
                        // already black or flipped

                        continue;
                    }

                    var neighbourCount = @this.NeighbourCount(neighbour);

                    if (neighbourCount == 2)
                    {
                        // is flipped

                        flipped.Add(neighbour);
                    }
                }
            }

            return flipped;
        }

        #region Helpers

        private static readonly (int x, int y)[][] _directionOffsets = new (int x, int y)[2][]
        {
            new (int x, int y)[6] // even y-coordinates
            {
                (x: 0, y: 1),   // ne
                (x: 1, y: 0),   // e
                (x: 0, y: -1),  // se
                (x: -1, y: -1), // sw
                (x: -1, y: 0),  // w
                (x: -1, y: 1),  // nw
            },
            new (int x, int y)[6] // odd y-coordinates
            {
                (x: 1, y: 1),  // ne
                (x: 1, y: 0),  // e
                (x: 1, y: -1), // se
                (x: 0, y: -1), // sw
                (x: -1, y: 0), // w
                (x: 0, y: 1),  // nw
            },
        };

        private static int NeighbourCount(
            this HashSet<Coordinates> @this,
            Coordinates tile)
        {
            return _directionOffsets[tile.Y % 2 == 0 ? 0 : 1].Count(o => @this.Contains(new(tile.X + o.x, tile.Y + o.y)));
        }

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
