using FlyCheap.Converter;
using FlyCheap.Db;
using FlyCheap.Models;
using FlyCheap.Models.Db;
using FlyCheap.Models.JsonModel;
using FlyCheap.Utility;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace FlyCheap.Api;

public class ApiTravelpayouts
{
    // Параметры запроса
    string currency = "RUB"; // Валюта цен (по умолчанию - RUB)

    //string origin = "AER"; // Код IATA города или аэропорта отправления
    //string destination = "SVO"; // Код IATA города или аэропорта назначения
    //string departureDate = "2023-09"; // Дата отправления (YYYY-MM или YYYY-MM-DD)
    //string returnDate = "2023-10"; // Дата возврата (не указывайте для билетов в один конец)
    string directFlight = "false"; // Билеты без пересадок (true или false, по умолчанию: false)
    string market = "ru"; // Рынок источника данных (по умолчанию ru)
    int limit = 30; // Количество записей на странице (по умолчанию 30, макс. 1000)
    int page = 1; // Номер страницы (для пропуска результатов)
    string sorting = "price"; // Сортировка цен (по цене или по популярности маршрута, по умолчанию: по цене)

    string
        unique = "false"; // Возвращает только уникальные маршруты (если указан только origin, true или false, по умолчанию: false)


    public HumanReadableAirways CreatingFlightSearchRequest(string departureCity, string arrivalCity,
        DateTime departureDate)
    {
        var humanReadableConverter = new HumanReadableConverter();
        //Поиск IATA аэропортов по названию городов
        var departureAirports = FindAirports(departureCity);
        var arrivalAirports = FindAirports(arrivalCity);

        var flightData = new ObjectForRequestFlight()
        {
            departureAirports = departureAirports,
            arrivalAirports = arrivalAirports,
            departureDate = $"{departureDate.Year}-{departureDate.Month:D2}-{departureDate.Day:D2}",
            returnDate = null
        };

        return humanReadableConverter.GetHumanReadableAirways(RequestFlight(flightData));
    }

    private AirwaysJson RequestFlight(ObjectForRequestFlight flightData)
    {
        AirwaysJson airwaysJson = new AirwaysJson
        {
            currency = "",
            success = false,
            data = new List<FlightData>()
        };

        var httpRequest = new ObjectForHttpRequest();

        foreach (var airportStart in flightData.departureAirports)
        {
            httpRequest.origin = airportStart.code;
            foreach (var airportFinal in flightData.arrivalAirports)
            {
                httpRequest.destination = airportFinal.code;
                httpRequest.departureDate = flightData.departureDate;
                httpRequest.returnDate = flightData.returnDate;
                Thread.Sleep(100);

                try
                {
                    string content = HttpRequest(httpRequest);
                    if (!string.IsNullOrEmpty(content))
                    {
                        AirwaysJson airwaysResult = JsonConvert.DeserializeObject<AirwaysJson>(content);
                        if (airwaysResult.success)
                        {
                            airwaysJson.data.AddRange(airwaysResult.data);
                            airwaysJson.success = true;
                            airwaysJson.currency = airwaysResult.currency;
                        }
                    }
                }
                catch (Exception e) // Тут можно логировать ошибки
                {
                    Console.WriteLine("Произошла ошибка при парсинге JSON: " + e.Message);
                }
            }
        }

        return airwaysJson;
    }

    private string? HttpRequest(ObjectForHttpRequest httpRequest)
    {
        string returnDateConstructor =
            string.IsNullOrEmpty(httpRequest.returnDate) ? "" : $"return_at={httpRequest.returnDate}&";

        string url = $"https://api.travelpayouts.com/aviasales/v3/prices_for_dates?" +
                     $"origin={httpRequest.origin}&destination={httpRequest.destination}&departure_at={httpRequest.departureDate}" +
                     $"&{returnDateConstructor}unique={unique}&sorting={sorting}&direct={directFlight}" +
                     $"&cy={currency}&limit={limit}&page={page}&one_way=true&token={Configuration.Configuration.Token}";

        //Console.WriteLine(url);
        using (HttpClient client = new HttpClient())
        {
            try
            {
                var response = client.GetAsync(url).Result;
                string content = "";

                if (response.IsSuccessStatusCode)
                {
                    content = response.Content.ReadAsStringAsync().Result;
                    //Console.WriteLine("content ===> " + content);
                    return content;
                }
                else // Тут можно логгировать ошибки
                {
                    Console.WriteLine("Ошибка запроса");
                    content = response.Content.ReadAsStringAsync().Result;
                    //Console.WriteLine("content ===> " + content);
                    //throw new InvalidOperationException("Ошибка запроса!");
                    return content;
                }
            }
            catch (Exception ex) // Тут можно логгировать ошибки
            {
                Console.WriteLine($"Произошла ошибка: {ex.Message}");
                return null;
            }
        }

        return null;
    }

    public List<Airports>? FindAirports(string cityOrAirport = "", string iataType = "airport")
    {
        using (AirDbContext airDbContext = new())
        {
            //Возвращаем IATA города на основании названия города
            var cityCode = airDbContext.Cities
                .AsNoTracking()
                .FirstOrDefault(x =>
                    x.name.Contains(cityOrAirport.Trim()) || x.name_translations.en.Contains(cityOrAirport.Trim()))
                ?.code;

            if (cityCode != null)
            {
                //Возвращаем IATA аэропортов на основании IATA города
                return airDbContext.Airports
                    .AsNoTracking()
                    .Where(x => x.city_code == cityCode && x.iata_type == iataType && x.flightable == true)
                    .ToList();
            }

            //Возвращаем IATA аэропорта на основании названия города
            var airport = airDbContext.Airports
                .AsNoTracking()
                .FirstOrDefault(x =>
                    x.name.Contains(cityOrAirport.Trim()) || x.name_translations.en.Contains(cityOrAirport.Trim()));
            if (airport != null)
            {
                List<Airports>? airportsList = new List<Airports>();
                airportsList.Add(airport);
                return airportsList;
            }

            Console.WriteLine("По вашему запросу ничего не найдено."); // Тут можно логгировать ошибки
            return default;
        }
    }
}