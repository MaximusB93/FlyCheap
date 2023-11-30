using FlyCheap.Db;
using Microsoft.EntityFrameworkCore;

namespace FlyCheap;

public class Catalogs
{
    public static List<string> GetCities()
    {
        using AirDbContext airDbContext = new();
        return airDbContext.Cities
            .AsNoTracking()
            .Select(x => x.name)
            .ToList()
            .Union(airDbContext.Cities  //Объединение последовательностей
                .AsNoTracking()
                .Select(x => x.name_translations)
                .ToList())
            .ToList();
    }
}