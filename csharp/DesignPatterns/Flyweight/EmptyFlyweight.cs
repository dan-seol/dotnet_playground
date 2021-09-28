using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using NUnit.Framework;

namespace Flyweight
//namespace Coding.Exercise
{
    public class Sentence
    {
        private List<WordToken> tokens = new List<WordToken>();
        public Sentence(string plainText)
        {
            // todo
            tokens = plainText.Split(' ').Select(word => new WordToken { Word = word, Capitalize = false }).ToList();
        }

        public WordToken this[int index]
        {
            get
            {
                return tokens[index];

            }
        }

        public override string ToString()
        {
            // output formatted text here
            return tokens.Select(token => token.Capitalize ? token.Word.ToUpper() : token.Word).Aggregate(string.Empty, (s1, s2) => string.Equals(string.Empty, s1) ? s1 + s2 : s1 + " " + s2);

        }

        public class WordToken
        {
            public bool Capitalize;
            public string Word;
        }
    }
}