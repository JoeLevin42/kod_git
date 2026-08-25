
using CatalogConsumer.Models;
namespace CatalogConsumer.Models;

public class HostileProccessed
{
    public int unit_id { get; set; }
    public int model_id { get; set; }
    public string operator_name { get; set; }
    public DateTime first_seen_date { get; set; } //mybe need to be str for JSONSERILAZTION
    public string status { get; set; }
    public double home_lat { get; set; }
    public double home_lon { get; set; }

    public string threat_band { get; set; } //need to be calculated

    //NP

    public Uav Uav { get; set; } = null!;
    public ICollection<TrackProccessed> Tracks { get; set; } = new List<TrackProccessed>();

}