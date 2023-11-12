using FlyCheap.Api;
using FlyCheap.Models;
using FlyCheap.StateModels;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace FlyCheap.TelegramBot;

public class TelegramBot
{
    public IATA _iata = new IATA();

    public TelegramBotClient _botClient = new TelegramBotClient(Configuration.Configuration.Token);
    public CancellationTokenSource cts = new CancellationTokenSource();

    private List<TgUser> _dbUsers = new List<TgUser>();

    public ReceiverOptions _receiverOptions = new ReceiverOptions
    {
        AllowedUpdates = { },
        ThrowPendingUpdates = true
    };

    public async Task Start()
    {
        _botClient.StartReceiving(HandleUpdateAsync, HandlePollingErrorAsync, _receiverOptions, cts.Token);
        var me = await _botClient.GetMeAsync();
        Console.WriteLine($"Start listening for @{me.Username}");
        Task.Delay(TimeSpan.MaxValue);
        cts.Cancel();
    }

    //Метод для обработки обновлений бота (здесь бот прослушивает сообщения {текстовые/c inline клавиатуры)
    //Заполнение каталога городами при старте бота
    public async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken token)
    {
        if (update.Type == UpdateType.Message && update.Message?.Text != null)
        {
            await HandleCommandMessage(botClient, update, update.Message);
            return;
        }

        if (update.Type == UpdateType.CallbackQuery)
        {
            if (update.CallbackQuery != null)
                await HandleCallbackQuery(botClient, update.CallbackQuery);
        }
    }

    public TgUser GetUser(long tgId)
    {
        TgUser tgUser = null;
        tgUser = _dbUsers.Find(x => x.TgId == tgId);
        if (tgUser == null)
        {
            tgUser = new TgUser { TgId = tgId };
            _dbUsers.Add(tgUser);
        }

        return tgUser;
    }

    //Метод ожидающий от пользователей ввода сообщения и обрабатывающий их
    public async Task HandleCommandMessage(ITelegramBotClient botClient, Update update, Message message)
    {
        var tgId = message.From.Id;
        var user = GetUser(tgId);
        var text = message.Text.ToLower();
        
       //Команда /start
        if (text == "/start")
        {
            await botClient.SendTextMessageAsync(message.Chat.Id, "Выберите действие:",
                replyMarkup: MainMenu.GetMainMenu());
        }
        
        //Город вылета
        else if (String.IsNullOrEmpty(user.DepartureСity))
        {
            user.DepartureСity = text;
            var departureCitiesIata = _iata.DeserializeJson(user.DepartureСity);
            user.iataDepartureСity = departureCitiesIata.destination.iata;
            if (departureCitiesIata.origin == null)
            {
                await botClient.SendTextMessageAsync(message.Chat.Id, $"Ошибка в городе отправления, введите снова");
                user.DepartureСity = null;
            }
            else
            {
                await botClient.SendTextMessageAsync(message.Chat.Id, "Введите город назначения");
            }
        }
        
        //Город назначения
        else if (String.IsNullOrEmpty(user.ArrivalСity))
        {
            user.ArrivalСity = text;
            var arrivalCitiesIata = _iata.DeserializeJson(user.ArrivalСity);
            user.iataArrivalСity = arrivalCitiesIata.destination.iata;
            if (arrivalCitiesIata.destination == null)
            {
                await botClient.SendTextMessageAsync(message.Chat.Id, $"Ошибка в городе назначения, введите снова");
                user.ArrivalСity = null;
            }
            else
                await botClient.SendTextMessageAsync(message.Chat.Id,
                    $"Ваш город отправления {user.DepartureСity} и город прибытия {user.ArrivalСity}");

            Task.Delay(3000);
            await botClient.SendTextMessageAsync(message.Chat.Id, $"Введите дату отправления в формате ДД.ММ.ГГГГ");
        }
        
        //Дата вылета
        else if (user.DepartureAt == DateTime.MinValue)
        {
            user.DepartureAt = DateTime.Parse(text);
            await botClient.SendTextMessageAsync(message.Chat.Id, $"Введите дату обратного рейса в формате ДД.ММ.ГГГГ");
        }
        
        //Дата обратного рейса
        else if (user.ReturnAt == DateTime.MinValue)
        {
            user.ReturnAt = DateTime.Parse(text);
            ResponseDataTickets responseDataTickets = new ResponseDataTickets();

            RequestTravelpayouts requestTravelpayouts =
                new RequestTravelpayouts(user.iataDepartureСity, user.iataArrivalСity,
                    user.DepartureAt.ToString("yyyy-MM-dd"),
                    user.ReturnAt.ToString("yyyy-MM-dd"));

            var tikets = requestTravelpayouts.DeserializeJson();
            await botClient.SendTextMessageAsync(message.Chat.Id,
                $"Из города {user.DepartureСity} в {user.ArrivalСity}, " +
                $"стоимость - {tikets.data.LED._1.Price}, " +
                $"авиакомпания - {tikets.data.LED._1.Airline}");
        }
    }

    //Метод обрабатывающий нажатие inline-кнопок
    public async Task HandleCallbackQuery(ITelegramBotClient botClient, CallbackQuery callbackQuery)
    {
        var tgId = callbackQuery.From.Id;
        //var user = UserUtils.GetOrCreate(tgId);

        await botClient.AnswerCallbackQueryAsync(callbackQuery.Id);

        //Поиск авиабилетов
        if (callbackQuery.Data.StartsWith("searchFlight"))
        {
            await botClient.SendTextMessageAsync(callbackQuery.Message.Chat.Id, "Введите город отправления");
        }

        if (callbackQuery.Data.StartsWith("myFlight"))
        {
            await botClient.SendTextMessageAsync(callbackQuery.Message.Chat.Id, "Мои авиарейсы");
        }
    }


    public async Task HandlePollingErrorAsync(ITelegramBotClient botClient, Exception update,
        CancellationToken token)
    {
        throw new NotImplementedException();
    }
}