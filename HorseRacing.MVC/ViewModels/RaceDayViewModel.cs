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
        public RaceDayViewModel(IIncludableQueryable<RaceDay, Track> raceDays)
        {
            RaceDays = raceDays;
        }

        public IIncludableQueryable<RaceDay, Track> RaceDays { get; }


    }
}
