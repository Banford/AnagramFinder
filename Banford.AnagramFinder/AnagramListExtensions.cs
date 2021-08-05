using System.Collections.Generic;

namespace Banford.AnagramFinder
{
    public static class AnagramListExtensions
    {
        public static string FormatAnagramGroup(this IEnumerable<string> anagrams) 
            => string.Join(',', anagrams);
    }
}