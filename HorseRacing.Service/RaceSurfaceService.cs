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
    public class RaceSurfaceService : IRaceSurfaceService
    {
        private readonly HorseRacingDbContext _horseRacingDbContext;
        
        public RaceSurfaceService(HorseRacingDbContext horseRacingRepository)
        {
            _horseRacingDbContext = horseRacingRepository;
        }

        public DTO.RaceSurface Add(DTO.RaceSurface raceSurfaceDto)
        {
            var result = _horseRacingDbContext.RaceSurfaces.Where(r => r.BRISCode == raceSurfaceDto.BRISCode).FirstOrDefault();
            if (result == null)
            {
                var data = GetDataObject(raceSurfaceDto);
                _horseRacingDbContext.RaceSurfaces.Add(data);
                _horseRacingDbContext.SaveChanges();
                raceSurfaceDto.Id = data.Id;
            }
            else
                raceSurfaceDto = GetDTOObject(result);
            return raceSurfaceDto;
        }

        public IEnumerable<DTO.RaceSurface> GetList()
        {
            return _horseRacingDbContext.RaceSurfaces.OrderBy(r => r.Name).Select(r => GetDTOObject(r));
        }

        private DTO.RaceSurface GetDTOObject(RaceSurface data)
        {
            DTO.RaceSurface dto = null;
            if (data != null)
            {
                dto = new DTO.RaceSurface
                {
                    Id = data.Id,
                    BRISCode = data.BRISCode,
                    Name = data.Name
                };
            }

            return dto;
        }
        
        private RaceSurface GetDataObject(DTO.RaceSurface dto)
        {
            RaceSurface raceSurface = null;
            if (dto != null)
            {
                raceSurface = new RaceSurface
                {
                    Id = dto.Id,
                    BRISCode = dto.BRISCode,
                    Name = dto.Name
                };
            }
            return raceSurface;
        }
    }
}
