
using CatalogConsumer.Models;
namespace CatalogConsumer.Models;

public class Track
{
    public int track_id { get; set; }
    public int unit_id { get; set; }
    public string report_time { get; set; }
    public decimal latitude { get; set; }
    public decimal longitude { get; set; }
    public int altitude_m { get; set; }
    public int signal_strength { get; set; }

    //NP
    public HostileUnit HostileUnit { get; set; } = null!;
}