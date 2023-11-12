using FlyCheap.Models.Utils;

namespace FlyCheap.Models.JsonModel;

public class AirportsJson : NamedEntity
{
    public string city_code { get; set; }
    public string country_code { get; set; }
    public string time_zone { get; set; }
    public string code { get; set; }
    public string iata_type { get; set; }
    public bool flightable { get; set; }
    public Coordinates coordinates { get; set; }
    public NameTranslations name_translations { get; set; }
}