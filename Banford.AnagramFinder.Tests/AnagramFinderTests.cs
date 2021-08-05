using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Banford.AnagramFinder;

namespace Banford.AnagramFinder.Tests
{
    public class AnagramFinderTests
    {
        [Fact]
        public void FindAnagrams_ShouldReturnAnagramsInListOfWords()
        {
            // Arrange
            var input = new[] {"abc", "cba"};

            // Act
            var finder = new AnagramFinder();
            var result = finder.FindAnagrams(input);

            // Assert
            var expected = new List<string> {"abc", "cba"};

            Assert.Equal(expected, result.First().Value);
        }
    }
}