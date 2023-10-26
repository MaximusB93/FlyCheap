using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace FlyCheap;

public class _1
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [JsonProperty("airline")] public string Airline { get; set; }
    [JsonProperty("departure_at")] public DateTime Departure_at { get; set; }
    [JsonProperty("return_at")] public DateTime Return_at { get; set; }
    [JsonProperty("expires_at")] public DateTime Expires_at { get; set; }
    [JsonProperty("price")] public int Price { get; set; }
    [JsonProperty("flight_number")] public int Flight_number { get; set; }
}

public class Data
{
    public LED LED { get; set; }
}

public class LED
{
    [JsonProperty("1")] public _1 _1 { get; set; }
}

public class ResponseDataTickets
{
    public Data data { get; set; }
    public string currency { get; set; }
    public bool success { get; set; }
}