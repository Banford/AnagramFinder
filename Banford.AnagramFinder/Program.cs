using System;
using System.Collections.Generic;
using System.IO;

namespace Banford.AnagramFinder
{
    class Program
    {
        static void Main(string[] args)
        {
            //var fileName = args[0];
            const string fileName = @"C:\AnagramData\example2.txt";
            
            ProcessFile(fileName);
        }
        
        private static void ProcessFile(string fileName)
        {
            var finder = new AnagramFinder();

            var words = new List<string>();
            var lastWord = string.Empty;

            using var reader = new StreamReader(fileName);
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                if (line.Length != lastWord.Length && lastWord != string.Empty)
                {
                    ProcessBatchOfWords(words.ToArray(), finder);
                    words.Clear();
                }

                words.Add(line);
                lastWord = line;
            }
        }

        private static void ProcessBatchOfWords(IEnumerable<string> words, AnagramFinder finder)
        {
            var anagrams = finder.FindAnagrams(words);

            foreach (var anagram in anagrams)
            {
                Console.WriteLine(anagram.Value.FormatAnagramGroup());
            }
        }
    }
}