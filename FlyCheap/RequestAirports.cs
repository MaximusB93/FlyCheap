using FlyCheap.Model;
using Newtonsoft.Json;

namespace FlyCheap;

public class RequestAirports
{
    private HttpClient _httpClient = new HttpClient();
    private readonly string url = "https://api.travelpayouts.com/data/en/airports.json";

    public async Task<string> GetAirports()
    {
        var json = await _httpClient.GetStringAsync(url);
        return json;
    }

    public AirportsJson? DeserializeJson()
    {
        var json = GetAirports();
        json.Wait();
        var jsonToAirports = JsonConvert.DeserializeObject<AirportsJson>(json.Result);
        return jsonToAirports;
    }
}