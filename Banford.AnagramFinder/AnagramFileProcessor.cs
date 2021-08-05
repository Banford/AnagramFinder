using System;
using System.Collections.Generic;
using System.IO;

namespace Banford.AnagramFinder
{
    public static class AnagramFileProcessor
    {
        public static void Process(string fileName)
        {
            var words = new List<string>();
            var lastWord = string.Empty;

            using var reader = new StreamReader(fileName);
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                var isEndOfInput = lastWord == string.Empty;
                var isSameLengthWord = line.Length == lastWord.Length;
                var shouldProcessBatch = !isSameLengthWord && !isEndOfInput;
                
                if (shouldProcessBatch)
                {
                    ProcessBatchOfWords(words.ToArray());
                    words.Clear();
                }

                words.Add(line);
                lastWord = line;
            }
        }

        private static void ProcessBatchOfWords(IEnumerable<string> words)
        {
            var anagrams = AnagramFinder.FindAnagrams(words);

            foreach (var anagram in anagrams)
            {
                Console.WriteLine(anagram.Value.FormatAnagramGroup());
            }
        }
    }
}