namespace FlyCheapTelegramBot.StateModels;

public class Fly
{
    public Guid Id { get; set; } //Разобраться
    public long UserTgId { get; set; }
    public string DepartureCity { get; set; }
    public string ArrivalCity { get; set; }
    public DateTime DepartureDate { get; set; }
    public string resultTickets = null;

    public Fly(long userTgId)
    {
        Id = Guid.NewGuid();
        UserTgId = userTgId;
    }
}