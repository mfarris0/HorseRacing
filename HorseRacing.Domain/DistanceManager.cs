namespace HorseRacing.Domain
{
    public class DistanceManager
    {
        const int yardsPerFurlong = 220;
        const int yardsPerMile = 1760;


        private double YardsToFurlongs(int yards)
        {
            double furlongs = yards / 220;
            return furlongs;
        }

        public string DistanceToDisplay(double yards)
        {
            string text;
            double value;

            if (yards < 1760)
            {
                value = yards / yardsPerFurlong;
                if (yards % yardsPerFurlong == 0)
                    text = $"{value:n0} furlongs";
                else
                    text = $"{value:n2} furlongs";
            }
            else
            {
                value = yards / yardsPerMile;
                if (yards % yardsPerFurlong == 0)
                    text = $"{value:n0} mile";
                else
                    text = $"{value:n2} miles";
            }
            return text;
        }
    }
}
