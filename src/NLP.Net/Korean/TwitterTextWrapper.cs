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
            var count = new NLPCount();
            return Extract(text, ref count);
        }

        public static IEnumerable<POS> Extract(string text, ref NLPCount count)
        {
            string normalized = TwitterKoreanProcessor.normalize(text).toString();
            var tokenized = TwitterKoreanProcessor.tokenize(normalized);
            var stemmed = TwitterKoreanProcessor.stem(tokenized);
            return stemmed.ToPosListFromTokens().Where(s => s.PosTag != "Punctuation" && s.PosTag != "Space");
        }
    }

    
}
