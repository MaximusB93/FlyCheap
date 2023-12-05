namespace FlyCheap.Archive;

public class FlightSearchOptions
{
    public static string Token = "f10cf5f14fc4ad7bafd93c78d96ce355";
    public static string Origin { get; set; } 
    public static string Destination { get; set; }
    public static DateTime DepartDate { get; set; }
    public static DateTime ReturnDate { get; set; }

    public FlightSearchOptions(string origin, string destination, DateTime departDate, DateTime returnDate)
    {
        Origin = origin;
        Destination = destination;
        DepartDate = departDate;
        ReturnDate = returnDate;
    }
}