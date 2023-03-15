using HorseRacing.Domain;

namespace HorseRacing.ConsoleApp.ImportManagers
{
    public class TrackImportManager
    {
        private readonly string[] _fields;
        public TrackImportManager(string[] fields)
        {
            _fields = fields;
        }
        public Track CreateTrack()
        {
            var trackField = _fields[0].Trim();
            var track = new Track
            {
                Id = trackField,
                BRISCode = trackField,
                Name = $"{trackField} - RECONCILE"
            };
            return track;
        }
    }
}
