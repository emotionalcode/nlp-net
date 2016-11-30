using com.twitter.penguin.korean;
using com.twitter.penguin.korean.phrase_extractor;
using com.twitter.penguin.korean.tokenizer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLP.Net.Korean
{
    internal static class TwitterTextWrapper
    {
        //static string[] PosIgnore = new string[]
        //{
        //    "Space",
        //    "Punctuation"
        //};

        public static IEnumerable<POS> Extract(string text)
        {
            string normalized = TwitterKoreanProcessor.normalize(text).toString();
            var tokenized = TwitterKoreanProcessor.tokenize(normalized);
            var stemmed = TwitterKoreanProcessor.stem(tokenized);
            var phrases = TwitterKoreanProcessor.extractPhrases(stemmed, true, false);
            return phrases.ToPosList();
        }
    }

    
}
