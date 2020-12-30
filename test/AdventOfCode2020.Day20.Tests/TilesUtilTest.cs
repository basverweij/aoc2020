using NUnit.Framework;

namespace AdventOfCode2020.Day20.Tests
{
    public class TilesUtilTest
    {
        [Test]
        [TestCase(false, 0, new char[] { '1', '2', '3', '4', '5', '6', '7', '8', '9' })]
        [TestCase(false, 1, new char[] { '7', '4', '1', '8', '5', '2', '9', '6', '3' })]
        [TestCase(false, 2, new char[] { '9', '8', '7', '6', '5', '4', '3', '2', '1' })]
        [TestCase(false, 3, new char[] { '3', '6', '9', '2', '5', '8', '1', '4', '7' })]
        [TestCase(true, 0, new char[] { '3', '2', '1', '6', '5', '4', '9', '8', '7' })]
        [TestCase(true, 1, new char[] { '9', '6', '3', '8', '5', '2', '7', '4', '1' })]
        [TestCase(true, 2, new char[] { '7', '8', '9', '4', '5', '6', '1', '2', '3' })]
        [TestCase(true, 3, new char[] { '1', '4', '7', '2', '5', '8', '3', '6', '9' })]
        public void Permutate(
            bool flipped,
            int rotate,
            char[] expectedPermutation)
        {
            var actualPermutation = _permutationTile.Permutate(flipped, rotate);

            for (var i = 0; i < 9; i++)
            {
                Assert.That(actualPermutation[i / 3][i % 3], Is.EqualTo(expectedPermutation[i]));
            }
        }

        [Test]
        [TestCase(false, 0, new int[] { 966, 288, 24, 902 })]
        [TestCase(false, 1, new int[] { 391, 966, 18, 24 })]
        [TestCase(false, 2, new int[] { 96, 391, 399, 18 })]
        [TestCase(false, 3, new int[] { 288, 96, 902, 399 })]
        [TestCase(true, 0, new int[] { 399, 902, 96, 288 })]
        [TestCase(true, 1, new int[] { 18, 399, 391, 96 })]
        [TestCase(true, 2, new int[] { 24, 18, 966, 391 })]
        [TestCase(true, 3, new int[] { 902, 24, 288, 966 })]
        public void BuildOptions(
            bool flipped,
            int rotate,
            int[] expectedBorders)
        {
            var options = _optionsTile.BuildOptions();

            var option = options[( flipped ? 4 : 0 ) + rotate];

            Assert.That(option.Borders, Is.EqualTo(expectedBorders));
        }

        #region Helpers

        private static readonly char[][] _permutationTile = new char[][]
            {
                new char[] { '1', '2', '3' },
                new char[] { '4', '5', '6' },
                new char[] { '7', '8', '9' },
            };

        private static readonly char[][] _optionsTile = new char[][]
            {
                new char[] { '#', '#', '#', '#', '.', '.', '.', '#', '#', '.',  },
                new char[] { '#', '.', '.', '#', '#', '.', '#', '.', '.', '#',  },
                new char[] { '#', '#', '.', '#', '.', '.', '#', '.', '#', '.',  },
                new char[] { '.', '#', '#', '#', '.', '#', '#', '#', '#', '.',  },
                new char[] { '.', '.', '#', '#', '#', '.', '#', '#', '#', '#',  },
                new char[] { '.', '#', '#', '.', '.', '.', '.', '#', '#', '.',  },
                new char[] { '.', '#', '.', '.', '.', '#', '#', '#', '#', '.',  },
                new char[] { '#', '.', '#', '#', '.', '#', '#', '#', '#', '.',  },
                new char[] { '#', '#', '#', '#', '.', '.', '#', '.', '.', '.',  },
                new char[] { '.', '.', '.', '.', '.', '#', '#', '.', '.', '.',  },
            };

        #endregion
    }
}