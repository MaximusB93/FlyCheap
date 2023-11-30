using FlyCheap;
using FlyCheap.Converter;
using FlyCheap.Db;
using FlyCheap.Enums;
using FlyCheap.Models.Db;

namespace FlyCheap;

static class Program
{
    private static UpdateDb _converter = new();

    static void Main()
    {
        Console.WriteLine("Start");

        // Console.WriteLine(_apiAviaSales.Test());
        _converter.ChangeMethodUpdateCollection(TableCode.Airports, LanguageCode.Russian);
        _converter.ChangeMethodUpdateCollection(TableCode.Cities, LanguageCode.Russian);
        _converter.ChangeMethodUpdateCollection(TableCode.Airlines, LanguageCode.Russian);
        _converter.ChangeMethodUpdateCollection(TableCode.Countries, LanguageCode.Russian);

        Console.WriteLine("Stop");
    }
}