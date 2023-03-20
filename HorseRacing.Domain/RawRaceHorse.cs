using System;
using System.ComponentModel.DataAnnotations;

namespace HorseRacing.Domain
{
    public class RawRaceHorse
    {
        //public RawRaceHorse()
        //{

        //}

        //public RawRaceHorse(string rawRaceId, string postPosition, string horseName, string morningLineOdds, string jockeyName, string weightAllowed, string trainerName)
        //{
        //    this.RawRaceId = rawRaceId;
        //    this.PostPosition = postPosition;
        //    this.HorseName = horseName;
        //    this.MorningLineOdds = morningLineOdds;
        //    this.JockeyName = jockeyName;
        //    this.WeightAllowed = weightAllowed;
        //    this.TrainerName = trainerName;
        //    SetId();
        //}

        //private void SetId()
        //{
        //    RawRaceHorseId = $"{RawRaceId}{PostPosition.PadLeft(2,'0')}"; // RaceDate (8) + Track (3) + RaceNumber (2) + PostPosition (2)
        //}
        
        [Required]
        [StringLength(15)]
        public string Id { get; set; }
        

        [Required]
        [StringLength(2)]
        public string PostPosition { get; set; }
        
        [Required]
        [StringLength(25)]
        public string HorseName { get; set; }
        
        [Required]
        [StringLength(10)]
        public string MorningLineOdds { get; set; }
        
        [Required]
        [StringLength(25)]
        public string JockeyName { get; set; }
        
        [Required]
        [StringLength(3)]
        public string WeightCarried { get; set; }
        
        [Required]
        [StringLength(30)]
        public string TrainerName { get; set; }

        
        [Required]
        [StringLength(13)]
        public string RawRaceId { get; set; }

        [Required]
        public RawRace RawRace { get; set; }

        public class Constants
        {
            public const string TableName = "RawRaceHorse";
        }

    }


}
