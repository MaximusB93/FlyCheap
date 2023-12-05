using FlyCheap.Models;
using FlyCheap.Models.Db;

namespace FlyCheap.Converter.Comparators;


public class AirportDbComparer : Comparer, IEqualityComparer<Airports>
{
    public bool Equals(Airports x, Airports y)
    {
        // Сравниваем по полям, которые должны определять уникальность записей
        return x.code == y.code && x.name == y.name && x.name_translations.en == y.name_translations.en;
    }

    public int GetHashCode(Airports obj)
    {
        // Возвращаем хэш-код на основе полей, которые определяют уникальность записей
        return HashCode.Combine(obj.code, obj.name, obj.name_translations.en);
    }
}