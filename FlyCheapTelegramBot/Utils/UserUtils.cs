using FlyCheapTelegramBot.Catalog;
using FlyCheapTelegramBot.StateModels;

namespace FlyCheapTelegramBot.Utils;

public class UserUtils
{
    public static User GetOrCreate(long tgId)
    {
        var user = UsersList.users.FirstOrDefault(x => x.TgId == tgId);
        if (user != null)
        {
            return user;
        }

        user = new User()
        {
            TgId = tgId,
            Role = Role.User,
            IsRegistered = true,
            InputState = InputState.None
        };
        UsersList.users.Add(user);
        return user;
    }
}