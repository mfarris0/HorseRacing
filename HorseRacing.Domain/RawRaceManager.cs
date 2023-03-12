namespace HorseRacing.Domain
{
    public class RawRaceManager
    {
        private const int YardsPerMile = 1760;

        //public string GetDetailLine(RawRace race)
        //{
        //    if (race.RawRaceDayId == null) throw new ArgumentNullException($"{nameof(race.RawRaceDayId)} cannot be null");
        //    if (race.RawRaceId == null) throw new ArgumentNullException($"{nameof(race.RawRaceId)} cannot be null");


        //    int raceNumber = int.Parse(race.RaceNumber);
        //    int purse = int.Parse(race.Purse);
        //    string raceTypeName = GetRaceTypeName(race.RaceType);
        //    string surfaceName = GetSurfaceName(race.Surface);
        //    string distanceText = GetDistanceToDisplay(race.Distance);
        //    string text = $"{raceNumber,2}  {purse,10:c0}  {raceTypeName,-27}  {surfaceName,-7}  {distanceText}";
        //    return text;
        //}

        private double YardsToFurlongs(int yards)
        {
            double furlongs = yards / YardsPerMile;
            return furlongs;
        }

        //private string GetRaceTypeName(string raceTypeId)
        //{
        //    RaceTypeManager raceTypeManager = new RaceTypeManager();
        //    return raceTypeManager.GetRaceTypeName(raceTypeId);
        //}

        //private string GetSurfaceName(string surfaceId)
        //{
        //    RaceSurfaceManager surfaceManager = new RaceSurfaceManager();
        //    return surfaceManager.GetSurfaceName(surfaceId);
        //}

        private string GetDistanceToDisplay(string yardString)
        {
            DistanceManager distanceManager = new DistanceManager();
            double yards = double.Parse(yardString);
            return distanceManager.DistanceToDisplay(yards);
        }
    }
}
