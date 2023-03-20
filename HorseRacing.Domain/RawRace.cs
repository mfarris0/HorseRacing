using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HorseRacing.Domain
{
    public class RawRace
    {
        //public RawRace()
        //{

        //}

        //public RawRace(string rawRaceDayId, string raceNumber, string purse, string raceType, string classification, string distance, string surface, string conditions)
        //{
        //    RawRaceDayId = rawRaceDayId;
        //    RaceNumber = raceNumber;
        //    Purse = purse;
        //    RaceType = raceType;
        //    Classification = classification;
        //    Distance = distance;
        //    Surface = surface;
        //    Conditions = conditions;
        //    SetId();
        //}

        //private void SetId()
        //{
        //    RawRaceId = $"{RawRaceDayId}{RaceNumber.PadLeft(2, '0')}"; // RaceDate (8) + Track (3) + RaceNumber (2)
        //}

        [Required]
        [StringLength(13)]
        public string Id { get; set; }
       
        [Required]
        [StringLength(2)]
        public string RaceNumber { get; set; }

        [Required]
        [StringLength(8)]
        public string Purse { get; set; }

        [Required]
        [StringLength(14)]
        public string Classification { get; set; }

        [Required]
        [StringLength(500)]
        public string Conditions { get; set; }

        
        [StringLength(2)]
        public string RaceTypeId { get; set; }

        [Required]
        [StringLength(2)]
        public RaceType RaceType { get; set; }


        [StringLength(6)]
        public string DistanceId { get; set; }
                
        [Required]
        [StringLength(6)]
        public Distance Distance { get; set; }

        public string RaceSurfaceId { get; set; }

        [Required]
        [StringLength(1)]
        public RaceSurface RaceSurface { get; set; }

        public int RaceDayId { get; set; }

        [Required]
        public RaceDay RaceDay { get; set; }

        [StringLength(11)]
        public string RaceDayIdString { get; set; } //$"{RaceDate}{Track}"; // RaceDate (8) + Track (3)


        public List<RawRaceHorse> RaceHorseList { get; set; } = new List<RawRaceHorse>();

        public override string ToString()
        {
            StringBuilder text = new StringBuilder();

            text.AppendLine( $"{Id} {RaceDay.RaceDateString} {RaceNumber} {Purse} {Classification} {RaceType.Name} {Distance.Name} {RaceSurface.Name}");
            text.AppendLine(Conditions);
            text.AppendLine();
            return text.ToString();
        }

        public class Constants
        {
            public const string TableName = "RawRace";
        }

    }
}
