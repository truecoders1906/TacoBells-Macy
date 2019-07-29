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
            logger.LogInfo("Begin parsing");
            var cells = line.Split(',');
            if (cells.Length < 3)
            {
                return null;
            }
            string latitudeAsString = cells[0];
            string longitudeAsString = cells[1];
            string name = cells[2];
            double longitude = double.Parse(longitudeAsString);
            double latitude = double.Parse(latitudeAsString);






            // Do not fail if one record parsing fails, return null
            return null; // TODO Implement
        }
    }

}