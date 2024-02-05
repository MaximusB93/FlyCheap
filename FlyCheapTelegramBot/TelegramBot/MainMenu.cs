using FlyCheapTelegramBot.StateModels;
using Telegram.Bot.Types.ReplyMarkups;

namespace FlyCheapTelegramBot.TelegramBot;

public class MainMenu
{
    public static IReplyMarkup GetMainMenu()
    {
        InlineKeyboardMarkup mainMenu = new(new[]
        {
            new[]
            {
                InlineKeyboardButton.WithCallbackData("Поиск авиарейса", "searchFlight"),
                InlineKeyboardButton.WithCallbackData("Мои рейсы", "myFlight")
            },
        });
        return mainMenu;
    }

    public static IReplyMarkup GetMainFlight(List<Fly> flights, long userTgId)
    {
        InlineKeyboardMarkup mainFlight = null;
        var flightTgId = flights.Where(x => x.UserTgId == userTgId).ToList();  //Выбор нужного пользователя по Id для показа истории
        if (flightTgId.Count != 0)
        {
            List<List<InlineKeyboardButton>> buttons = new List<List<InlineKeyboardButton>>();
            for (int i = 0; i < flightTgId.Count; i++)
            {
                var flight = flightTgId[i];

                var button =
                    InlineKeyboardButton.WithCallbackData($"{flight.DepartureCity} - {flight.ArrivalCity}",
                        $"flight_{flights.IndexOf(flight)}");
                buttons.Add(new List<InlineKeyboardButton> { button });
            }

            mainFlight = new InlineKeyboardMarkup(buttons);
        }

        return mainFlight;
    }
}