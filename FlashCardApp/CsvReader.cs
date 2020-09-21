using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace FlashCardApp
{
    class CsvReader
    {
        private string _folderPath;

        public CsvReader(string folderPath)
        {
            _folderPath = folderPath;
        }
        //public list<flashcard> readwords()
        //{

        //}
        //public flashcard readLineFromFile(string line)
        //{

        //}

        public List<string> LookUpDefinition(string word)
        {
            List<string> definitions = new List<string>();

            char firstLetter = word[0];
            string filePath = _folderPath + firstLetter.ToString().ToUpper() + ".csv";

            using(var reader = File.OpenText(filePath))
            {
                string line;
                while((line = reader.ReadLine()) != null)
                {
                    string wordFound = line.Split('(')[0];
                    if (wordFound.Contains(word))
                    {
                        if(wordFound.Length-1 <= word.Length)
                        {
                            definitions.Add(line);
                        }
                    }
                }
            }       
            return definitions;
        }
    }
}
