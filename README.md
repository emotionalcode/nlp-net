# nlp-net [![NuGet Badge](https://buildstats.info/nuget/NLP.NET)](https://www.nuget.org/packages/NLP.Net/)
.net library for [HanNanum](http://semanticweb.kaist.ac.kr/hannanum/), [StanfordNLP](https://sergey-tihon.github.io/Stanford.NLP.NET/StanfordCoreNLP.html), [twitter-korean-text](https://github.com/twitter/twitter-korean-text), [MeCab](http://taku910.github.io/mecab/)


### Install
To install NLP.NET, run the following command in the [Package Manager Console](https://docs.nuget.org/docs/start-here/using-the-package-manager-console)
```
PM> Install-Package NLP.NET
```

### Features
1. Korean NLP via [HanNanum](http://semanticweb.kaist.ac.kr/hannanum/)
2. Korean NLP via [twitter-korean-text](https://github.com/twitter/twitter-korean-text)
3. Chinese NLP via [StanfordNLP](https://sergey-tihon.github.io/Stanford.NLP.NET/StanfordCoreNLP.html)
4. English NLP via [StanfordNLP](https://sergey-tihon.github.io/Stanford.NLP.NET/StanfordCoreNLP.html)
5. Japanese NLP via [MeCab](http://taku910.github.io/mecab/)

### Quick start
```c#
var text = "샘플 텍스트 입니다.";
var result = POSExtractor.Extract(NLPType.KoreanTwitter, text);
```
