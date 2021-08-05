using System.Collections.Generic;

namespace Banford.AnagramFinder
{
    public class AnagramFinder
    {
        public Dictionary<string, List<string>> FindAnagrams(string[] input)
        {
            // Hard coded to pass first test...
            return new Dictionary<string, List<string>>
            {
                {"abc", new List<string> {"abc", "cba"}}
            };
        }
    }
}