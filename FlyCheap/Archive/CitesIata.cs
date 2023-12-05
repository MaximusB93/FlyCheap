namespace FlyCheap.Archive;

public class Destination
{
    public string iata { get; set; }
    public string name { get; set; }
}

public class Origin
{
    public string iata { get; set; }
    public string name { get; set; }
}

public class CitesIata
{
    public Origin origin { get; set; }
    public Destination destination { get; set; }
}