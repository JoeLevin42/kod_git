namespace day1simul {
    class Navy
    {
        static void Main()
        {
            //-input int trackI = ID(try convert to int)
            //-input int speed = speed(try convert to int)
            //-input int heading = heading(try conver to int if not between 0 - 359)
            //-input - status = status(Enum("cruising", "turning", "stopped", or "accelerating")

            string[] statuses = { "cruising", "turning", "stopped", "accelerating" };
            int trackId;
            int speed;
            int heading;
            string status;

            string input_trackId = Console.ReadLine();
            string input_speed = Console.ReadLine();
            string input_heading = Console.ReadLine();
            string input_status = Console.ReadLine();

             if   (int.TryParse(input_trackId, out trackId) &&
                int.TryParse(input_speed, out speed) && 
                int.TryParse(input_heading, out heading)&&
                 heading >= 0 && heading <=359)
            {
                Console.WriteLine("Everthing parsed into int");
                    
            }
            

            
            else
            {
                Console.WriteLine("Something went wrong");
            }
           

        }
    }
}