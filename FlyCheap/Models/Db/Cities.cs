using System.ComponentModel.DataAnnotations;
using FlyCheap.Models.JsonModel;
using FlyCheap.Models.Utils;
using Microsoft.EntityFrameworkCore;

namespace FlyCheap.Models.Db;

public class Cities : NamedEntity
{
    public string country_code { get; set; }
    [Key] public string code { get; set; }
    public string time_zone { get; set; }
    //public Coordinates coordinates { get; set; }
    public double lon { get; set; }
    public double lat { get; set; } 

    //public string name_translations { get; set; }
    //public Cases cases { get; set; }
}