using HorseRacing.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HorseRacing.MVC.ViewModels
{
    public class RaceViewModel
    {
        public RaceViewModel(RaceDay raceDay, List<RawRace> racecard)
        {
            RaceDay = raceDay;
            Racecard = racecard;
        }

        public RaceDay RaceDay { get; set; }

        public IEnumerable<RawRace> Racecard { get; set; }

        public List<RaceType> RaceTypeLookup { get; set; }

        public List<Distance>  DistanceLookup { get; set; }

        public List<RaceSurface> RaceSurfaceLookup { get; set; }


    }
}
