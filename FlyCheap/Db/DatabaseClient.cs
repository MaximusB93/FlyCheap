using FlyCheap.Api;

namespace FlyCheap.Db;

public class DatabaseClient
{
    //private RequestTravelpayouts _requestTravelpayouts = new RequestTravelpayouts();

    public void RequestDb()
    {
        using (var airDbContext = new AirDbContext())
        {
            var result = RequestAir.GetJsonData();
            result.Wait();
            var airports = RequestAir.DeserializeJson<TOutput>(result.Result);

            foreach (var airport in airports)
            {
                airDbContext.Airports.Add(airport);
            }

            airDbContext.SaveChanges();
        }


        /*using (var appDbContext = new AppDbContext())
        {
            appDbContext.DataTickets.Add(_requestTravelpayouts.DeserializeJson().data.LED._1);
            appDbContext.SaveChanges();
        }*/
    }
}