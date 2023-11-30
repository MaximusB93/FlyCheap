namespace FlyCheapTelegramBot.StateModels;

public class TgUser
{
    public long TgId { get; set; }
    public string DepartureСity { get; set; }
    public string ArrivalСity { get; set; }
    
    public string iataDepartureСity { get; set; }
    public string iataArrivalСity { get; set; }

    public DateTime DepartureAt { get; set; }

    public DateTime ReturnAt { get; set; }
}