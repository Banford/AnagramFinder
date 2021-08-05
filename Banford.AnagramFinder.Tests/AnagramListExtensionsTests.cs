using System;
using Xunit;

namespace Banford.AnagramFinder.Tests
{
    public class AnagramFormatterTests
    {
        [Fact]
        public void FormatAnagramGroup_ShouldReturnFormattedStringOfAnagrams()
        {
            // Arrange
            var anagrams = new[]
            {
                "fun",
                "fnu",
                "unf"
            };

            // Act
            var result = anagrams.FormatAnagramGroup();

            // Assert
            Assert.Equal("fun,fnu,unf", result);
        }
        
        [Fact]
        public void FormatAnagramGroup_ShouldReturnFormattedStringOfAnagramsForLongerList()
        {
            // Arrange
            var anagrams = new[]
            {
                "abc",
                "bac",
                "cba"
            };

            // Act
            var result = anagrams.FormatAnagramGroup();

            // Assert
            Assert.Equal("abc,bac,cba", result);
        }
        
        [Fact]
        public void FormatAnagramGroup_ShouldReturnEmptyStringWhenNoAnagramsAreProvided()
        {
            // Arrange
            var anagrams = Array.Empty<string>();

            // Act
            var result = anagrams.FormatAnagramGroup();

            // Assert
            Assert.Equal("", result);
        }
    }
}