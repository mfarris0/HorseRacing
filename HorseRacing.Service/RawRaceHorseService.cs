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
    public class RawRaceHorseService : IRawRaceHorseService
    {
        private readonly HorseRacingDbContext _horseRacingDbContext;
        
        public RawRaceHorseService(HorseRacingDbContext horseRacingRepository)
        {
            _horseRacingDbContext = horseRacingRepository;
        }

        public DTO.RawRaceHorse Add(DTO.RawRaceHorse rawRaceHorseDto)
        {
            var result = _horseRacingDbContext.RawRaceHorses.Where(r => r.HorseName == rawRaceHorseDto.HorseName && r.RawRaceId == rawRaceHorseDto.RawRaceId).FirstOrDefault();
            if (result == null)
            {
                var data = GetDataObject(rawRaceHorseDto);
                _horseRacingDbContext.RawRaceHorses.Add(data);
                _horseRacingDbContext.SaveChanges();
                rawRaceHorseDto.Id = data.Id;
            }
            else
                rawRaceHorseDto = GetDTOObject(result);

            return rawRaceHorseDto;
        }

        public DTO.RawRaceHorse GetById(string id)
        {
            var rawRaceHorse = _horseRacingDbContext.RawRaceHorses.Find(id);
            var rawRaceHorseDto = GetDTOObject(rawRaceHorse);
            return rawRaceHorseDto;
        }

        private DTO.RawRaceHorse GetDTOObject(RawRaceHorse data)
        {
            DTO.RawRaceHorse dto = null;
            if (data != null)
            {
                dto = new DTO.RawRaceHorse
                {
                    Id = data.Id,
                    PostPosition = data.PostPosition,
                    HorseName = data.HorseName,
                    MorningLineOdds = data.MorningLineOdds,
                    JockeyName = data.JockeyName,
                    WeightCarried = data.WeightCarried,
                    TrainerName = data.TrainerName,
                    RawRaceId = data.RawRaceId
                };
            }

            return dto;
        }
        
        private RawRaceHorse GetDataObject(DTO.RawRaceHorse dto)
        {
            RawRaceHorse rawRaceHorse = null;
            if (dto != null)
            {
                rawRaceHorse = new RawRaceHorse
                {
                    Id = dto.Id,
                    PostPosition = dto.PostPosition,
                    HorseName = dto.HorseName,
                    MorningLineOdds = dto.MorningLineOdds,
                    JockeyName = dto.JockeyName,
                    WeightCarried = dto.WeightCarried,
                    TrainerName = dto.TrainerName,
                    RawRaceId = dto.RawRaceId
                };
            }
            return rawRaceHorse;
        }
    }
}
