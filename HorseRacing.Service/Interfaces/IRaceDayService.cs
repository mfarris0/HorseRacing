using HorseRacing.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorseRacing.Service.Interfaces
{
    public interface IRaceDayService
    {
        DTO.RaceDay Add(DTO.RaceDay raceDayDto);

        DTO.RaceDay GetById(int id);

        IEnumerable<DTO.RaceDay> GetByRaceDate(DateTime raceDate);
        
        IEnumerable<DTO.RaceDay> GetByTrackId(string trackId);

    }

}
