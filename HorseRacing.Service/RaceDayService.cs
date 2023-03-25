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
    public class RaceDayService : IRaceDayService
    {
        private readonly HorseRacingDbContext _horseRacingDbContext;
        public RaceDayService(HorseRacingDbContext horseRacingRepository)
        {
            _horseRacingDbContext = horseRacingRepository;
        }

        public DTO.RaceDay Add(DTO.RaceDay raceDayDto)
        {
            var result = _horseRacingDbContext.RaceDays.Where(r => r.RaceDate == raceDayDto.RaceDate && r.Track.Id == raceDayDto.TrackId).FirstOrDefault();
            if (result == null)
            {
                var data = GetDataObject(raceDayDto);
                _horseRacingDbContext.RaceDays.Add(data);
                _horseRacingDbContext.SaveChanges();
                raceDayDto.Id = data.Id;
            }
            else
            {
                raceDayDto = GetDTOObject(result);
            }
            return raceDayDto;
        }

        public DTO.RaceDay Update(DTO.RaceDay raceDayDto)
        {
            var raceDay = GetDataObject(raceDayDto);
            _horseRacingDbContext.RaceDays.Update(raceDay);
            _horseRacingDbContext.SaveChanges();
            return raceDayDto;
        }


        public DTO.RaceDay GetById(int id)
        {
            var raceDay = _horseRacingDbContext.RaceDays.Find(id);
            var raceDayDto = GetDTOObject(raceDay);
            return raceDayDto;
        }

        public IEnumerable<DTO.RaceDay> GetByRaceDate(DateTime raceDate)
        {
            return _horseRacingDbContext.RaceDays.Where(r => r.RaceDate == raceDate).OrderBy(s => s.RaceDate).Select(t => GetDTOObject(t));
        }

        public IEnumerable<DTO.RaceDay> GetByTrackId(string trackId)
        {
            return _horseRacingDbContext.RaceDays.Where(r => r.Track.Id == trackId).OrderBy(s => s.RaceDate).Select(t => GetDTOObject(t));
        }

        private DTO.RaceDay GetDTOObject(RaceDay data)
        {
            DTO.RaceDay dto = null;
            if (data != null)
            {
                dto = new DTO.RaceDay
                {
                    Id = data.Id,
                    TrackId = data.Track.Id,
                    TrackCode = data.TrackCode,
                    RaceDate = (DateTime)data.RaceDate,
                    RaceDateString = data.RaceDateString,
                    RaceDayIdString = data.RaceDayIdString
                };
            }

            return dto;
        }

        private RaceDay GetDataObject(DTO.RaceDay dto)
        {
            RaceDay raceDay = null;
            if (dto != null)
            {
                var trackService = new TrackService(_horseRacingDbContext);
                raceDay = new RaceDay
                {
                    Id = dto.Id,
                    TrackId = dto.TrackId,
                    TrackCode = dto.TrackCode,
                    RaceDate = dto.RaceDate,
                    RaceDateString = dto.RaceDateString,
                    RaceDayIdString = dto.RaceDayIdString
                };
            }
            return raceDay;
        }

    }
}
