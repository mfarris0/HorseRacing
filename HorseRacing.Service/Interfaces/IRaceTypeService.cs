using HorseRacing.Domain;
using System.Collections.Generic;

namespace HorseRacing.Service.Interfaces
{
    public interface IRaceTypeService
    {
        DTO.RaceType Add(DTO.RaceType raceType);

        IEnumerable<DTO.RaceType> GetList(); // Get all fields in track table

    }

}
