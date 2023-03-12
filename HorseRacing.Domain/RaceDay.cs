using System;
using System.ComponentModel.DataAnnotations;

namespace HorseRacing.Domain
{
    public class RaceDay
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public DateTime RaceDate { get; set; }

        [Required]
        [StringLength(3)]
        public string TrackCode { get; set; }

        [Required]
        public Track Track { get; set; }

        [Required]
        [StringLength(8)]
        public string RaceDateString { get; set; }


        public class Constants
        {
            public const string TableName = "RaceDay";
        }
    }

}
