using FlyCheap.Models.JsonModel;
using FlyCheap.Models.Utils;
using NamedEntity = FlyCheap.Models.Utils.NamedEntity;

namespace FlyCheap.Models.Db;

public class Airlines : Utils.NamedEntity
{
    public string code { get; set; }
    public string is_lowcost { get; set; }
    public NameTranslations name_translations { get; set; }
}