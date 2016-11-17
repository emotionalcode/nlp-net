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
        }
    }
}
