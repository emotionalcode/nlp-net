﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLP.Net.Korean;

namespace NLP.Net
{
    public class POSExtractor
    {
        public static IEnumerable<POS> Extract(NLPType nlpType, string text)
        {
            switch (nlpType)
            {
                case NLPType.KoreanHanNanum:
                    return HannaNumWrapper.Extract(text);
                case NLPType.KoreanTwitter:
                    return TwitterTextWrapper.Extract(text);
                case NLPType.Chinese:
                    return Chinese.ChinesePOSExtractor.Extract(text);
                default:
                    throw new Exception($"{nlpType} is not supported");
            }
        }
    }

    public enum NLPType
    {
        KoreanHanNanum,
        KoreanTwitter,
        //English,
        Chinese
    }

    public class POS
    {
        public string PosTag { get; set; }
        public string Text { get; set; }
    }
}
