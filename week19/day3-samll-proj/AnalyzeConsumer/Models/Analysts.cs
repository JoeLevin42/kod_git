using AnalyzeConsumer.Models;

namespace AnalyzeConsumer.Models;

public class Analysts
{
    
    public int analyst_id { get; set; }
    public string name { get; set; }
    public string arena { get; set; }
    public string specialty { get; set; }

    public ICollection<Calls> Calls { get; set; } = new List<Calls>();
}