
using DashbordApi.Models;

namespace DashbordApi.Models;

public class Analysts
{
    public int analyst_id { get; set; }
    public string name { get; set; }
    public string arena { get; set; }
    public string specialty { get; set; }

    //NP
    public ICollection<Calls>  Calls { get; set; }
}