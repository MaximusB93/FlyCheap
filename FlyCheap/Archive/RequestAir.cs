using FlyCheap.Models.JsonModel;
using FlyCheap.Models.Utils;
using Newtonsoft.Json;

namespace FlyCheap.Api;

public class RequestAir
{
    private static readonly string countriesUrl = "countries.json";
    private static readonly string citiesUrl = "cities.json";
    private static readonly string airportsUrl = "airports.json";
    private static readonly string airlinesUrl = "airlines.json";
    private static readonly string alliancesUrl = "airlines_alliances.json";
    private static readonly string planesUrl = "planes.json";
    public static string[] ArrayUrl = new[] { countriesUrl, citiesUrl, airportsUrl, airlinesUrl };
    public static string language = "ru/";


    public static async Task<string> GetJsonData()
    {
        string url = $"{Configuration.Configuration.BaseUrl}/data/{language}{ArrayUrl[0]}";
        //var responseContainer = new ResponseContainer(); Под вопросом откуда берется

        using (var client = new HttpClient())
        { 
            var response = await client.GetStringAsync(url);
            return response;
        }
    }

    public static TOutput? ConvertFromJsonToDbFormat<TOutput>(string input) where TOutput : IEnumerable<NamedEntity>
    {
        var output = JsonConvert.DeserializeObject<TOutput>(input);
        foreach (var item in output)
        {
            if (item.name == null)
            {
                item.name = "none";
            }
        }

        if (output.Any(x => x.name == null))
        {
            throw new InvalidOperationException("Обнаружены объекты с полем name, равным null");
        }

        return output;
    }
}