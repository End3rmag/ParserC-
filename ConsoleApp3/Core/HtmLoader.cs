namespace ConsoleApp3.Core;

public class HtmLoader
{
    readonly HttpClient client;
    private readonly string url;
    
    public HtmLoader(IParserSettings settings)
    {
        client = new HttpClient();
        url = $"{settings.BaseUrl}/{settings.PreFix}/";
    }

    public async Task<string> GetSourseByPageId(int id)
    {
        var currentUrl = url.Replace("{CurrentId}", id.ToString());
        var response = await client.GetAsync(currentUrl);
        string source = null;


        if (response != null && response.StatusCode == System.Net.HttpStatusCode.OK)
        {
            source = await response.Content.ReadAsStringAsync();
        }

        return source;
    }
}