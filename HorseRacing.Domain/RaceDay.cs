using System;
using System.ComponentModel.DataAnnotations;

namespace HorseRacing.Domain
{
    public class RaceDay
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public DateTime? RaceDate { get; set; }

        [Required]
        [StringLength(3)]
        public string TrackCode { get; set; }

        
        [StringLength(3)]
        public string TrackId { get; set; }
        
        [Required]
        public Track Track { get; set; }

        
        [Required]
        [StringLength(8)]
        public string RaceDateString { get; set; }

        [Required]
        [StringLength(11)]
        public string RaceDayIdString { get; set; } //$"{RaceDate}{Track}"; // RaceDate (8) + Track (3)


        public class Constants
        {
            public const string TableName = "RaceDay";
        }
    }

}
