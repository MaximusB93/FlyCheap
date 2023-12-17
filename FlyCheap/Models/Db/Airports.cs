using System.ComponentModel.DataAnnotations;
using FlyCheap.Models.JsonModel;
using FlyCheap.Models.Utils;

namespace FlyCheap.Models.Db;

public class Airports : NamedEntity
{
    [Key] public int Id { get; set; }
    [MaxLength(3)] public string city_code { get; set; }
    [MaxLength(2)] public string country_code { get; set; }
    [MaxLength(255)] public string time_zone { get; set; }
    [MaxLength(3)] public string code { get; set; }
    [MaxLength(255)] public string iata_type { get; set; }
    [MaxLength(255)] public bool flightable { get; set; }
    [Required][MaxLength(255)] public string name_translations { get; set; }
    public float lat { get; set; }
    public float lon { get; set; }
}