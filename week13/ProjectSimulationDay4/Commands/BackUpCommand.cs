using Project.Commands; 

namespace Project.Commands
{
    public class BackUpCommand : Command
    {
        public string DatasetName { get; set; }

        public BackUpCommand(string rawLine, string datasetName)
            :base(rawLine,datasetName)
        {
            
            DatasetName = datasetName;
        }

        public override void Execute()
        {
            Console.WriteLine($"Data has been Backed up in : {DatasetName}");
        }
    }
}