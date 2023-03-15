using HorseRacing.Domain;
using System.Collections.Generic;

namespace HorseRacing.ConsoleApp
{
    public class RaceCardViewerViewModel
    {
        public Track Track { get; set; } = new Track();

        public RaceDay RaceDay { get; set; } = new RaceDay();

        public Dictionary<string, RaceType> RaceTypeLookup = new Dictionary<string, RaceType>();

        public Dictionary<string, Distance> DistanceLookup = new Dictionary<string, Distance>();

        public Dictionary<string, RaceSurface> RaceSurfaceLookup = new Dictionary<string, RaceSurface>();

        public List<RawRace> RaceCard { get; set; } = new List<RawRace>();
        
        public List<RawRaceHorse> RaceHorseList { get; set; } = new List<RawRaceHorse>();
    }



}
