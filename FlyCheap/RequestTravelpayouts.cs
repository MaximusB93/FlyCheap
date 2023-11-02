using FlyCheap.Model;
using Newtonsoft.Json;

namespace FlyCheap;

public class RequestTravelpayouts
{
    public static FlightSearchOptions FlightSearchOptions;
    private HttpClient _httpClient = new HttpClient();

    /*private string url =
        $"https://api.travelpayouts.com/v1/prices/cheap" +
        $"?origin={FlightSearchOptions.Origin}" +
        $"&destination={FlightSearchOptions.Destination}" +
        $"&depart_date={FlightSearchOptions.DepartDate}" +
        $"&return_date={FlightSearchOptions.ReturnDate}" +
        $"&token={FlightSearchOptions.Token}";*/

    private string url =
        $"https://api.travelpayouts.com/v1/prices/cheap?origin=MOW&destination=LED&depart_date=2023-10-27&return_date=2023-10-30&token=f10cf5f14fc4ad7bafd93c78d96ce355";

    public async Task<string> RequestGet()
    {
        var result = await _httpClient.GetStringAsync(url);
        return result;
    }

    public ResponseDataTickets? DeserializeJson()
    {
        var task = RequestGet();
        task.Wait();
        var jsonToDataTickets = JsonConvert.DeserializeObject<ResponseDataTickets>(task.Result);
        return jsonToDataTickets;
     }
}