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
            var text = @"육성 과정에서는 아직 스킬도 다 배우지 못 하고, 각성도 못 했고, 장비도 그 레벨 대 마봉 둘둘이나 하는 상태에서 던전을 돌 뿐입니다.(어쩌면 적정레벨의 마봉도 아닐 수 있습니다.) 여기서 난이도를 높힌다는건 게임을 제대로 모르고 있다는 명백한 증거라고 생각 됩니다. 이런다고 액션성 안 살아납니다. 왜 잘 돌아가는걸 되도 않는 이유로 안좋은 쪽으로 바꿔서 유저들의 짜증만 돋구게 만드시는지요? 누구나 만렙 모험단이 아니고 누구도 템페 or 게일포스를 달고 다닐 수 있는게 아닙니다. 파티플레이요? 던파에서 파티플레이가 왜 기피 되는지를 잘 생각해 보시길 바랍니다. 레이드도 아닌 이상 파티플레이의 장점이라고는 랜덤헬 정도일 뿐이죠.";
            var result = POSExtractor.Extract(NLPType.KoreanHanNanum, text);
            foreach (var item in result)
            {
                Console.WriteLine(JsonConvert.SerializeObject(item));
            }

            //var chineseText = "我已经把小号能卖掉的挑战书全卖了换春节套了";
            //var chinesResult = POSExtractor.Extract(NLPType.Chinese, chineseText);
            //foreach (var item in chinesResult)
            //{
            //    Console.WriteLine(JsonConvert.SerializeObject(item));
            //}

            //var englishText = "Female Slayer 2nd awakening avatars gif";
            //var englishResult = POSExtractor.Extract(NLPType.English, englishText);
            //foreach (var item in englishResult)
            //{
            //    Console.WriteLine(JsonConvert.SerializeObject(item));
            //}
        }
    }
}
