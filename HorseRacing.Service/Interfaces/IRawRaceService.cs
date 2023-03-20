using HorseRacing.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorseRacing.Service.Interfaces
{
    public interface IRawRaceService
    {
        DTO.RawRace Add(DTO.RawRace rawRaceDto);

        DTO.RawRace GetById(string id);

    }

}
