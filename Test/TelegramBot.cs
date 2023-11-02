using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace Test;

public class TelegramBot
{
    //public IATA _iata = new IATA();

    //public static TelegramBotClient _botClient = new TelegramBotClient("6881248740:AAHqsZA_ttRmeoGSWOaM2JaqFvLhMfUaQvs");
    //public CancellationTokenSource cts = new CancellationTokenSource();

    /*public ReceiverOptions _receiverOptions = new ReceiverOptions
    {
        AllowedUpdates = { },
        ThrowPendingUpdates = true
    };*/

    // StartReceiving does not block the caller thread. Receiving is done on the ThreadPool.
    /*static ReceiverOptions _receiverOptions = new()
    {
        AllowedUpdates = Array.Empty<UpdateType>() // receive all update types except ChatMember related updates
    };*/

    public static async void StartBot()
    {
        var botClient = new TelegramBotClient("6881248740:AAHqsZA_ttRmeoGSWOaM2JaqFvLhMfUaQvs");
        botClient.StartReceiving(updateHandler: HandleUpdateAsync,
            pollingErrorHandler: HandlePollingErrorAsync);
        var me = await botClient.GetMeAsync();
        Console.WriteLine($"Start listening for @{me.Username}");
        //Task.Delay(TimeSpan.MaxValue);

        //Console.ReadLine();
        //cts.Cancel();
    }

    //Метод для обработки обновлений бота (здесь бот прослушивает сообщения {текстовые/c inline клавиатуры)
    //Заполнение каталога городами при старте бота
    private static async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken token)
    {

        if (update.Type == UpdateType.Message && update.Message?.Text != null)
        {
            await HandleCommandMessage(botClient, update.Message);
            return;
        }

        if (update.Type == UpdateType.CallbackQuery)
        {
            await HandleCallbackQuery(botClient, update.CallbackQuery, update.Message);
        }
    }

    //Метод ожидающий от пользователем ввода сообщения и обрабатывающий их
    public static async Task HandleCommandMessage(ITelegramBotClient botClient, Message message)
    {
        var tgId = message.From.Id;
        //var user = UserUtils.GetOrCreate(tgId);
        var text = message.Text.ToLower();

        if (text == "/start")
        {
            await botClient.SendTextMessageAsync(message.Chat.Id, "Выберите действие:",
                replyMarkup: MainMenu.GetMainMenu());
            return;
        }
    }

    public static async Task HandleCallbackQuery(ITelegramBotClient botClient, CallbackQuery callbackQuery, Message message)
    {
        var tgId = message.From.Id;
        //var user = UserUtils.GetOrCreate(tgId);

        await botClient.AnswerCallbackQueryAsync(callbackQuery.Id);

        //Поиск авиабилетов
        if (callbackQuery.Data.StartsWith("searchFlight"))
        {
            await botClient.SendTextMessageAsync(callbackQuery.Message.Chat.Id, "Введите город отправления");
        }
    }


    private static async Task HandlePollingErrorAsync(ITelegramBotClient botClient, Exception ex,
        CancellationToken token)
    {
        Console.WriteLine($"ERROR : {ex.Message}");
    }


    // async static Task Start(ITelegramBotClient botClient, Update update, CancellationToken token)
    // {
    //     var message = update.Message;
    //     if (message.Text != null)
    //     {
    //         Console.WriteLine($"{message.Chat.Username} : {message.Text}");
    //         if (message.Text.ToLower().Contains("start"))
    //         {
    //             await botClient.SendTextMessageAsync(message.Chat.Id, "Вас приветствует Бот по дешевым авиабилетам");
    //             Thread.Sleep(2000);
    //             await botClient.SendTextMessageAsync(update.Message.Chat.Id, "Введите город отправления");
    //             return;
    //         }
    //     }
    // }
    //
    //
    // async Task Update(ITelegramBotClient botClient, Update update, CancellationToken token)
    // {
    //     await Start(botClient, update, token);
    //
    //     var message = update.Message;
    //     if (message.Text != null)
    //     {
    //         var originMessageText = message.Text;
    //         if (originMessageText == "Казань")
    //         {
    //             if (message.Text.ToLower().Contains(originMessageText))
    //             {
    //                 await botClient.SendTextMessageAsync(message.Chat.Id, "Введите город прибытия");
    //                 var destinationMessageText = message.Text;
    //                 if (message.Text.ToLower().Contains(destinationMessageText))
    //                 {
    //                     _iata.DeserializeJson(originMessageText, destinationMessageText);
    //                 }
    //
    //                 return;
    //             }
    //         }
    //     }
    // }
    //
    // private Task Error(ITelegramBotClient botClient, Exception update, CancellationToken token)
    // {
    //     throw new NotImplementedException();
    // }
}