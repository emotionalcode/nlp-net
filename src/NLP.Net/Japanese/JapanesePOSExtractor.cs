using NMeCab;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLP.Net.Japanese
{
    internal static class JapanesePOSExtractor
    {
        static MeCabParam meCabParam;
        static MeCabTagger tagger;

        static JapanesePOSExtractor()
        {
            meCabParam = new MeCabParam();
            meCabParam.DicDir = ConfigurationManager.AppSettings["mecabDicPath"];
            tagger = MeCabTagger.Create(meCabParam);
        }
        

        public static IEnumerable<POS> Extract(string text)
        {
            var count = new NLPCount();
            return Extract(text, ref count);
        }

        public static IEnumerable<POS> Extract(string text, ref NLPCount count)
        {
            var segments = new List<POS>();
            if (string.IsNullOrEmpty(text)) return segments;

            MeCabNode node = tagger.ParseToNode(text);
            while (node != null)
            {
                if (node.CharType > 0)
                {
                    if (node.Surface.Length <= 100)
                    {
                        segments.Add(new POS() { Text = node.Surface, PosTag = node.Feature.Split(',')[0] });
                    }
                }
                node = node.Next;
            }
            return segments;
        }
    }
}
