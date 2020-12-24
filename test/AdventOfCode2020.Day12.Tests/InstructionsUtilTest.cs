
using NUnit.Framework;

namespace AdventOfCode2020.Day12.Tests
{
    [TestFixture]
    public class InstructionsUtilTest
    {
        [Test]
        [TestCase("R0", 'R', 0)]
        [TestCase("R90", 'R', 1)]
        [TestCase("R180", 'R', 2)]
        [TestCase("R270", 'R', 3)]
        [TestCase("L0", 'L', 0)]
        [TestCase("L90", 'L', 3)]
        [TestCase("L180", 'L', 2)]
        [TestCase("L270", 'L', 1)]
        public void Parse(
            string s,
            char expectedInstruction,
            int expectedNumber)
        {
            var (actualInstruction, actualNumber) = InstructionsUtil.Parse(s);

            Assert.That(actualInstruction, Is.EqualTo(expectedInstruction));

            Assert.That(actualNumber, Is.EqualTo(expectedNumber));
        }

        [Test]
        [TestCase('R', 0, 1, 2)]
        [TestCase('R', 1, -2, 1)]
        [TestCase('R', 2, -1, -2)]
        [TestCase('R', 3, 2, -1)]
        [TestCase('L', 0, 1, 2)]
        [TestCase('L', 3, 2, -1)]
        [TestCase('L', 2, -1, -2)]
        [TestCase('L', 1, -2, 1)]
        public void ApplyWithWaypoint(
            char instruction,
            int number,
            int expectedWaypointX,
            int expectedWaypointY)
        {
            var (x, y) = (0, 0);

            var (waypointX, waypointY) = (1, 2);

            (instruction, number).ApplyWithWaypoint(ref x, ref y, ref waypointX, ref waypointY);

            Assert.That(x, Is.EqualTo(0));

            Assert.That(y, Is.EqualTo(0));

            Assert.That(waypointX, Is.EqualTo(expectedWaypointX));

            Assert.That(waypointY, Is.EqualTo(expectedWaypointY));
        }
    }
}
