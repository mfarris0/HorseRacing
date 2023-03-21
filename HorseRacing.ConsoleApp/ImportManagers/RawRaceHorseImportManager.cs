using HorseRacing.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorseRacing.ConsoleApp.ImportManagers
{
    public class RawRaceHorseImportManager
    {
        private readonly string[] _fields;
        private readonly RawRace _rawRace;
        public RawRaceHorseImportManager(string[] fields, RawRace rawRace)
        {
            _fields = fields;
            _rawRace = rawRace;
        }

        public RawRaceHorse CreateRawRaceHorse()
        {
            var rawRaceHorse = new RawRaceHorse
            {
                Id = CreateId(),
                PostPosition = _fields[3],
                HorseName = _fields[44],
                MorningLineOdds = _fields[43],
                JockeyName = _fields[32],
                WeightCarried = _fields[50],
                TrainerName = _fields[27],
                RawRaceId = _rawRace.Id,
                RawRace = _rawRace
            };
            return rawRaceHorse;
        }

        private string CreateId()
        {
            //Id = $"{RawRaceId}{PostPosition.PadLeft(2,'0')}"; // RaceDate (8) + Track (3) + RaceNumber (2) + PostPosition (2)

            var postPosition = _fields[3].Trim();
            return $"{_rawRace.Id}{postPosition.PadLeft(2, '0')}";
        }

    }
}
