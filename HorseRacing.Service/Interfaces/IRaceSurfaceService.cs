using HorseRacing.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorseRacing.Service.Interfaces
{
    public interface IRaceSurfaceService
    {
        DTO.RaceSurface Add(DTO.RaceSurface raceSurfaceDto);

        IEnumerable<DTO.RaceSurface> GetList(); // Get all fields in raceSurface table

    }

}
