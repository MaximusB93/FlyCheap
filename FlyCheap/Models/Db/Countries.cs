using System.ComponentModel.DataAnnotations;
using FlyCheap.Models.JsonModel;
using FlyCheap.Models.Utils;

namespace FlyCheap.Models.Db;

public class Countries : NamedEntity
{
    [Key] public string code { get; set; }
    public string currency { get; set; }
    public NameTranslations name_translations { get; set; }
    public Cases cases { get; set; }
}