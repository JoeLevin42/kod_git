using System;

namespace Intel
{
    class IntelSystem
    {
        enum classification { Friendly, Hostile, Unidentified }

        static int GetID()
        {
            Console.WriteLine("Please enter ID");
            string userInput = Console.ReadLine();
            int numericInput = ParseToInt(userInput);

            if (numericInput > 0) { return numericInput; }
            return -1;

        }

        static classification GetClassification()
        {
            while (true)
            {
                Console.WriteLine("Please enter classification");
                string userInput = Console.ReadLine();

                bool isSuccess = Enum.TryParse<classification>(userInput, true, out classification userEnum);

                if (isSuccess)
                {
                    return userEnum;
                }
            }
        }

            static int GetStrenght()
            {

                while (true)
                {
                    Console.WriteLine("Please enter strenght");
                    string userInput = Console.ReadLine();
                    
                    int numericInput = ParseToInt(userInput);
                    if (numericInput > 0) { return numericInput; }

                    else { return -1; }
                }

            }


            static int ParseToInt(string param)
            {
                int numericParam = 0;
                bool isSuccess = int.TryParse(param, out numericParam);

                if (isSuccess) { return numericParam; }
                else { return -1; }

            }
            
   


            static void Main()
            {
                List<int> sourceId = new List<int>();
                List<string> classifation = new List<string>();
                List<int> strenght = new List<int>();

                GetClassification();

            }

        
    }
}