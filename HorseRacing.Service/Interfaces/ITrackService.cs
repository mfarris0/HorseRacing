using HorseRacing.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorseRacing.Service.Interfaces
{
    public interface ITrackService
    {
        DTO.Track Add(DTO.Track trackDto);

        IEnumerable<DTO.Track> GetList(); // Get all fields in track table

    }

}
