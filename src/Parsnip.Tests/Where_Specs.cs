﻿namespace Parsnip.Tests
{
    using NUnit.Framework;
    using Parsers;


    [TestFixture]
    public class Querying_an_array_with_a_filter
    {
        [Test]
        public void Should_return_a_matching_element()
        {
            var subject = new[] {1, 2, 3, 4, 5};

            var anyParser = new AnyParser<int>();

            Parser<int[], int> query = from x in anyParser
                                       where x == 1
                                       select x;

            Result<int[], int> result = query.ParseArray(subject);

            Assert.IsTrue(result.HasValue);
            Assert.AreEqual(1, result.Value);
        }

        [Test]
        public void Should_not_return_an_unmatching_element()
        {
            var subject = new[] {1, 2, 3, 4, 5};

            var anyParser = new AnyParser<int>();

            Parser<int[], int> query = from x in anyParser
                                       where x == 2
                                       where x != 1
                                       select x;

            Result<int[], int> result = query.ParseArray(subject);

            Assert.IsFalse(result.HasValue);
        }
    }
}