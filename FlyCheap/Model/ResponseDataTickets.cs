using Newtonsoft.Json;

namespace FlyCheap.Model;

public class _1
{
    private Random rnd = new Random();

    private DateTime _departureAt;
    private DateTime _returnAt;
    private DateTime _expiresAt;

    //[Key]
    //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id
    {
        get => rnd.Next(6, 10);
        set => rnd.Next();
    }

    [JsonProperty("airline")] public string Airline { get; set; }

    [JsonProperty("departure_at")]
    public DateTime Departure_at
    {
        get => _departureAt.ToUniversalTime();
        set => _departureAt = value.ToUniversalTime();
    }

    [JsonProperty("return_at")]
    public DateTime Return_at
    {
        get => _returnAt.ToUniversalTime();
        set => _returnAt = value.ToUniversalTime();
    }

    [JsonProperty("expires_at")]
    public DateTime Expires_at
    {
        get => _expiresAt.ToUniversalTime();
        set => _expiresAt = value.ToUniversalTime();
    }

    [JsonProperty("price")] public int Price { get; set; }
    [JsonProperty("flight_number")] public int Flight_number { get; set; }
}

public class Data
{
    public LED LED { get; set; }
}

public class LED
{
    [JsonProperty("0")] public _1 _1 { get; set; }
}

public class ResponseDataTickets
{
    public Data data { get; set; }
    public string currency { get; set; }
    public bool success { get; set; }
}