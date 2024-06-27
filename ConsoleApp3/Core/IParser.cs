using AngleSharp.Html.Dom;

namespace ConsoleApp3.Core;

public interface IParser<T> where T : class
{
    T Parse(IHtmlDocument document);
}