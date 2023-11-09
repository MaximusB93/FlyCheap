using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FlyCheap.Model;

public class AirportsJson
{
    public int AirportsJsonId { get; set; }
    public int NameTranslationsId { get; set; }
    [ForeignKey("NameTranslationsId")] public NameTranslations name_translations { get; set; }
    public string city_code { get; set; }
    public string country_code { get; set; }
    public string time_zone { get; set; }
    public string code { get; set; }
    public string iata_type { get; set; }
    public string name { get; set; }
    public int CoordinatesId { get; set; }
    [ForeignKey("CoordinatesId")] public Coordinates coordinates { get; set; }
    public bool flightable { get; set; }
}

public class NameTranslations
{
    public int NameTranslationsId { get; set; }
    public string en { get; set; }
}

public class Coordinates
{
    public int CoordinatesId { get; set; }
    public float lat { get; set; }
    public float lon { get; set; }
}