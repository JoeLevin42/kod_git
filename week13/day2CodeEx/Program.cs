using System;
using System.Collections.Generic;

namespace A
{

    abstract class SatelliteImage
    {
        public int Id { get; }
        public double CloudCover { get; }
        public string Sensor { get; }

        protected SatelliteImage(int id, double cloudCover, string sensor)
        {
            if (cloudCover < 0 || cloudCover > 100)
                throw new ArgumentException($"Corrupt record {id}: invalid cloud cover");

            Id = id;
            CloudCover = cloudCover;
            Sensor = sensor;
        }

        public abstract int Score();

        public virtual string Format()
        {
            return $"Image {Id} | {CloudCover:0}% | {Sensor}";
        }
    }

   
    interface IRetaskable
    {
        void Retask();
    }

    interface IThermalCalibratable
    {
        void CalibrateThermal();
    }


    class SARImage : SatelliteImage, IRetaskable
    {
        public SARImage(int id, double cloudCover)
            : base(id, cloudCover, "SAR") { }

        public override int Score()
        {
            return 100 - (int)CloudCover;
        }

        public void Retask()
        {
            Console.WriteLine($"SAR {Id} retasked.");
        }
    }

    class EOImage : SatelliteImage
    {
        public EOImage(int id, double cloudCover)
            : base(id, cloudCover, "EO") { }

        public override int Score()
        {
            return 60 - (int)CloudCover;
        }
    }

    class IRImage : SatelliteImage, IThermalCalibratable
    {
        public IRImage(int id, double cloudCover)
            : base(id, cloudCover, "IR") { }

        public override int Score()
        {
            return 40 - (int)CloudCover;
        }

        public void CalibrateThermal()
        {
            Console.WriteLine($"IR {Id} thermal calibrated.");
        }
    }

    class QuickLookImage : SatelliteImage
    {
        public QuickLookImage(int id, double cloudCover)
            : base(id, cloudCover, "QUICK") { }

        public override int Score()
        {
            // IMPORTANT FIX FOR LSP:
            // no exception, must be safe for loop
            return 5;
        }
    }

    class Repository<T> where T : SatelliteImage
    {
        private List<T> _images = new();

        public void Add(T image)
        {
            _images.Add(image);
        }

        public List<T> GetAll()
        {
            return _images;
        }
    }

   
    class Program
    {
        static void Main()
        {
            Repository<SatelliteImage> repo = new();

            int dropped = 0;

            int[] ids = { 1, 2, 3, 4 };
            double[] clouds = { 20, 50, 10, 150 }; // last one corrupt

            for (int i = 0; i < ids.Length; i++)
            {
                try
                {
                    SatelliteImage img;

                    if (i == 0)
                        img = new SARImage(ids[i], clouds[i]);
                    else if (i == 1)
                        img = new EOImage(ids[i], clouds[i]);
                    else if (i == 2)
                        img = new IRImage(ids[i], clouds[i]);
                    else
                        img = new QuickLookImage(ids[i], clouds[i]);

                    repo.Add(img);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine($"Dropped corrupt record {ids[i]}");
                    dropped++;
                }
                finally
                {
                    Console.WriteLine($"Finished processing record {ids[i]}");
                }
            }

            Console.WriteLine("\n--- SCORING ---");

            int total = 0;

            foreach (SatelliteImage img in repo.GetAll())
            {
                Console.WriteLine(img.Format());
                int score = img.Score();
                Console.WriteLine($"Score: {score}\n");

                total += score;
            }
            Console.WriteLine($"Stored: {repo.GetAll().Count}");
            Console.WriteLine($"Dropped: {dropped}");
            Console.WriteLine($"Total score: {total}");
        }
    }
}