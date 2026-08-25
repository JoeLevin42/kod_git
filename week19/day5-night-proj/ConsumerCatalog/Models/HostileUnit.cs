
using CatalogConsumer.Models;
using System.ComponentModel.DataAnnotations;
namespace CatalogConsumer.Models;

public class HostileUnit
{
    [Key]
    public int unit_id { get; set; }
    public int model_id { get; set; }
    public string operator_name { get; set; }
    public DateTime first_seen_date { get; set; } //mybe need to be str for JSONSERILAZTION
    public string status { get; set; }
    public double home_lat { get; set; }
    public double home_lon { get; set; }

    //NP

    public Uav Uav { get; set; } = null!;
    public ICollection<Track> Tracks { get; set; } = new List<Track>();
}