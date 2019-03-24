using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.IO;
using System.Linq;

namespace CountOccurrence
{
    class Program
    {

        /// Method for reading the content of the input file  
        public static string ReadTextFile(string fileName)
        {
            string text ="";
            try
            {
                text = System.IO.File.ReadAllText(fileName);
            }catch(Exception ex)
            {
                Console.Write("The input file could not be found.\n" + ex);
                Environment.Exit(1);
            }

            return text;
        }

        /// Do a case insensitive replace
        /// Splits the given text into individual words, stripping punctuation
        /// A word is defined by the regex @"\p{L}+"
        public static IEnumerable<string> SplitWords(string text)
        {
            string toLowerCase = text.ToLower();
            Regex wordMatcher = new Regex(@"[\p{L}']+");
            return wordMatcher.Matches(toLowerCase).Select(c => c.Value);
        }

        /// Prints word-counts to the given TextWriter
        public static void WriteWordCounts(Dictionary<string, int> counts, TextWriter writer)
        {
            writer.WriteLine("The number of counts for each words are:");
            foreach (KeyValuePair<string, int> kvp in counts)
            {
                writer.WriteLine("Counts: " + kvp.Value + " for " + kvp.Key);
            }
        }

        /// Counts the number of occurrences of each distinct item
        public static Dictionary<string, int> CountOccurrences(IEnumerable<string> items)
        {
            var dictionary = new Dictionary<string, int>();

            foreach (string word in items)
            {
                int count;
                dictionary.TryGetValue(word, out count);
                dictionary[word] = count + 1;
            }

            return dictionary;
        }
        
        static void Main(string[] args)
        {
            string fileName = @"F:\Ex\MyfgIle.txt"; /// File path
            string inputText = ReadTextFile(fileName);
            IEnumerable<string> splitedWords= SplitWords(inputText);
            var counts = CountOccurrences(splitedWords);
            WriteWordCounts(counts, System.Console.Out);
        }


    }

}