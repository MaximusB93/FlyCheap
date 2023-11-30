using Telegram.Bot;

namespace FlyCheapTelegramBot.TelegramBot;

public static class Exсeptions
{
    public static Task HandlePollingErrorAsync(ITelegramBotClient botClient, Exception update,
        CancellationToken token)
    {
        throw new NotImplementedException();
    }
}