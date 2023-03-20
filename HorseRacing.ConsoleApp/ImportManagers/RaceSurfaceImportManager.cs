using HorseRacing.Domain;

namespace HorseRacing.ConsoleApp.ImportManagers
{
    public class RaceSurfaceImportManager
    {
        private readonly string[] _fields;
        public RaceSurfaceImportManager(string[] fields)
        {
            _fields = fields;
        }

        public RaceSurface CreateRaceSurface()
        {
            var raceSurfaceField = _fields[6];
            var raceSurface = new RaceSurface
            {
                Id = raceSurfaceField,
                BRISCode = raceSurfaceField,
                Name = $"{raceSurfaceField}"
            };
            return raceSurface;
        }
    }


}
