using FlyCheap.Model;
using Newtonsoft.Json;

namespace FlyCheap;

public class IATA
{
    private HttpClient _httpClient = new HttpClient();

    private async Task<string> RequestIata(string city)
    {
        string url = $"https://www.travelpayouts.com/widgets_suggest_params?q=Из%20{city}%20в%20{city}";
        var result = await _httpClient.GetStringAsync(url);
        return result;
    }

    public CitesIata? DeserializeJson(string city)
    {
        var task = RequestIata(city);
        task.Wait();
        var jsonToDataTickets = JsonConvert.DeserializeObject<CitesIata>(task.Result);
        return jsonToDataTickets;
    }
}