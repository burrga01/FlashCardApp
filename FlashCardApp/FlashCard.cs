using System;
using System.Collections.Generic;
using System.Text;

namespace FlashCardApp
{
    public class FlashCard
    {
        public string Word
        {
            get; private set;
        }
        public string Definition
        {
            get; private set;
        }

        public FlashCard(string word, string definition)
        {
            Word = word;
            Definition = definition;
        }
    }
}
