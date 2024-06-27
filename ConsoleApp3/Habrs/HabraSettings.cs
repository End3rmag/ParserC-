using ConsoleApp3.Core;

namespace ConsoleApp3.Habrs;

public class HabraSettings : IParserSettings
{
    public string BaseUrl { get; set; } = "https://en.wikipedia.org/wiki/List_of_human_disease_case_fatality_rates";
    public string PreFix { get; set; } = "page{CurrentId}";
    public int StartPoint { get; set; }
    public int EndPoint { get; set; }
}