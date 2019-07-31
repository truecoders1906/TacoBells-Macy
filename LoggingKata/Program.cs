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

            double farthestDistance = 0;

            foreach (ITrackable tacoBellOne in locations)
            {
                GeoCoordinate locA = new GeoCoordinate(tacoBellOne.Location.Latitude, tacoBellOne.Location.Longitude);

                foreach (ITrackable tacoBellTwo in locations)
                {
                    GeoCoordinate locB = new GeoCoordinate(tacoBellTwo.Location.Latitude, tacoBellTwo.Location.Longitude);
                    double distanceBetweenlocAAndlocB = locA.GetDistanceTo(locB);
                    if (distanceBetweenlocAAndlocB > farthestDistance)
                    {
                        tacoOne = tacoBellOne;
                        tacoTwo = tacoBellTwo;
                        farthestDistance = distanceBetweenlocAAndlocB;
                    }
                }
            }
            Console.WriteLine(tacoOne.Name);
            Console.WriteLine(tacoTwo.Name);
            Console.WriteLine(farthestDistance);
        }
    }
}