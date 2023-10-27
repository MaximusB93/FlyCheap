namespace FlyCheap;

public class DatabaseClient
{
    private RequestTravelpayouts _requestTravelpayouts = new RequestTravelpayouts();

    public void RequestDb()
    {
        using (var appDbContext = new AppDbContext())
        {
            appDbContext.DataTickets.Add(_requestTravelpayouts.DeserializeJson().data.LED._1);
            appDbContext.SaveChanges();
        }
    }
}