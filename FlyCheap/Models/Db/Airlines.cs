using System.ComponentModel.DataAnnotations;
using FlyCheap.Models.JsonModel;
using FlyCheap.Models.Utils;
using NamedEntity = FlyCheap.Models.Utils.NamedEntity;

namespace FlyCheap.Models.Db;

public class Airlines : NamedEntity
{
    [Key] public string code { get; set; }
    public string is_lowcost { get; set; }
    [Required]public string name_translations { get; set; }
}