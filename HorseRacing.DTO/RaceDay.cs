using System;
using System.ComponentModel.DataAnnotations;

namespace HorseRacing.DTO
{
    public class RaceDay
    {
        public int Id { get; set; }

        public DateTime RaceDate { get; set; }

        public string TrackCode { get; set; }

        public string TrackId { get; set; }

        public string RaceDateString { get; set; }

    }

}
