
using Day2.Models;
using System.Text.Json;

namespace Day2
{

  

    namespace Models
    {
        public class Report
        {
            public int Id { get; set; }
            public string Category { get; set; }
            public int Priority { get; set; }
            public string Zone { get; set; }
            public int SignalStrength { get; set; }
            public string Shift { get; set; }
            
            public Report() { }
        }

    }

    class JsonRW
    {
        public List<Report> ReadFromJsonToObj(string path)
        {
            string json = File.ReadAllText(path);
            
            try {
                List<Report> reports = JsonSerializer.Deserialize<List<Report>>(json);
                return reports;
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"Error this cannot desrialize {ex.Message}");
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
                
        return null;
            }
        
        public void WriteToJsonFromObj<T>(string path, List<T> reports)
        {
            try 
            { 
            string json = JsonSerializer.Serialize(reports);
                File.WriteAllText(path, json);

             }
            catch (JsonException ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
        }

    }

    class PartA
    {
        public int ReportCounter<T>(List<T> reports) //1
        {
            int totalReports = reports.Count();
            return totalReports;
        }

        public List<int> IdOfSignal(List<Report> reports) // 2
        {
            List<int> Ids = reports
                .Where(r => r.Category == "SIGNAL")
                .Select(r => r.Id).ToList();

            return Ids;
        }


        public List<int> IdOfSignalFilter(List<Report> reports) // 3
        {
            List<int> Ids = reports
               .Where(r => r.Priority >= 4)
               .Select(r => r.Id).ToList();

            return Ids;
        }

        public List<int> IdOfNightShiftNorth(List<Report> reports)// 4
        {
            List<int> Ids = reports
                .Where(r => r.Shift == "Night" && r.Zone == "North")
                .Select(r => r.Id).ToList();
            return Ids;
        }

        public List<(int Id , int Priority)> IdAndPrComms(List<Report> reports) //5
        {
            List<(int Id , int Priority)> result = reports
                .Where(r => r.Category == "COMMS")
                .Select(r => (r.Id, r.Priority)).ToList();

            return result; 
        }
        
        public List<int> IdOfSingalStWithCond1(List<Report> reports) //6
        {
            List<int> result = reports
                    .Where(r => r.SignalStrength >= 70 && r.SignalStrength <= 90)
                    .Select(r => r.Id).ToList();
            return result;
    
        }

        public List<int> IdNotInWest(List<Report> reports) //7
        {
            List<int> result = reports
                .Where(r => r.Zone != "West")
                .Select(r => r.Id).ToList();

            return result;
        }

        public List<int> IdOrderByPr(List<Report> reports) //8
        {
            List<int> result = reports
                .OrderBy(r => r.Priority)
                .Select(r => r.Priority).ToList();

            return result;
        }

        public List<int> IdHighZone(List<Report> reports) //9\
        {
            List<int> result = reports
                .OrderBy(r => r.Zone)
                .Select(r => r.Id).ToList();

            return result;
        }

        public List<int> ThreeIdTopSingalStrength(List<Report> reports) //10
        {
            List<int> result = reports
                .OrderByDescending(r => r.SignalStrength)
                .Select(r => r.Id)
                .Take(3).ToList();

            return result;
        }
        
        public List<int> TwoWeekestSingalStrngth(List<Report> reports) //11
        {
            List<int> result = reports
                .OrderBy(r => r.SignalStrength)
                .Select(r => r.Id)
                .Take(2).ToList();
            return result;
        }


        public List<int> IdSkipFirstHighReport(List<Report> reports) //12
        {
            List<int> result = reports
                .OrderBy(r => r.Priority)
                .Select(r => r.Id)
                .Skip(5).ToList();

            return result
        }

        public List<int> IdCond2(List<Report> reports) //13
        {
            List<int> result = reports
                .Where(r => r.Category == "IMAGERY")
                .OrderBy(r => r.SignalStrength)
                .Select(r=> r.Id).ToList();

            return result;
                
        }

        public int CountP5(List<Report> reports) //14 
        {
            int result = reports
                .Where(r => r.Priority > 5)
                .Select(r => r)
                .Count();
            return result;
        }

        public double SingalStrngthAvg(List<Report> reports) // 15
        {
            double result = reports
                .Average(r => r.SignalStrength);
            return result;

        }

        public int StrongestSignalValue(List<Report> reports) //16
        {
            int result = reports
                .OrderByDescending(r => r.SignalStrength)
                .Select(r => r.SignalStrength)
                .First();
                
                
            return result;
        }

        public int WeekestSingalValue(List<Report> reports) // 17 
        {
            int result = reports
                .OrderBy()
        }
                

                

           

    }

}