using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace FlyCheap;

public class TgBot
{
    //private static ICommand[] _commands;
    private static ReceiverOptions? receiverOptions;

    public static void Main2()
    {
        InitBot();
        //InitBotCommands();
        //WaitAdminCommands();
    }

    private static void WaitAdminCommands()
    {
        Console.ReadLine();
    }

    private static void InitBot()
    {
        Start();
    }

    private static void InitBotCommands()
    {
        /*_commands = new ICommand[4];

        _commands[0] = new HelloCommand();
        _commands[1] = new TextCommand();
        _commands[2] = new ImageCommand();
        _commands[3] = new StartCommand();*/
    }

    public static async void Start()
    {
        var botClient = new TelegramBotClient("6881248740:AAHqsZA_ttRmeoGSWOaM2JaqFvLhMfUaQvs");

        botClient.StartReceiving(
            updateHandler: HandleUpdateAsync,
            pollingErrorHandler: HandlePollingErrorAsync
        );

        var me = await botClient.GetMeAsync();

        Console.WriteLine($"Start listening for @{me.Username}");
    }

    private static async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken token)
    {
        /*var message = update.Message;

        if (message == null)
            return;

        if (message.Text != null)
            await TextSwitcher(botClient, message);

        else if (message.Photo != null)
            await Handlers.HandlePhoto(botClient, message);*/

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

    public static async Task HandleCallbackQuery(ITelegramBotClient botClient, CallbackQuery callbackQuery,
        Message message)
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
    /*private static async Task TextSwitcher(ITelegramBotClient botClient, Telegram.Bot.Types.Message message)
    {
        string user_text = message.Text.ToLower();

        if (message.Text.StartsWith("/"))
        {
            var command = _commands.FirstOrDefault(c => user_text.Contains(c.Name));

            if (command != null)
            {
                command.Execute(message, botClient, chatGPT);
                return;
            }
            else
            {
                Console.WriteLine("Command not finded");
            }
        }

        else if (user_text.Contains("нарисуй") || user_text.Contains("img"))
            await Handlers.HandlePhoto(botClient, message);
        else
            await Handlers.HandleText(botClient, message);
    }*/

    private static async Task HandlePollingErrorAsync(ITelegramBotClient botClient, Exception ex,
        CancellationToken token)
    {
        Console.WriteLine($"ERROR : {ex.Message}");
    }

    /*internal static class Handlers
    {
        public static async Task HandleText(ITelegramBotClient botClient, Telegram.Bot.Types.Message message)
        {
            return;
        }

        public static async Task HandlePhoto(ITelegramBotClient botClient, Telegram.Bot.Types.Message message)
        {
            Console.WriteLine($"{message.Chat.FirstName ?? "unkonw"}: [photo]");

            var response_from_gpt_ = await chatGPT.SendRequestImageAsync(message.Text);

            await botClient.SendTextMessageAsync(message.Chat.Id, response_from_gpt_);

            return;
        }
    }*/
}