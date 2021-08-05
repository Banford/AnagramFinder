using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Banford.AnagramFinder.Tests
{
    public class AnagramFinderTests
    {
        [Fact]
        public void FindAnagrams_ShouldReturnAnagramsInListOfWords()
        {
            // Arrange
            var input = new[] {"abc", "cba"};
            var finder = new AnagramFinder();

            // Act
            var result = finder.FindAnagrams(input);

            // Assert
            var expected = new List<string> {"abc", "cba"};

            Assert.Equal(expected, result.First().Value);
        }
        
        [Fact]
        public void FindAnagrams_ShouldReturnAnagramsInListOfThreeWords()
        {
            // Arrange
            var input = new[] {"abc", "cba", "bac"};
            var finder = new AnagramFinder();

            // Act
            var result = finder.FindAnagrams(input);

            // Assert
            var expected = new List<string> {"abc", "cba", "bac"};

            Assert.Equal(expected, result.First().Value);
        }
    }
}