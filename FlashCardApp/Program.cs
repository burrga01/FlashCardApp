using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection.Metadata.Ecma335;

namespace FlashCardApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var textFileReader = new TextFileReader(@"Words.txt");

            //get words from file
            var words = textFileReader.ReadWords();
            for(int i = 0; i < words.Count; i++)
            {
                words[i] = CapitilizeFirstLetter(words[i]);
            }


            var csvFileReader = new CsvReader(@"Dictionary in csv\");
            Dictionary<string, List<string>> dictionary = new Dictionary<string, List<string>>();

            foreach (string word in words)
            {
                var definitions = csvFileReader.LookUpDefinition(word);
                if (!dictionary.ContainsKey(word))
                {
                    dictionary.Add(word, definitions);
                }
            }

            foreach (string key in dictionary.Keys)
            {
                Console.WriteLine($"{key.ToUpper()}:");
                printList(dictionary[key]);
                Console.WriteLine();
                Console.WriteLine();
            }

        }

        private static void printList(List<string> words)
        {
            foreach (string word in words)
            {
                Console.WriteLine(word);
            }
        }
        private static string CapitilizeFirstLetter(string word)
        {
            var letters = word.ToCharArray();
            var upperCaseLetters = word.ToUpper().ToCharArray();
            letters[0] = upperCaseLetters[0];

            string capitilizedWord = "";
            for(int i = 0; i < letters.Length; i ++)
            {
                capitilizedWord = capitilizedWord + letters[i].ToString();
            }
            return capitilizedWord;
        }
    }
}
