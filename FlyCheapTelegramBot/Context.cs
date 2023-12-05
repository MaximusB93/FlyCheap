using FlyCheapTelegramBot.StateModels;
using User = Telegram.Bot.Types.User;

namespace FlyCheapBot.Db.Models;

public static class Context
{
    public static List<User> Users = new List<User>();
    public static List<Fly> Flyes = new List<Fly>();
}