
using CatalogConsumer.Models;
using System.ComponentModel.DataAnnotations;
namespace CatalogConsumer.Models;

public class Track
{
    [Key]
    public int track_id { get; set; }
    public int unit_id { get; set; }
    public DateTime report_time { get; set; }
    public double latitude { get; set; }
    public double longitude { get; set; }
    public int altitude_m { get; set; }
    public int signal_strength { get; set; }

    //NP
    public HostileUnit HostileUnit { get; set; } = null!;
}