using NUnit.Framework;

namespace AdventOfCode2020.Day24.Tests
{
    public class TilesUtilTest
    {
        [Test]
        [TestCase(new HexDirections[] { HexDirections.East, HexDirections.SouthEast, HexDirections.West }, 0, -1)]
        [TestCase(new HexDirections[] { HexDirections.NorthWest, HexDirections.West, HexDirections.SouthWest, HexDirections.East, HexDirections.East }, 0, 0)]
        public void GetCoordinates(
            HexDirections[] directions,
            int expectedX,
            int expectedY)
        {
            var actualCoordinates = directions.GetCoordinates();

            Assert.That(
                actualCoordinates,
                Is.EqualTo(new Coordinates(expectedX, expectedY)));
        }
    }
}