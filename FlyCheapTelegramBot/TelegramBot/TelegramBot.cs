using System.Text;
using FlyCheap;
using FlyCheap.Api;
using FlyCheap.Api.Configuration;
using FlyCheap.Archive;
using FlyCheap.Models;
using FlyCheapTelegramBot.Catalog;
using FlyCheapTelegramBot.StateModels;
using FlyCheapTelegramBot.Utils;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Fly = FlyCheapTelegramBot.StateModels.Fly;

namespace FlyCheapTelegramBot.TelegramBot;

public class TelegramBot
{
    public TelegramBotClient _botClient = new TelegramBotClient(Configuration.Token);
    public CancellationTokenSource cts = new CancellationTokenSource();

    public ReceiverOptions _receiverOptions = new ReceiverOptions
    {
        AllowedUpdates = { },
        ThrowPendingUpdates = true
    };
    //Стартовый метод бота
    public async Task Start()
    {
        _botClient.StartReceiving(HandleUpdateAsync, Exсeptions.HandlePollingErrorAsync, _receiverOptions, cts.Token);
        var me = await _botClient.GetMeAsync();
        Console.WriteLine($"Start listening for @{me.Username}");
        await Task.Delay(Int32.MaxValue);
        cts.Cancel();
    }

    //Метод для обработки обновлений бота, бот прослушивает сообщения или нажатия inline клавиатуры)
    public async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken token)
    {
        //Заполнение каталога городами при старте бота
        if (CitiesCatalog.cities.Count == 0)
        {
            CitiesCatalog.cities = Catalogs.GetCities();
        }

        //Cрабатывает метод HandleCommandMessage, если приходит сообщение
        if (update.Type == UpdateType.Message && update.Message?.Text != null)
        {
            await HandleCommandMessage(botClient, update, update.Message);
            return;
        }

        //Cрабатывает метод HandleCallbackQuery, если inline клавиатура
        if (update.Type == UpdateType.CallbackQuery)
        {
            if (update.CallbackQuery != null)
                await HandleCallbackQuery(botClient, update.CallbackQuery, update.Message);
        }
    }

    //Метод ожидающий от пользователей ввода сообщения и обрабатывающий их
    public async Task HandleCommandMessage(ITelegramBotClient botClient, Update update, Message message)
    {
        var tgId = message.From.Id;
        var user = UserUtils.GetOrCreate(tgId);
        var text = message.Text.ToLower();

        //Команда /start
        if (text == "/start")
        {
            await botClient.SendTextMessageAsync(message.Chat.Id, "Выберите действие:",
                replyMarkup: MainMenu.GetMainMenu());
        }

        string? selectedCityFromList;
        Fly? flight;
        switch (user.InputState)
        {
            case InputState.None:
                return;

            //Парсим город вылета
            case InputState.DepartureСity:
                selectedCityFromList = DataBaseUtils.ParsingCity(tgId, text, user);
                if (selectedCityFromList != null)
                {
                    flight = DataBaseUtils.SearchFlyByUserTgId(tgId);
                    DataBaseUtils.SaveResultsToList(flight.DepartureCity, selectedCityFromList, InputState.ArrivalCity,
                        user);
                    DataBaseUtils.SendMessage(botClient, tgId,
                        $"Ваш город вылета {selectedCityFromList}, введите город назначения");
                }
                else
                    DataBaseUtils.SendMessage(botClient, tgId, "Город отправления не найден - повторите ввод");

                break;

            //Парсим город прибытия
            case InputState.ArrivalCity:
                selectedCityFromList = DataBaseUtils.ParsingCity(tgId, text, user);
                if (selectedCityFromList != null)
                {
                    flight = DataBaseUtils.SearchFlyByUserTgId(tgId);
                    DataBaseUtils.SaveResultsToList(flight.ArrivalCity, selectedCityFromList, InputState.DepartureDate,
                        user);
                    DataBaseUtils.SendMessage(botClient, tgId,
                        $"Ваш город назначение {selectedCityFromList}, введите дату вылета в формате ДД.ММ.ГГГГ");
                }
                else
                    DataBaseUtils.SendMessage(botClient, tgId, "Город назначения не найден - повторите ввод");

                break;

            //Парсим дату отправления
            case InputState.DepartureDate:
                var dateFromMessage = text;
                if (DateTime.TryParse(dateFromMessage, out DateTime parseDateTime))
                {
                    flight = DataBaseUtils.SearchFlyByUserTgId(tgId);
                    DataBaseUtils.SaveResultsToList(flight.DepartureDate, parseDateTime, InputState.FullState, user);
                }
                else
                    await botClient.SendTextMessageAsync(tgId,
                        "Дата вылета введена неверно - повторите ввод в формате  дд.мм.гггг");

                break;

            //Все данные получены, выводим ответ
            case InputState.FullState:
                flight = DataBaseUtils.SearchFlyByUserTgId(tgId);
                var result = GetFinalTickets(flight);
                await botClient.SendTextMessageAsync(tgId, "Результат поиска:" + result);
                break;

            //Дефолтный ответ бота в случае неправильного ввода команды пользователем
            default:
                await botClient.SendTextMessageAsync(tgId,
                    $"Для начала работы с ботом FlyCheap, введите команду /start \n");
                break;
        }
    }

    public string GetFinalTickets(Fly fly)
    {
        var sb = new StringBuilder();
        var apiTravelpayounts = new ApiTravelpayouts();
        var readableAirways =
            apiTravelpayounts.CreatingFlightSearchRequest(fly.DepartureCity, fly.ArrivalCity, fly.DepartureDate);

        /*if (readableAirways != 0)
        {
            foreach (var flightData in readableAirways)
            {
                sb.Append("Аэропорт отправления: " + flightData.origin_airport + "\n");
                sb.Append("Аэропорт назначения: " + flightData.destination_airport + "\n");
                sb.Append("Время отправления: " + flightData.departure_at + "\n");
                sb.Append("Авиакомпания: " + flightData.airline + "\n");
                sb.Append("Цена: " + flightData.price + " " + apiTravelpayounts.currency + "\n");
                sb.Append("Продолжительность полёта: " + flightData.duration + " Мин." + "\n");
                sb.Append("Номер рейса: " + flightData.flight_number + "\n");
                sb.Append("----------------------------------------------" + "\n");
            }

            return sb.ToString();
        }

        else
        {
            return "Авиарейсов по данному направлению не найдено!";
        }*/
        return "Авиарейсов по данному направлению не найдено!";
    }

    //Метод обрабатывающий нажатие inline-кнопок
    //Перенести в другой класс
    public async Task HandleCallbackQuery(ITelegramBotClient botClient, CallbackQuery callbackQuery, Message message)
    {
        var tgId = callbackQuery.From.Id;
        var user = UserUtils.GetOrCreate(tgId);

        await botClient.AnswerCallbackQueryAsync(callbackQuery.Id);

        //Поиск авиабилетов
        if (callbackQuery.Data.StartsWith("searchFlight"))
        {
            await botClient.SendTextMessageAsync(callbackQuery.Message.Chat.Id, "Введите город отправления");
            user.InputState = InputState.DepartureСity;
            var fly = new Fly(tgId); //Фиксируем Id юзера за поиском рейса 
            FlightsList.flights.Add(fly); //Помещаем его в лист
            return;
        }

        //Мои авиарейсы
        if (callbackQuery.Data.StartsWith("myFlight"))
        {
            await botClient.SendTextMessageAsync(callbackQuery.Message.Chat.Id, "Мои авиарейсы");
            return;
        }

        await botClient.SendTextMessageAsync(callbackQuery.Message.Chat.Id,
            $"You choose with data: {callbackQuery.Data}");
        //await botClient.SendTextMessageAsync(message.Chat.Id, "Бот не умеет распознавать сообщения. \r\n Выберите один из вариантов", replyMarkup: MainMenu.GetMainMenu());
        return;
    }
}