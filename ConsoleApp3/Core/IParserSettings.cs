namespace ConsoleApp3.Core;

public interface IParserSettings
{
    string BaseUrl { get; set; }

    string PreFix { get; set; }
    
    int StartPoint { get; set; }
    
    int EndPoint { get; set; }
}