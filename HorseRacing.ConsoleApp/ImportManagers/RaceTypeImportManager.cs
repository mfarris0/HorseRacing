using HorseRacing.Domain;

namespace HorseRacing.ConsoleApp.ImportManagers
{
    public class RaceTypeImportManager
    {
        private readonly string[] _fields;
        public RaceTypeImportManager(string[] fields)
        {
            _fields = fields;
        }
        public RaceType CreateRaceType()
        {
            var raceTypeField = _fields[8];
            var raceType = new RaceType
            {
                Id = raceTypeField,
                BRISCode = raceTypeField,
                Name = $"{raceTypeField} - RECONCILE"
            };
            return raceType;
        }
    }


}
