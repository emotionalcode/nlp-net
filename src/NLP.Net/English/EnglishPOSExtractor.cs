using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using edu.stanford.nlp.pipeline;
using static edu.stanford.nlp.ling.CoreAnnotations;
using System.IO;

namespace NLP.Net.English
{
    internal static class EnglishPOSExtractor
    {
        static StanfordCoreNLP pipeline;
        static EnglishPOSExtractor()
        {
            var props = new java.util.Properties();
            props.setProperty("annotators", "tokenize, ssplit, pos");
            props.setProperty("ner.useSUTime", "0");

            var curDir = Environment.CurrentDirectory;
            Directory.SetCurrentDirectory($"{curDir}/english");

            pipeline = new StanfordCoreNLP(props);
            Directory.SetCurrentDirectory(curDir);

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
