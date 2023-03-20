using System;
using HorseRacing.Domain;

namespace HorseRacing.ConsoleApp.ImportManagers
{
    public class RaceDayImportManager
    {
        private readonly string[] _fields;
        private readonly Track _track;
        public RaceDayImportManager(string[] fields, Track track)
        {
            _fields = fields;
            _track = track;
        }


        public RaceDay CreateRaceDay()
        {
            var raceDateField = _fields[1].Trim();
            var raceDayIdString = $"{raceDateField}{_track.BRISCode}";
            var raceDay = new RaceDay
            {
                Track = _track,
                TrackCode = _track.BRISCode,
                RaceDateString = raceDateField,
                RaceDate = CreateDate(raceDateField),
                RaceDayIdString = raceDayIdString

            };
            return raceDay;
        }

        private DateTime? CreateDate(string brisDateString)
        {
            DateTime? raceDate = null;
            if (int.TryParse(brisDateString.Substring(0,4), out int year))
            {
                if(int.TryParse(brisDateString.Substring(4,2), out int month))
                {
                    if(int.TryParse(brisDateString.Substring(6,2), out int day))
                    {
                        raceDate = new DateTime(year, month, day);
                    }
                }
            }
            return raceDate;
        }
    }
}
