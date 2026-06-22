using System;

namespace TrackSimul
{
    class Tracks
    {
        static List<int> id = new List<int>();
        static List<int> speed = new List<int>();
        static List<int> heading = new List<int>();

        static int[] ReadFromUser()
        {
            int id=0;
            int speed=0;
            int heading=0;

            bool flag = false;
            while (!flag)
            {
                Console.WriteLine("Please enter valid id");
                string userId = Console.ReadLine();
                bool isSuccess = int.TryParse(userId, out id);
                if (isSuccess) { flag = true; }
                else {
                    Console.WriteLine("The id not valid please enter valid intiger!");
                }
            }
            flag = false;
            while (!flag)
            {
                Console.WriteLine("Please enter the speed");
                string userSpeed = Console.ReadLine();
                bool isSuccess = int.TryParse(userSpeed, out speed);
                if (isSuccess) { flag = true; }
                else { Console.WriteLine("The speed is not valid please enter valid intiger!"); }
            }

            flag = false;
            while (!flag)
            {
                Console.WriteLine("Please enter the heading");
                string userHeading = Console.ReadLine();
                bool isSuccess = int.TryParse(userHeading, out heading);
                if (isSuccess) { flag = true; }
                else { Console.WriteLine("The heading is not valid please enter vlaid intiger"); }
            }

            int[] attributes = {id,speed,heading};
            return attributes;

        }
                




        
    }
}