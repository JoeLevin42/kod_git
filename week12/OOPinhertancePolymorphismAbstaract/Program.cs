using System;

namespace Platforms
{
    abstract class Platform
    {
        private int _trackId;
        private double _speedKnots;
        private double _heading;
        public int TrackId { get => _trackId; }
        public double SpeedKnots
        {
            get => _speedKnots;
            set { if (value < 0) _speedKnots = 0; else _speedKnots = value; }
        }
        public double Heading
        {
            get => _heading;
            set { if (value < 0 || value > 359) _heading = 0; else _heading = value; }
        }

        protected Platform(int trackId, double speedKnots, double heading)
        {
            trackId = TrackId;
            speedKnots = SpeedKnots;
            heading = Heading;

        }
        abstract public string StatusLine();
        abstract public bool IsTrackable();
    }

    class AirPlatform : Platform
    {
        private double _altitudeFeet;

        public double AltitudeFeet
        {
            get => _altitudeFeet;
            set
            {
                if (value < 0) _altitudeFeet = 0;
                else _altitudeFeet = value;
            }
        }
        public AirPlatform(int trackId, double speedKnots, double heading, double altitudeFeet)
        : base(trackId, speedKnots, heading)
        {
            altitudeFeet = AltitudeFeet;
        }

        public override string StatusLine()
            => $"trackId: {TrackId}, speeKnots: {SpeedKnots}, heading {Heading}, altitudeFeet {AltitudeFeet}";

        public override bool IsTrackable()
        {
            if (!(AltitudeFeet >= 100 || AltitudeFeet <= 60000)) return false;

            else return true;

        }
    }
        class SeaPlatform : Platform
        {
            private double _depthMeters;

            public double DepthMeters
            {
                get => _depthMeters;
                set { if (value < 0) value *= -1; _depthMeters = value; }
            }
            public SeaPlatform(int trackId, double speedKnots, double heading, double depthMeters)
                : base(trackId, speedKnots, heading)
            {
                DepthMeters = depthMeters;
            }
            public override string StatusLine()
            => $"trackId: {TrackId}, speeKnots: {SpeedKnots}, heading {Heading}, deepthMeter {DepthMeters}";

            public override bool IsTrackable()
            {
                if (!(DepthMeters < 0 || DepthMeters <= 300)) return false;
                return true;
            }
        }


    class GroundPlatform : Platform
    {
        private string _terrainType;
        
        public string TerrainType { get => _terrainType;
        set { if (string.IsNullOrEmpty(value)) _terrainType = "default";
                else _terrainType = value;
            }
        }
        public GroundPlatform(int trackId, double speedKnots, double heading , string terrainType)
            : base(trackId, speedKnots, heading)
        {
            TerrainType = terrainType;
        }
        public override string StatusLine()
            => $"trackId: {TrackId}, speeKnots: {SpeedKnots}, heading {Heading}, terrain_Type {TerrainType}";
        public override bool IsTrackable()
        {
            if (TerrainType == "tunnel") return false;
            return true;
        }
    }
    class Program
    {
        static void Main()
        {
            List<Platform> all = new()
            {
            new AirPlatform(1,300.0,200,30000.0),
            new AirPlatform(2,300.0,200,70000.0),
            new SeaPlatform(3,300.0,200,100.0),
            new SeaPlatform(4,300.0,200,400.0),
            new GroundPlatform(5,300.0,300.0,"dirt"),
            new GroundPlatform(6,300.0,200.0,"tunnel")
            };

            foreach (Platform obj in all)
            {
                Console.WriteLine(obj.StatusLine());
                Console.WriteLine(obj.IsTrackable());
            }
        }
    }

}