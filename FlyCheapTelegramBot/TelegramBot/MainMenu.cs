using Telegram.Bot.Types.ReplyMarkups;

namespace FlyCheap.TelegramBot;

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
}