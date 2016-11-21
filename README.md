# nlp-net [![NuGet Badge](https://buildstats.info/nuget/NLP.NET)](https://www.nuget.org/packages/NLP.Net/)
.net library for [HanNanum](http://semanticweb.kaist.ac.kr/hannanum/), [twitter-korean-text](https://github.com/twitter/twitter-korean-text) using [IKVM](http://www.ikvm.net/).


### Install
To install NLP.NET, run the following command in the [Package Manager Console](https://docs.nuget.org/docs/start-here/using-the-package-manager-console)
```
PM> Install-Package NLP.NET
```

### Features
1. extract pos tag

### Quick start
```c#
var text = "샘플 텍스트 입니다.";
var result = POSExtractor.Extract(NLPType.KoreanTwitter, text);
```
