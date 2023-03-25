using HorseRacing.Data;
using HorseRacing.Domain;
using HorseRacing.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorseRacing.Service
{
    public class DistanceService : IDistanceService
    {
        private readonly HorseRacingDbContext _horseRacingDbContext;
        
        public DistanceService(HorseRacingDbContext horseRacingRepository)
        {
            _horseRacingDbContext = horseRacingRepository;
        }

        public DTO.Distance Add(DTO.Distance distanceDto)
        {
            var result = _horseRacingDbContext.Distances.Where(r => r.BRISCode == distanceDto.BRISCode).FirstOrDefault();
            if (result == null)
            {
                var data = GetDataObject(distanceDto);
                _horseRacingDbContext.Distances.Add(data);
                _horseRacingDbContext.SaveChanges();
                distanceDto.Id = data.Id;
            }
            else
                distanceDto = GetDTOObject(result);

            return distanceDto;
        }

        public IEnumerable<DTO.Distance> GetList()
        {
            return _horseRacingDbContext.Distances.OrderBy(r => r.Name).Select(r => GetDTOObject(r));
        }

        private DTO.Distance GetDTOObject(Distance data)
        {
            DTO.Distance dto = null;
            if (data != null)
            {
                dto = new DTO.Distance
                {
                    Id = data.Id,
                    BRISCode = data.BRISCode,
                    Name = data.Name
                };
            }

            return dto;
        }
        
        private Distance GetDataObject(DTO.Distance dto)
        {
            Distance track = null;
            if (dto != null)
            {
                track = new Distance
                {
                    Id = dto.Id,
                    BRISCode = dto.BRISCode,
                    Name = dto.Name
                };
            }
            return track;
        }
    }
}
