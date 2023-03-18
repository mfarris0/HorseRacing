using HorseRacing.Domain;
using System.Collections.Generic;

namespace HorseRacing.Service.Interfaces
{
    public interface IRaceTypeService
    {
        RaceType Add(RaceType raceType);

        IEnumerable<RaceType> GetList(); // Get all fields in track table

        IEnumerable<RaceType> GetLookup(); // Get Id and Name fields only.
    }

}
