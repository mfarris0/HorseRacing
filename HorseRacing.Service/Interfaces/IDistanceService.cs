using HorseRacing.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorseRacing.Service.Interfaces
{
    public interface IDistanceService
    {
        DTO.Distance Add(DTO.Distance distanceDto);

        IEnumerable<DTO.Distance> GetList(); // Get all fields in track table

    }

}
