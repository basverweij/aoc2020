
using NUnit.Framework;

namespace AdventOfCode2020.Day13.Tests
{
    public class EuclidUtilTest
    {
        [Test]
        [TestCase(240, 46, 2, -9, 47)]
        public void Extended(
            int a,
            int b,
            int expectedGcd,
            int expectedX,
            int expectedY)
        {
            var (actualGcd, actualX, actualY) = EuclidUtil.Extended(a, b);

            Assert.That(actualGcd, Is.EqualTo(expectedGcd));

            Assert.That(actualX, Is.EqualTo(expectedX));

            Assert.That(actualY, Is.EqualTo(expectedY));
        }

        [Test]
        [TestCase(9, 0, 15, -3, 18)]
        [TestCase(30, 0, 38, -6, 120)]
        public void CombinedRotations(
            int periodA,
            int phaseA,
            int periodB,
            int phaseB,
            int expectedStep)
        {
            var (combinedPeriod, combinedPhase) = EuclidUtil.CombinedRotations(periodA, phaseA, periodB, phaseB);

            var actualStep = EuclidUtil.Mod(-combinedPhase, combinedPeriod);

            Assert.That(actualStep, Is.EqualTo(expectedStep));
        }

        [Test]
        [TestCaseSource(nameof(_solution2TestCases))]
        public void Solution2(
            (int id, int index)[] ids,
            int expectedTimestamp)
        {
            var actualTimestamp = EuclidUtil.Solution2(ids);

            Assert.That(actualTimestamp, Is.EqualTo(expectedTimestamp));
        }

        private static readonly object[][] _solution2TestCases = {
            new object[]{new (int, int)[] { (17, 0), (13, 2), (19, 3) }, 3417 },
            new object[]{new (int, int)[] { (67, 0), (7, 1), (59, 2), (61, 3) }, 754018 },
            new object[]{new (int, int)[] { (67, 0), (7, 2), (59, 3), (61, 4) }, 779210 },
            new object[]{new (int, int)[] { (67, 0), (7, 1), (59, 3), (61, 4) }, 1261476 },
            new object[]{new (int, int)[] { (1789, 0), (37, 1), (47, 2), (1889, 3) }, 1202161486 },
        };
    }
}