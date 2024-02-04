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

    public static IReplyMarkup GetMainFlight(List<Fly> flights)
    {
        InlineKeyboardMarkup mainFlight = null;
        if (flights.Count != 0)
        {
            List<List<InlineKeyboardButton>> buttons = new List<List<InlineKeyboardButton>>();
            for (int i = 0; i < flights.Count; i++)
            {
                var flight = flights[i];

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