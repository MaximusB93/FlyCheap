using Newtonsoft.Json;

namespace FlyCheap.Archive;

public class ApiTravelpayoutsCopy
{
    public static string Token = "f10cf5f14fc4ad7bafd93c78d96ce355";
    public static string Origin { get; set; }
    public static string Destination { get; set; }
    public static DateTime DepartDate { get; set; }
    public static DateTime ReturnDate { get; set; }
    
    private HttpClient _httpClient = new HttpClient();

    private string url =
        $"https://api.travelpayouts.com/v1/prices/cheap" +
        $"?origin={Origin}" +
        $"&destination={Destination}" +
        $"&depart_date={DepartDate}" +
        $"&return_date={ReturnDate}" +
        $"&token={Token}";

    public ApiTravelpayoutsCopy(string origin, string destination, DateTime departDate, DateTime returnDate)
    {
        Origin = origin;
        Destination = destination;
        DepartDate = departDate;
        ReturnDate = returnDate;
    }
    
    //private string url = $"https://api.travelpayouts.com/v1/prices/cheap?origin=MOW&destination=LED&depart_date=2023-10-27&return_date=2023-10-30&token=f10cf5f14fc4ad7bafd93c78d96ce355";

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