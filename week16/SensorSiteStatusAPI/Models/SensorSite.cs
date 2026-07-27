namespace SensorSiteStatusAPI.Models;

public class SensorSite
{
    public string Id { get; set; }
    public string SiteName { get; set; }
    public string Zone { get; set; }
    public string Status { get; set; } //Enum?????
    public DateTime LastContact { get; set; }
}