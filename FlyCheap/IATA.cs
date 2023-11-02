using FlyCheap.Model;
using Newtonsoft.Json;

namespace FlyCheap;

public class IATA
{
    private HttpClient _httpClient = new HttpClient();

    public async Task<string> RequestIata(string origin, string destination)
    {
        string url = $"https://www.travelpayouts.com/widgets_suggest_params?q=Из%20{origin}%20в%{destination}";
        var result = await _httpClient.GetStringAsync(url);
        return result;
    }
    
    public CitesIata? DeserializeJson(string origin, string destination)
    {
        var task = RequestIata(origin,destination);
        task.Wait();
        var jsonToDataTickets = JsonConvert.DeserializeObject<CitesIata>(task.Result);
        return jsonToDataTickets;
    }
    
    
}

