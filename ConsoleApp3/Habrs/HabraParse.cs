using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using ConsoleApp3.Core;

namespace ConsoleApp3.Habrs;

public class HabraParse : IParser<string[]>
{
    public string[] Parse(IHtmlDocument document)
    {
        var list = new List<string>();
        var items = document.QuerySelectorAll("").Where(item => item.ClassName.Contains(""));

        foreach (var item in items)
        {
            list.Add(item.TextContent);
        }

        return list.ToArray();
    }
}