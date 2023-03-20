using System;
using System.ComponentModel.DataAnnotations;

namespace HorseRacing.DTO
{
    public class RawRaceHorse
    {
        
        public string Id { get; set; }
        
        public string PostPosition { get; set; }
        
        public string HorseName { get; set; }
        
        public string MorningLineOdds { get; set; }
        
        public string JockeyName { get; set; }
        
        public string WeightCarried { get; set; }
        
        public string TrainerName { get; set; }

        
        //RawRaceHorseId = $"{RawRaceId}{PostPosition.PadLeft(2,'0')}"; // RaceDate (8) + Track (3) + RaceNumber (2) + PostPosition (2)
        public string RawRaceId { get; set; }

    }


}
