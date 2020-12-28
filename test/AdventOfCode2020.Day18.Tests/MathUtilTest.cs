﻿using NUnit.Framework;

namespace AdventOfCode2020.Day18.Tests
{
    [TestFixture]
    public class MathUtilTest
    {
        [Test]
        [TestCase("1 + 2 * 3 + 4 * 5 + 6", 71)]
        [TestCase("1 + (2 * 3) + (4 * (5 + 6))", 51)]
        [TestCase("2 * 3 + (4 * 5)", 26)]
        [TestCase("5 + (8 * 3 + 9 + 3 * 4 * 3)", 437)]
        [TestCase("5 * 9 * (7 * 3 * 3 + 9 * 3 + (8 + 6 * 4))", 12240)]
        [TestCase("((2 + 4 * 9) * (6 + 9 * 8 + 6) + 6) + 2 + 4 * 2", 13632)]
        public void Evaluate(
            string expression,
            int expectedValue)
        {
            var actualValue = MathUtil.Evaluate(expression);

            Assert.That(actualValue, Is.EqualTo(expectedValue));
        }
    }
}
