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
            string[] promts = { "id", "speed", "heading" };
            int[] attributes = new int[3];

            for (int i = 0; i < 3; i++)
            {
                bool flag = false;
                while (!flag)
                {
                    Console.WriteLine($"Please enter {promts[i]}");
                    string userInput = Console.ReadLine();
                    bool isSuccess = int.TryParse(userInput, out attributes[i]);
                    if (isSuccess) { flag = true; }
                    else { Console.WriteLine($"The imput of {promts[i]} is not valid please input valid intiger!"); }


                }
            }
            return attributes;
        }

        static void AddTrack(int[] arr, List<int> id, List<int> speed, List<int> heading)
        {

            id.Add(arr[0]);
            speed.Add(arr[1]);
            heading.Add(arr[2]);

        }

        static int GetIndexById(int searchId, List<int> id)
        {
            for (int i = 0; i < id.Count; i++)
            {
                if (id[i] == searchId) { return i; }
            }
            return -1;
        }


        static void RemoveItem(int searchID, List<int> id, List<int> speed, List<int> heading)
        {
            int targetIndex = GetIndexById(searchID, id);
            id.RemoveAt(targetIndex);
            speed.RemoveAt(targetIndex);
            heading.RemoveAt(targetIndex);


        }

        static void GetAllTracks(List<int> id, List<int> speed, List<int> heading)
        {
            for (int i = 0;  i< id.Count; i++)
            {
                Console.WriteLine($"ID: {id[i]} , Speed {speed[i]}, Heading: {heading[i]}");
            }
        }

        static List<string> GetFilteredTracks(int tresholdSpeed,List<int> id, List<int> speed, List<int> heading)
        {
            List<string> filteredStr = new List<string>();
            for (int i = 0;i <id.Count; i++)
            {
             if (speed[i] >= tresholdSpeed)
                {
                    filteredStr.Add($"ID : {id[i]}, Speed {speed[i]}, Heading {heading[i]}");
                }   
            }
            return filteredStr;
        }

        static void PrintLines(List<string> listi)
        {
            for (int i = 0; i < listi.Count; i++)
            {
                Console.WriteLine(listi[i]);
            }
        }

        static int Count(List<int> id)
        {
            return (id.Count);
        } 
        static int MaxSpeed(List<int> id, List<int> speed)
        {
            int MaxiSpeedi = speed.Max();
            int MaxiSpeediIndex = speed.IndexOf(MaxiSpeedi);
            int MaxiId = id[MaxiSpeediIndex];

            return MaxiId;
        }

        static double AverageSpeed(List<int> speed)
        {
            return speed.Average();
        }

        static string ReturnObject(int targetIndex ,List<int> id, List<int> speed, List<int> heading)
        {
            return $"ID: {id[targetIndex]}, Speed {speed[targetIndex]}, Heading {heading[targetIndex]}";
        }
     
        
      
        static void Main()
        {
            List<int> id = new List<int>();
            List<int> speed = new List<int>();
            List<int> heading = new List<int>();



           

        }








    }
}


