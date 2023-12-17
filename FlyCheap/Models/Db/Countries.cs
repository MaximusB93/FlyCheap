using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FlyCheap.Models.JsonModel;
using FlyCheap.Models.Utils;

namespace FlyCheap.Models.Db;

public class Countries : NamedEntity
{
    [Key] public string code { get; set; }
    public string currency { get; set; } 
    public string name_translations { get; set; }
    //public Cases cases { get; set; }
}