using com.twitter.penguin.korean.phrase_extractor;
using com.twitter.penguin.korean.tokenizer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLP.Net.Korean
{
    public static class ScalaExtentions
    {
        public static List<POS> ToPosListFromTokens(this scala.collection.Seq seq)
        {
            var result = new List<POS>();
            for (int i = 0; i < seq.size(); i++)
            {
                KoreanTokenizer.KoreanToken scalaResult = seq.apply(i) as KoreanTokenizer.KoreanToken;
                result.Add(new POS()
                {
                    PosTag = ((TwitterPos)scalaResult.pos().id()).ToString(),
                    Text = scalaResult.text()
                });
            }
            return result;
        }

        public static List<POS> ToPosList(this scala.collection.Seq seq)
        {
            var result = new List<POS>();
            for (int i = 0; i < seq.size(); i++)
            {
                KoreanPhraseExtractor.KoreanPhrase scalaResult = seq.apply(i) as KoreanPhraseExtractor.KoreanPhrase;
                var tokens = scalaResult.tokens();
                string text = string.Empty;
                for (int j = 0; j < tokens.size(); j++)
                {
                    KoreanTokenizer.KoreanToken token = tokens.apply(j) as KoreanTokenizer.KoreanToken;
                    text += token.text();
                }

                result.Add(new POS()
                {
                    PosTag = ((TwitterPos)scalaResult.pos().id()).ToString(),
                    Text = text
                });
            }
            return result;
        }
    }
}
