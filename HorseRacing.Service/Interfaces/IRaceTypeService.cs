using HorseRacing.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HorseRacing.Service
{
    public interface IRaceTypeService
    {
        DTO.RaceType Add(DTO.RaceType raceType);

        IEnumerable<DTO.RaceType> GetAll(); // Get all fields in track table
        
        DTO.RaceType GetById(string id);

    }

}
