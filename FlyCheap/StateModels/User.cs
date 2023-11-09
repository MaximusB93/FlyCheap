using FlyCheap.Vitzen;

namespace FlyCheap.StateModels;

public class User
{
    public long TgId { get; set; }
    public Role Role { get; set; }
    public InputState InputState { get; set; }
    public string UserName { get; set; }
    public bool IsRegistered { get; set; }
}

public enum InputState
{
    Nothing,
    DepartureСity,
    ArrivalСity,
    DepartureDate,
    FullState
}