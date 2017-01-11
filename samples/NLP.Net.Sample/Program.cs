using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLP.Net.Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            var text = @"꼬우면 오후 반차쓰고 참여하세요 뭐 이런거 아님? 선착순이라니 어처구니없는..";
            var result = POSExtractor.Extract(NLPType.KoreanTwitter, text);
            foreach (var item in result)
            {
                Console.WriteLine(JsonConvert.SerializeObject(item));
            }

            var chineseText = "我已经把小号能卖掉的挑战书全卖了换春节套了";
            var chinesResult = POSExtractor.Extract(NLPType.Chinese, chineseText);
            foreach (var item in chinesResult)
            {
                Console.WriteLine(JsonConvert.SerializeObject(item));
            }

            var englishText = "Female Slayer 2nd awakening avatars gif";
            var englishResult = POSExtractor.Extract(NLPType.English, englishText);
            foreach (var item in englishResult)
            {
                Console.WriteLine(JsonConvert.SerializeObject(item));
            }
        }
    }
}
