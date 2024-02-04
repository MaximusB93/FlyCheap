using FlyCheapTelegramBot.Catalog;
using FlyCheapTelegramBot.StateModels;
using Telegram.Bot;

namespace FlyCheapTelegramBot;

public class DataBaseUtils
{
    //Парсим города отправления и прибытия
    public static string? ParsingCity(long tgId, string cityFromMessage, User user)
    {
        var selectedCityFromList =
            CitiesCatalog.cities.FirstOrDefault(x =>
                x.Contains(cityFromMessage)); //Проверяем есть ли такой город в базе
        return selectedCityFromList;
    }

    public static Fly SearchFlyByUserTgId(long tgId)
    {
        var flight =
            FlightsList.flights.Last(x => x.UserTgId == tgId /*&& x.resultTickets == null*/); //Находим Id в листе
        return flight;
    }

    //Вынести в UI
    public static async Task SendMessage(ITelegramBotClient botClient, long tgId, string message)
    {
        await botClient.SendTextMessageAsync(tgId, message);
    }
}