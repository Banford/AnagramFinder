using System.Collections.Generic;

namespace Banford.AnagramFinder
{
    public static class AnagramFormatter
    {
        public static string FormatAnagramGroup(IEnumerable<string> anagrams)
        {
            return string.Join(',', anagrams);
        }
    }
}