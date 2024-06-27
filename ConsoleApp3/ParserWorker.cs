using AngleSharp.Html.Dom;
using AngleSharp.Html.Parser;
using ConsoleApp3.Core;

namespace ConsoleApp3;

public class ParserWorker<T> where T : class
{
     IParser<T> parser;
     private IParserSettings _parserSettings;
     HtmLoader loader;
     private bool isActive;

     public IParser<T> Parser
     {
          get { return parser; }
          set { parser = value; }
     }

     public IParserSettings Settings
     {
          get { return _parserSettings; }
          set
          {
               _parserSettings = value;
               loader = new HtmLoader(value);

          }

     }

     public bool isactive
     {
          get
          {
               return isActive;
          }
     }
     
     public event Action<object, T> OnNewData;
     public event Action<object> OnComplited;

     public ParserWorker(IParser<T> parser)
     {
          this.parser = parser;
     }

     public ParserWorker(IParser<T> parser, IParserSettings _parserSettings) : this(parser)
     {
          this._parserSettings = _parserSettings;
     }

     public void Start()
     {
          isActive = true;
           Worker();
     }

     public void Abort()
     {
          isActive = false;
          
     }

     private async void Worker()
     {
          for (int i = _parserSettings.StartPoint; i < _parserSettings.EndPoint ; i++)
          {
               if (!isActive)
               {
                    return;
               }
               var source = await loader.GetSourseByPageId(i);
               HtmlParser domParser = new HtmlParser();
               IHtmlDocument document = await domParser.ParseDocumentAsync(source);
               T result = parser.Parse(document);
               OnNewData?.Invoke(this, result);
          }
          OnComplited?.Invoke(this);
          isActive = false;
     }
} 