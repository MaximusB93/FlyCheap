using FlyCheap.Models.Utils;

namespace FlyCheap.Models.JsonModel;

public class AirlinesJson : NamedEntity
{
    public string code { get; set; }
    public string is_lowcost { get; set; }
    public NameTranslations name_translations { get; set; }
}