using NUnit.Framework;

namespace AdventOfCode2020.Day03.Tests
{
    public class TreeUtilTest
    {
#pragma warning disable CS8618

        private string[] _geo;

#pragma warning restore CS8618

        [SetUp]
        public void SetUp()
        {
            _geo = new string[]
            {
                "..##.......",
                "#...#...#..",
                ".#....#..#.",
                "..#.#...#.#",
                ".#...##..#.",
                "..#.##.....",
                ".#.#.#....#",
                ".#........#",
                "#.##...#...",
                "#...##....#",
                ".#..#...#.#",
            };
        }

        [Test]
        [TestCase(1, 1, 2)]
        [TestCase(3, 1, 7)]
        [TestCase(5, 1, 3)]
        [TestCase(7, 1, 4)]
        [TestCase(1, 2, 2)]
        public void Trees(
            int slopeX,
            int slopeY,
            int expected)
        {
            var actual = TreeUtil.Trees(_geo, slopeX, slopeY);

            Assert.That(
                actual,
                Is.EqualTo(expected));
        }
    }
}