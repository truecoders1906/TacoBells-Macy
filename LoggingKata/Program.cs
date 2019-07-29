using System;
using System.Linq;
using System.IO;
using GeoCoordinatePortable;

namespace LoggingKata
{
    class Program
    {
        static readonly ILog logger = new TacoLogger();
        const string csvPath = "TacoBell-US-AL.csv";

        static void Main(string[] args)
        {
            logger.LogInfo("Log initialized");

            var lines = File.ReadAllLines(csvPath);

            logger.LogInfo($"Lines: {lines[0]}");

            var parser = new TacoParser();

            var locations = lines.Select(parser.Parse).ToArray();

            ITrackable tacoOne = null;
            ITrackable tacoTwo = null;

            double distanceFromtacoOneTotacoTwo = 0;

            foreach(ITrackable tacoBellOne in locations)
            {
                GeoCoordinate locA = new GeoCoordinate(tacoBellOne.Location.Latitude, tacoBellOne.Location.Longitude);

                foreach (ITrackable tacoBellTwo in locations)
                {
                    GeoCoordinate locB = new GeoCoordinate(tacoBellTwo.Location.Latitude, tacoBellTwo.Location.Longitude);

                    double distanceBetweenlocAAndlocB = locA.GetDistanceTo(locB);
                }
            }
            // TODO:  Find the two Taco Bells in Alabama that are the furthest from one another.
            // HINT:  You'll need two nested forloops

            
    }
}