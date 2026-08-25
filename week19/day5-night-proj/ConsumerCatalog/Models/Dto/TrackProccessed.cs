
using CatalogConsumer.Models;
namespace CatalogConsumer.Models;

public class TrackProccessed
{
    public int track_id { get; set; }
    public int unit_id { get; set; }
    public DateTime report_time { get; set; }
    public double latitude { get; set; }
    public double longitude { get; set; }
    public int altitude_m { get; set; }
    public int signal_strength { get; set; }

    public string sector_code { get; set; } //need to be claculated
    //NP
    public HostileProccessed HostileProccessed { get; set; } = null!;

}