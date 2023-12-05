using FlyCheap.Db;
using FlyCheap.Models.Db;
using FlyCheap.Models.Utils;

namespace FlyCheap.Archive;

public class DatabaseClient
{
    //private ApiTravelpayoutsCopy _requestTravelpayouts = new ApiTravelpayoutsCopy();

    public void RequestDb<TOutput>() where TOutput : IEnumerable<NamedEntity>
    {
        using (var airDbContext = new AirDbContext())
        {
            var result = RequestAir.GetJsonData();
            result.Wait();
            var airports = RequestAir.ConvertFromJsonToDbFormat<TOutput>(result.Result);

            foreach (var airport in airports)
            {
                airDbContext.Airports.Add((Airports)airport);
            }

            airDbContext.SaveChanges();
        }


        /*using (var appDbContext = new AppDbContext())
        {
            appDbContext.DataTickets.Add(_requestTravelpayouts.ConvertFromJsonToDbFormat().data.LED._1);
            appDbContext.SaveChanges();
        }*/
    }
}