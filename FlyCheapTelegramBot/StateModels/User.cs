namespace FlyCheapTelegramBot.StateModels;

public class User
{
    public long TgId { get; set; }
    public Role Role { get; set; }
    public InputState InputState { get; set; }
    public bool IsRegistered { get; set; }
}

public enum InputState
{
    None,
    DepartureСity,
    ArrivalCity,
    DepartureDate,
    FullState
}

public enum Role
{
    User,
    Admin
}