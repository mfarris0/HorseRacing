using HorseRacing.Domain;

namespace HorseRacing.ConsoleApp.ImportManagers
{
    public class DistanceImportManager
    {
        private readonly string[] _fields;
        public DistanceImportManager(string[] fields)
        {
            _fields = fields;
        }
        public Distance CreateDistance()
        {
            var distanceField = _fields[5];
            Distance distance = new Distance
            {
                Id = distanceField,
                BRISCode = distanceField,
                Name = $"{distanceField} - RECONCILE"
            };
            return distance;
        }

    }

}
