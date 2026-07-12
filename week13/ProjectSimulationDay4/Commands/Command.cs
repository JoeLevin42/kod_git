namespace Project.Commands
{
    public abstract class Command
    {
        public string RawLine { get; }
        public string Target { get; }

        protected Command(string rawLine, string target)
        {
            if (string.IsNullOrWhiteSpace(target))
            {
                throw new ArgumentException("Target cannot be empty"); //Need to be catched in he next...
            }

            RawLine = rawLine;
            Target = target;
        }

        public abstract void Execute();
    }
}