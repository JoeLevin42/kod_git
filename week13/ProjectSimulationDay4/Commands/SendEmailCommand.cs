using Project.Commands;

namespace Project.Commands
{
    public class SendEmailCommand : Command
    {
        public string Email { get; set; }

        public SendEmailCommand(int id, string emailAdress)
        {
            Id = id;
            Email = emailAdress;
        }

        public override bool Execute()
        {
            Console.WriteLine($"Email has been sent to : {Email}");
            
        }
    }
}