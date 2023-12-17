using System.ComponentModel.DataAnnotations;

namespace FlyCheap.Models.Utils;

public class Coordinates
{
    public int Id { get; set; }
    public float lat { get; set; }
    public float lon { get; set; }
}