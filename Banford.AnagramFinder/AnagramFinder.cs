using System;
using System.Collections.Generic;
using System.Linq;

namespace Banford.AnagramFinder
{
    public class AnagramFinder
    {
        public static Dictionary<string, List<string>> FindAnagrams(IEnumerable<string> input)
        {
            var anagrams = new Dictionary<string, List<string>>();

            foreach (var word in input)
            {
                var sorted = SortWordAlphabetically(word);

                if (anagrams.ContainsKey(sorted))
                {
                    var value = anagrams[sorted];
                    if (!value.Contains(word)) value.Add(word);
                }
                else
                {
                    anagrams.Add(sorted, new List<string> {word});
                }
            }

            anagrams = SelectAnagrams(anagrams);

            return anagrams;
        }

        private static string SortWordAlphabetically(string word)
        {
            var chars = word.ToCharArray();
            Array.Sort(chars);
            return new string(chars);
        }
        
        private static Dictionary<string, List<string>> SelectAnagrams(Dictionary<string, List<string>> anagrams)
        {
            return anagrams.Where(a => a.Value.Count > 1)
                .ToDictionary(a => a.Key, a => a.Value);
        }
    }
}