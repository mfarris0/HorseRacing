using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HorseRacing.Domain
{
    public class RawRaceDay
    {
        //public RawRaceDay()
        //{

        //}

        //public RawRaceDay(string raceDate, string trackCode) : this()
        //{
        //    RaceDate = raceDate;
        //    TrackCode = trackCode;
        //    SetId();
        //}

        //private void SetId()
        //{
        //    RawRaceDayId = $"{RaceDate}{Track}"; // RaceDate (8) + Track (3)
        //}

        [Required]
        [StringLength(11)]
        public string Id { get; set; }


        [Required]
        [StringLength(8)]
        public string RaceDate { get; }


        [Required]
        [StringLength(3)]
        public string TrackCode { get; set; }

        public Track Track { get; set; }


        public IEnumerable<RawRace> RaceCard { get; set; }

        public class Constants
        {
            public const string TableName = "RawRaceDay";
        }
    }
}
