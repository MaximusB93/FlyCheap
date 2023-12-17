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
            FlightsList.flights.First(x => x.UserTgId == tgId && x.resultTickets == null); //Находим Id в листе
        return flight;
    }

    //Вынести в UI
    public static async Task SendMessage(ITelegramBotClient botClient, long tgId, string message)
    {
        await botClient.SendTextMessageAsync(tgId, message);
    }

    public static void SaveResultsToList<T>(T flight, T data, InputState inputState, User user)
    {
        flight = data;
        user.InputState = inputState;
    }
    public static void SaveResultsToList1(Fly flight, string data, InputState inputState, User user)
    {
        flight.DepartureCity = data;
        user.InputState = inputState;
    }
    public static void SaveResultsToList2(Fly flight, string data, InputState inputState, User user)
    {
        flight.ArrivalCity = data;
        user.InputState = inputState;
    }
    public static void SaveResultsToList3(Fly flight, DateTime data, InputState inputState, User user)
    {
        flight.DepartureDate = data;
        user.InputState = inputState;
    }
}