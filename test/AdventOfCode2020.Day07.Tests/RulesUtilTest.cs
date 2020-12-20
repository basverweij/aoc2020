using System.Collections.Generic;
using System.Linq;

using NUnit.Framework;

namespace AdventOfCode2020.Day07.Tests
{
    [TestFixture]
    public class RulesUtilTest
    {
#pragma warning disable CS8618

        private Dictionary<string, (string color, int count)[]> _containing;

#pragma warning restore CS8618

        [SetUp]
        public void SetUp()
        {
            var rules = _lines.Select(RulesUtil.ParseRule).ToArray();

            _containing = rules.ToDictionary(r => r.color, r => r.contains);
        }

        [Test]
        [TestCase("shiny gold", 126)]
        public void GetContainingCountForColor(
            string color,
            int expectedCount)
        {
            var actualCount = _containing.GetContainingCountForColor(color) - 1; // exclude the outer-most bag

            Assert.That(
                actualCount,
                Is.EqualTo(expectedCount));
        }

        #region Helpers

        private static readonly string[] _lines =
        {
            "shiny gold bags contain 2 dark red bags.",
            "dark red bags contain 2 dark orange bags.",
            "dark orange bags contain 2 dark yellow bags.",
            "dark yellow bags contain 2 dark green bags.",
            "dark green bags contain 2 dark blue bags.",
            "dark blue bags contain 2 dark violet bags.",
            "dark violet bags contain no other bags.",
        };

        #endregion
    }
}
