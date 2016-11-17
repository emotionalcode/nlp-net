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
            var result = new List<POS>();
            workflow.analyze(text);
            var sentences = workflow.getResultOfDocument(new jHanNanum.comm.Sentence(0, 0, false));

            foreach (jHanNanum.comm.Sentence sentence in sentences)
            {
                var eojeols = sentence.getEojeols();
                foreach (var eojeol in eojeols)
                {
                    for (int i = 0; i < eojeol.length; i++)
                    {
                        result.Add(new POS()
                        {
                            PosTag = eojeol.getTags()[i],
                            Text = eojeol.getMorphemes()[i]
                        });
                    }
                }
            }
            return result;
        }
    }
}
