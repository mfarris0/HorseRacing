using HorseRacing.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorseRacing.Service.Interfaces
{
    public interface IRawRaceHorseService
    {
        DTO.RawRaceHorse Add(DTO.RawRaceHorse rawRaceHorseDto);

        DTO.RawRaceHorse GetById(string id);

    }

}
