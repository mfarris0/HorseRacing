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
    public class RawRaceService : IRawRaceService
    {
        private readonly HorseRacingDbContext _horseRacingDbContext;
        
        public RawRaceService(HorseRacingDbContext horseRacingRepository)
        {
            _horseRacingDbContext = horseRacingRepository;
        }

        public DTO.RawRace Add(DTO.RawRace rawRaceDto)
        {
            var result = _horseRacingDbContext.RawRaces.Where(r => r.RaceDayId == rawRaceDto.RaceDayId && r.RaceNumber == rawRaceDto.RaceNumber).FirstOrDefault();
            if (result == null)
            {
                var data = GetDataObject(rawRaceDto);
                _horseRacingDbContext.RawRaces.Add(data);
                _horseRacingDbContext.SaveChanges();
                rawRaceDto.Id = data.Id;
            }
            else
                rawRaceDto = GetDTOObject(result);

            return rawRaceDto;
        }

        public DTO.RawRace GetById(string id)
        {
            var rawRace = _horseRacingDbContext.RawRaces.Find(id);
            var rawRaceDto = GetDTOObject(rawRace);
            return rawRaceDto;
        }

        private DTO.RawRace GetDTOObject(RawRace data)
        {
            DTO.RawRace dto = null;
            if (data != null)
            {
                dto = new DTO.RawRace
                {
                    Id = data.Id,
                    RaceDayId = data.RaceDayId,
                    RaceNumber = data.RaceNumber,
                    DistanceId = data.DistanceId,
                    RaceSurfaceId = data.RaceSurfaceId,
                    Purse = data.Purse,
                    Classification = data.Classification,
                    Conditions = data.Conditions,
                    RaceTypeId = data.RaceTypeId,
                    RaceDayIdString = data.RaceDayIdString
                };
            }

            return dto;
        }
        
        private RawRace GetDataObject(DTO.RawRace dto)
        {
            RawRace rawRace = null;
            if (dto != null)
            {
                rawRace = new RawRace
                {
                    Id = dto.Id,
                    RaceDayId = dto.RaceDayId,
                    RaceNumber = dto.RaceNumber,
                    DistanceId = dto.DistanceId,
                    RaceSurfaceId = dto.RaceSurfaceId,
                    Purse = dto.Purse,
                    Classification = dto.Classification,
                    Conditions = dto.Conditions,
                    RaceTypeId = dto.RaceTypeId,
                    RaceDayIdString = dto.RaceDayIdString
                };
            }
            return rawRace;
        }
    }
}
