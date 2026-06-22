using System;

namespace Day2 {
    class A
    {

         static List<string> tracks = new List<string>();
         static List<double> speeds = new List<double>();

        static void AddTrack(string id , double speed)
        {
            tracks.Add(id);
            speeds.Add(speed);
        }

        static double AverageSpeed()
        {
            if (speeds.Count == 0) return 0.0;

            double sum = 0;
            foreach (int s in speeds) sum += s;
            return sum / speeds.Count;
        }
        
        static void Main()
        {
            AddTrack("hi", 100.0);
            double avg = AverageSpeed();
            Console.WriteLine(avg);
            }
            
        
    }
}