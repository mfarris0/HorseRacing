using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HorseRacing.DTO
{
    public class RawRace
    {
        public string Id { get; set; }
       
        public string RaceNumber { get; set; }

        public string Purse { get; set; }

        public string Classification { get; set; }

        public string Conditions { get; set; }

        public string RaceTypeId { get; set; }

        public string DistanceId { get; set; }
                
        public string RaceSurfaceId { get; set; }

        public int RaceDayId { get; set; }

        public string RaceDayIdString { get; set; } //$"{RaceDate}{Track}"; // RaceDate (8) + Track (3)


    }
}
