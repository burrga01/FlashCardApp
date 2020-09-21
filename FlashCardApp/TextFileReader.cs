using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.IO;

namespace FlashCardApp
{
    class TextFileReader
    {
        private string _filePath;
        public TextFileReader(string filePath)
        {
            _filePath = filePath;
        }
        public List<string> ReadWords()
        {
            var words = new List<string>();

            using (var reader = File.OpenText(_filePath))
            {
                string line;
                while((line = reader.ReadLine()) != null)
                {
                    words.Add(line);
                }
            }
            return words;
        }
    }
}
