namespace LoggingKata
{
    /// <summary>
    /// Parses a POI file to locate all the Taco Bells
    /// </summary>
    public class TacoParser
    {
        readonly ILog logger = new TacoLogger();
        
        public ITrackable Parse(string line)
        {
            //logger.LogInfo("Begin parsing");
            TacoBell tacoBell = new TacoBell();
            Point point = new Point();
            var cells = line.Split(',');
            if (cells.Length < 3)
            {
                return null;
            }
            string name = cells[2];
            double longitude = double.Parse(cells[1]);
            double latitude = double.Parse(cells[0]);

            tacoBell.Name = name;
            point.Latitude = latitude;
            point.Longitude = longitude;
            tacoBell.Location = point;
            return tacoBell;
            





            // Do not fail if one record parsing fails, return null
            return null; // TODO Implement
        }
    }

}