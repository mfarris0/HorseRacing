using HorseRacing.Domain;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HorseRacing.MVC.ViewModels
{
    public class RaceDayViewModel
    {
        public RaceDayViewModel(IIncludableQueryable<RawRace, RaceType> rawRaces)
        {
            RawRaces = rawRaces;
        }
        public IIncludableQueryable<RawRace, RaceType> RawRaces { get; }

        public RaceDay RaceDay { get; set; }
    }
}
