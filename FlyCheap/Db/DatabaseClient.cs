namespace FlyCheap;

public class DatabaseClient
{
    private RequestTravelpayouts _requestTravelpayouts = new RequestTravelpayouts();

    public void RequestDb()
    {
        using (var appDbContext = new AppDbContext())
        {
            appDbContext.DataTickets.Add(_requestTravelpayouts.DeserializeJson().data.LED._1);
            /*appDbContext.DataTickets.Add(new _1()
            {
                Id = 3, Airline = "s", Departure_at = DateTime.Now.ToUniversalTime(), Return_at = "s", Expires_at = "s", Price = 1,
                Flight_number = 2
            });*/
            appDbContext.SaveChanges();
        }
    }
}