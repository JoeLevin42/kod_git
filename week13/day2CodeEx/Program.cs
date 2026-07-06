using A;
using System;

namespace A
{

    abstract class SatelliteImage
    {
        public int Id { get; }
        public double CloudCover { get; }
        public string Sensor { get; }

        protected SatelliteImage(int id, double cloudCover, string sensor)
        {
            if (!(cloudCover >= 0 && cloudCover <= 100))
                throw new ArgumentException("CloudCover must be 0–100");

            Id = id;
            CloudCover = cloudCover;
            Sensor = sensor;
        }

        public abstract int Score();

        public virtual string Format()
        {
            return $"Image {Id}:{CloudCover:0}% cloud [{Sensor}]";
        }
    }
    class SARImage : SatelliteImage
    {
        public SARImage(int id, double cloudCover)
            : base(id, cloudCover, "SAR") { }

        public override int Score()
        {
            return 100 - (int)CloudCover;
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

        class IRImage : SatelliteImage
        {
            public IRImage(int id, double cloudCover)
                : base(id, cloudCover, "IR") { }

            public override int Score()
            {
                return 40 - (int)CloudCover;
            }



        }
        class Repository<T> where T : SatelliteImage
        {
            private List<T> _images = new List<T>();


            public void Add(T image)
            {
                _images.Add(image);
            }

            public List<T> GetAll()
            {
                return _images;
            }

        }

        class Prgram
        {
            static void Main()
            {
                Repository<SatelliteImage> repo = new Repository<SatelliteImage>();

                try
                {
                    repo.Add(new SARImage(1, 20));
                    repo.Add(new EOImage(2, 50));
                    repo.Add(new IRImage(3, 10));

                    //Exception!!
                    repo.Add(new SARImage(4, 150));
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }

                int total = 0;

                foreach (SatelliteImage image in repo.GetAll())
                {
                    Console.WriteLine(image.Format());
                    Console.WriteLine($"Score:{image.Score()}");
                    Console.WriteLine();

                    total += image.Score();
                }

                Console.WriteLine($"Total Score: {total}");
            }
        }
    }
}

        
