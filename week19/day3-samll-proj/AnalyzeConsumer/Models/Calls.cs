using AnalyzeConsumer.Models;


namespace AnalyzeConsumer.Models;

public class Calls
{
    public int call_id { get; set; }
    public int analyst_id { get; set; }
    public int agent_id { get; set; }
    public int word_alpha { get; set; }
    public int word_bravo { get; set; }
    public int word_charlie { get; set; }
    public Analysts Analysts { get; set; }
}