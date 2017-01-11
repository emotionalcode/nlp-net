using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using edu.stanford.nlp.pipeline;
using static edu.stanford.nlp.ling.CoreAnnotations;

namespace NLP.Net.Chinese
{
    static class ChinesePOSExtractor
    {
        static StanfordCoreNLP pipeline;
        static ChinesePOSExtractor()
        {
            var props = new java.util.Properties();
            props.setProperty("annotators", "segment, ssplit, pos");
            props.setProperty("customAnnotatorClass.segment", "edu.stanford.nlp.pipeline.ChineseSegmenterAnnotator");

            props.setProperty("segment.model", "edu/stanford/nlp/models/segmenter/chinese/ctb.gz");
            props.setProperty("segment.sighanCorporaDict", "edu/stanford/nlp/models/segmenter/chinese");
            props.setProperty("segment.serDictionary", "edu/stanford/nlp/models/segmenter/chinese/dict-chris6.ser.gz");
            props.setProperty("segment.sighanPostProcessing", "true");

            //sentence split
            props.setProperty("ssplit.boundaryTokenRegex", "[.]|[!?]+|[。]|[！？]+");

            //pos
            props.setProperty("pos.model", "edu/stanford/nlp/models/pos-tagger/chinese-distsim/chinese-distsim.tagger");

            //ner
            props.setProperty("ner.model", "edu/stanford/nlp/models/ner/chinese.misc.distsim.crf.ser.gz");
            props.setProperty("ner.applyNumericClassifiers", "false");
            props.setProperty("ner.useSUTime", "false");

            //# parse
            props.setProperty("parse.model", "edu/stanford/nlp/models/lexparser/chineseFactored.ser.gz");

            pipeline = new StanfordCoreNLP(props);
        }

        public static IEnumerable<POS> Extract(string text)
        {

            var segment = new List<POS>();
            if (string.IsNullOrEmpty(text)) return segment;

            var document = new Annotation(text);
            pipeline.annotate(document);

            var sentencesAnnotation = new SentencesAnnotation();
            var tokensAnnotation = new TokensAnnotation();
            var textAnnotation = new TextAnnotation();
            var partOfSpeechAnnotation = new PartOfSpeechAnnotation();

            java.util.ArrayList sentenceArrayList = (java.util.ArrayList)document.get(sentencesAnnotation.getClass());
            var sentences = sentenceArrayList.toArray();

            for (int i = 0; i < sentences.Length; i++)
            {
                var sentence = (edu.stanford.nlp.util.CoreMap)sentences[i];
                var tokenArray = ((java.util.ArrayList)sentence.get(tokensAnnotation.getClass()));
                var tokens = tokenArray.toArray();
                for (int j = 0; j < tokens.Length; j++)
                {

                    var coreLabel = (edu.stanford.nlp.ling.CoreLabel)tokens[j];
                    string posTag = (string)coreLabel.get(partOfSpeechAnnotation.getClass());
                    string word = (string)coreLabel.get(textAnnotation.getClass());
                    if (word.Length <= 100)
                    {
                        segment.Add(new POS() { Text = word, PosTag = posTag });
                    }
                }
            }
            return segment.ToList();
        }
    }
}
