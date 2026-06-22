using System;

namespace Navysimulation
{
    class Navy
    {
        static void Main()
        {
            string[] statuses = { "cruising", "turning", "stopped","accelerating"};
            int trackId = 0;
            int speed = 0;
            string speedCl = "";
            int heading = 0;
            string status = "";


            bool flag = false;
            while (!flag)
            {
                Console.WriteLine("Please enter trackID");
                string inputTrackId = Console.ReadLine();
                if (int.TryParse(inputTrackId, out trackId))
                {
                    Console.WriteLine("The convert successed");
                    flag = true;
                }
                else
                {
                    Console.WriteLine("Try again the input is invalid");
                }
            }

            flag = false;
            while (!flag)
            {
                Console.WriteLine("pleae enter speed");
                string inputSpeed = Console.ReadLine();
                if (int.TryParse(inputSpeed , out speed))
                {
                    if (speed <= 100) {
                        speedCl = "SLOW";
                    }
                    else if (speed > 100 && speed <= 300)
                    {
                        speedCl = "MEDIUM";
                    }
                    else if (speed > 300)
                    {
                        speedCl = "FAST";
                    }
                    else if (speed <0){
                        Console.WriteLine("You cant use negative numbers");
                        continue;
                    }
                    flag = true;
                    Console.WriteLine("The convert and classification successed!");
                        }
                else
                {
                    Console.WriteLine("Something went wrong try again");
                }
                    
                    }

                        

                }
            }


        }
    
