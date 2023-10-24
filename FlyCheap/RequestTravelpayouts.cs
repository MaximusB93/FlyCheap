using Newtonsoft.Json;

namespace FlyCheap;

public class RequestTravelpayouts
{
    public static DataTiсkets _dataTiсkets;
    private HttpClient _httpClient = new HttpClient();

    /*private string url =
        $"https://api.travelpayouts.com/v1/prices/cheap" +
        $"?origin={DataTiсkets.Origin}" +
        $"&destination={DataTiсkets.Destination}" +
        $"&depart_date={DataTiсkets.DepartDate}" +
        $"&return_date={DataTiсkets.ReturnDate}" +
        $"&token={DataTiсkets.Token}";*/

    private string url =
        $"https://api.travelpayouts.com/v1/prices/cheap?origin=MOW&destination=HKT&depart_date=2023-10&return_date=2023-10&token=f10cf5f14fc4ad7bafd93c78d96ce355";

    public async Task<string> RequestGet()
    {
        var result =  _httpClient.GetStringAsync(url);
        //Console.ReadLine();
        return result.Result.ToString();
        var json = JsonConvert.DeserializeObject<DataTiсkets>(result.Result);
        

    }

    

}