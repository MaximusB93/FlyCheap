using Newtonsoft.Json;

namespace FlyCheap;

public class ReturnDataTickets
{
    public class _0
    {
        [JsonProperty("airline")] public string airline { get; set; }
        [JsonProperty("departure_at")] public DateTime departure_at { get; set; }
        [JsonProperty("return_at")] public DateTime return_at { get; set; }
        [JsonProperty("expires_at")] public DateTime expires_at { get; set; }
        [JsonProperty("price")] public int price { get; set; }
        [JsonProperty("flight_number")] public int flight_number { get; set; }
    }

    public class Data
    {
        [JsonProperty("LED")] public LED LED { get; set; }
    }

    public class LED
    {
        [JsonProperty("0")] public _0 _0 { get; set; }
    }

    public class Root
    {
        [JsonProperty("data")] public Data data { get; set; }
        [JsonProperty("currency")] public string currency { get; set; }
        [JsonProperty("success")] public bool success { get; set; }
    }

    public override string ToString()
    {
        return$"{airline}"
    }
}