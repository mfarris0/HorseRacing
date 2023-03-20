using HorseRacing.Domain;

namespace HorseRacing.ConsoleApp.ImportManagers
{
    public class RawRaceImportManager
    {
        private readonly string[] _fields;
        private readonly RaceDay _raceDay;
        private readonly RaceSurface _raceSurface;
        private readonly Distance _distance;
        private readonly RaceType _raceType;

        public RawRaceImportManager(string[] fields, RaceDay raceDay, RaceType raceType, Distance distance, RaceSurface raceSurface)
        {
            _fields = fields;
            _raceDay = raceDay;
            _raceType = raceType;
            _distance = distance;
            _raceSurface = raceSurface;
        }

        public RawRace CreateRawRace()
        {
            var rawRace = new RawRace
            {
                Id = CreateId(),
                RaceNumber = _fields[2],
                Purse = _fields[11],
                Classification = _fields[10],
                Conditions = _fields[15],
                RaceType = _raceType,
                Distance = _distance,
                RaceSurface=_raceSurface,
                RaceDay = _raceDay,
                RaceDayIdString = _raceDay.RaceDayIdString
            };
            return rawRace;
        }

        private string CreateId()
        {
            // RaceDate (8) + Track (3) + RaceNumber (2)
            //  Example = 20230314CD01

            string raceNumber = _fields[2];
            return $"{_raceDay.RaceDayIdString}{raceNumber.PadLeft(2, '0')}"; 
        }
    }


}
