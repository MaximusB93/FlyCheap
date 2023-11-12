﻿using FlyCheap.Models.Utils;

namespace FlyCheap.Models.JsonModel;

public class RoutesJson : NamedEntity
{
    public string airline_iata { get; set; }
    public object airline_icao { get; set; }
    public string departure_airport_iata { get; set; }
    public object departure_airport_icao { get; set; }
    public string arrival_airport_iata { get; set; }
    public object arrival_airport_icao { get; set; }
    public bool codeshare { get; set; }
    public int transfers { get; set; }
    public List<string> planes { get; set; }
}