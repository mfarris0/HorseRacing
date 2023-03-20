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
    public class RaceTypeService : IRaceTypeService
    {
        private readonly IHorseRacingRepository _horseRacingRepository;

        public RaceTypeService(IHorseRacingRepository horseRacingRepository)
        {
            _horseRacingRepository = horseRacingRepository;
        }

        public DTO.RaceType Add(DTO.RaceType raceTypeDto)
        {
            var result = _horseRacingRepository.HorseRacingDatabase.RaceTypes.Where(r => r.BRISCode == raceTypeDto.BRISCode).FirstOrDefault();
            if (result == null)
            {
                var data = GetDataObject(raceTypeDto);
                _horseRacingRepository.HorseRacingDatabase.RaceTypes.Add(data);
                _horseRacingRepository.SaveChanges();
                raceTypeDto.Id = data.Id;
            }
            else
                raceTypeDto = GetDTOObject(result);
            return raceTypeDto;
        }

        public IEnumerable<DTO.RaceType> GetList()
        {
            return _horseRacingRepository.HorseRacingDatabase.RaceTypes.OrderBy(r => r.Name).Select(r => GetDTOObject(r));
        }

        private DTO.RaceType GetDTOObject(RaceType data)
        {
            DTO.RaceType dto = null;
            if (data != null)
            {
                dto = new DTO.RaceType
                {
                    Id = data.Id,
                    BRISCode = data.BRISCode,
                    Name = data.Name
                };
            }

            return dto;
        }

        private RaceType GetDataObject(DTO.RaceType dto)
        {
            RaceType track = null;
            if (dto != null)
            {
                track = new RaceType
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
