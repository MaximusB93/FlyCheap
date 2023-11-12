using FlyCheap.Models.Utils;

namespace FlyCheap.Models.JsonModel;

public class AlliansesJson : NamedEntity
{
    public List<string> airlines { get; set; }
    public NameTranslations name_translations { get; set; }
}