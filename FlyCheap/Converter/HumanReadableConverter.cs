using FlyCheap.Db;
using FlyCheap.Models;
using FlyCheap.Models.JsonModel;
using Microsoft.EntityFrameworkCore;

namespace FlyCheap.Converter;

public class HumanReadableConverter
{
    public HumanReadableAirways GetHumanReadableAirways(AirwaysJson airwaysJson)
    {
        var humanReadableAirways = new HumanReadableAirways
        {
            currency = airwaysJson.currency,
            data = new List<FlightDataForHumans>()
        };

        foreach (var flightData in airwaysJson.data)
        {
            var dataItem = new FlightDataForHumans
            {
                origin_airport = GetAirport(flightData.origin_airport),
                destination_airport = GetAirport(flightData.destination_airport),
                airline = GetAirline(flightData.airline),
                origin = GetCities(flightData.origin),
                destination = GetCities(flightData.destination),
                price = flightData.price,
                departure_at = flightData.departure_at,
                return_at = flightData.return_at,
                duration = flightData.duration,
                duration_back = flightData.duration_back,
                duration_to = flightData.duration_to,
                transfers = flightData.transfers,
                return_transfers = flightData.return_transfers,
                flight_number = flightData.flight_number
            };

            humanReadableAirways.data.Add(dataItem);
        }

        return humanReadableAirways;
    }

    private string GetCities(string citiesCode)
    {
        using (AirDbContext dbContext = new())
        {
            return dbContext.Cities
                .AsNoTracking()
                .FirstOrDefault(x => x
                    .code == citiesCode)
                ?.name;
        }
    }

    private string GetAirline(string airlineCode)
    {
        using (AirDbContext dbContext = new())
        {
            return dbContext.Airlines
                .AsNoTracking()
                .FirstOrDefault(x => x
                    .code == airlineCode)
                ?.name_translations.en;
        }
    }

    private string GetAirport(string airportCode)
    {
        using (AirDbContext dbContext = new())
        {
            return dbContext.Airports
                .AsNoTracking()
                .FirstOrDefault(x => x
                    .code == airportCode)
                .name;
        }
    }
}