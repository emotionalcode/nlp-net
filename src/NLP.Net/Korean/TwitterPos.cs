using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLP.Net.Korean
{
    public enum TwitterPos
    {
        // Word leved POS
        Noun, Verb, Adjective,
        Adverb, Determiner, Exclamation,
        Josa, Eomi, PreEomi, Conjunction,
        NounPrefix, VerbPrefix, Suffix, Unknown,

        // Chunk level POS
        Korean, Foreign, Number, KoreanParticle, Alpha,
        Punctuation, Hashtag, ScreenName,
        Email, URL, CashTag,

        // Functional POS
        Space, Others,

        ProperNoun
    }
}
