using FlyCheap.Models.Utils;

namespace FlyCheap.Models.JsonModel;

public class CountriesJson : NamedEntity
{
    public string code { get; set; }
    public string currency { get; set; }
    public NameTranslations name_translations { get; set; }
    public Cases cases { get; set; }
}