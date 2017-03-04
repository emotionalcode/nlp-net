using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLP.Net.Korean
{
    using jHanNanum = kr.ac.kaist.swrc.jhannanum;

    internal static class HannaNumWrapper
    {
        static jHanNanum.hannanum.Workflow workflow = jHanNanum.hannanum.WorkflowFactory.getPredefinedWorkflow(3);

        static HannaNumWrapper()
        {
            workflow.activateWorkflow(false);
        }

        public static IEnumerable<POS> Extract(string text)
        {
            var count = new NLPCount();
            return Extract(text, ref count);
        }

        public static IEnumerable<POS> Extract(string text, ref NLPCount count)
        {
            var result = new List<POS>();
            workflow.analyze(text);
            var sentences = workflow.getResultOfDocument(new jHanNanum.comm.Sentence(0, 0, false));
            foreach (jHanNanum.comm.Sentence sentence in sentences)
            {
                count.SentenceCount++;
                var eojeols = sentence.Eojeols;
                foreach (var eojeol in eojeols)
                {
                    count.WordsPhraseCount++;
                    for (int i = 0; i < eojeol.length; i++)
                    {
                        count.MorphemeCount++;
                        result.Add(new POS()
                        {
                            PosTag = eojeol.Tags[i],
                            Text = eojeol.Morphemes[i]
                        });
                    }
                }
            }
            return result;
        }
    }
}
