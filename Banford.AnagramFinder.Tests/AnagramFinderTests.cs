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
            var anagrams = finder.FindAnagrams(input);

            // Assert
            var expected = new List<string> {"abc", "cba"};

            Assert.Equal(expected, anagrams.First().Value);
        }
        
        [Fact]
        public void FindAnagrams_ShouldReturnAnagramsInListOfThreeWords()
        {
            // Arrange
            var input = new[] {"abc", "cba", "bac"};
            var finder = new AnagramFinder();

            // Act
            var anagrams = finder.FindAnagrams(input);

            // Assert
            var expected = new List<string> {"abc", "cba", "bac"};

            Assert.Equal(expected, anagrams.First().Value);
        }
        
        [Fact]
        public void FindAnagrams_ShouldNotAddDuplicateWordsToAnagramGroup()
        {
            // Arrange
            var words = new[]
            {
                "fun",
                "fun",
                "fun",
                "fnu"
            };
            var finder = new AnagramFinder();

            // Act
            var anagrams = finder.FindAnagrams(words);

            // Assert
            Assert.Equal(2, anagrams.First().Value.Count);
        }
        
        // Should not return anagram group if only one word
        // Should not return anagram group if no anagrams
    }
}