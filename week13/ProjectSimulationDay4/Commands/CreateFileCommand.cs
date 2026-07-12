using Project.Commands;
using System;

namespace Project.Commands
{
    public class CreateFileCommand : Command
{
    public string FileName { get; set; }

    public CreateFileCommand(string rawLine, string fileName) 
            : base(rawLine, fileName)
        {
            RawLine = rawLine;
            FileName = fileName;
        }


    public override bool Execute()
        {
            global::System.Console.WriteLine($"File have been created! name :{FileName}");
        }

   
}
}