
using System.Text.Json;

namespace A
{
    class NegativeValueException : ArgumentException
    {
        public NegativeValueException()
            : base("This value cannot be negative") { }
    }

    class StringInsteadIntException : ArgumentException
    {
        public StringInsteadIntException()
            : base("This value have to be int not string!!") { }
    }

    class Report
    {
        public int Id { get; set; }
        public string Category { get; set; }
        public int Priority { get; set; }

        public Report() { }
    }

    class Read
    {
        public List<string[]> RawData(string path)
        {
            List<string[]> splitedLines = new();
            if (File.Exists(path))
            {
                string[] dataRead = File.ReadAllLines(path);
                foreach (string line in dataRead)
                {
                    splitedLines.Add(line.Trim().Split(" "));
                }


            }
            return splitedLines;
        }

        public List<Report> ValidiatedData(List<string[]> listOfData)
        {
            List<Report> CleanApprovedData = new();
            foreach (string[] report in listOfData)
            {
                try
                {
                    if (!(int.TryParse(report[0], out int validId) &&
                            int.TryParse(report[2], out int validPriority))) { throw new StringInsteadIntException(); }

                    if (validPriority < 0 || validId < 0) throw new NegativeValueException();

                    CleanApprovedData.Add(new Report { Id = validId, Category = report[1], Priority = validPriority }); 
                }
                catch (StringInsteadIntException ex)
                {
                    Console.WriteLine($"ERROR {ex.Message}");
                }
                catch (NegativeValueException ex)
                {
                    Console.WriteLine($"ERROR {ex.Message}");
                }
            }
            return CleanApprovedData;
        }
     
     public void printStatistics(List<string[]> rawData , List<string[]> validatedData)
        {
            Console.WriteLine("--- Statistics ---");
            Console.WriteLine($"TOTAL ROWS : {rawData.Count()} ");
            Console.WriteLine($"TOTAL VALID ROWS {validatedData.Count()}");
            Console.WriteLine($"TORAL IN-VALID {rawData.Count() - validatedData.Count()}");

        }

       
     public void SaveToJson(List<Report> validatedData)
        {
            try
            {
                string json = JsonSerializer.Serialize(validatedData);
                File.WriteAllText("reports.json", json);
            }
            catch (JsonException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    public void ReadFromJson(string path)
        {
            try
            {
                string json = File.ReadAllText(path);
                List<Report> reports = JsonSerializer.Deserialize<List<Report>>(json);
            }
            catch (JsonException ex)
            {
                Console.WriteLine("The json file is corrupted");
            }
            catch (IOException ex)
            {
                Console.WriteLine("Could not read file");
            }
        
        }
        


        class Program
        {
            public static void Main(string[] args)
            {
                Read reader = new Read();
                reader.RawData("w4d1_field_reports_input.txt");
            }

        }
    }
}
