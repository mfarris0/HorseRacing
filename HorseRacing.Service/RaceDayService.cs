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
        private readonly IHorseRacingRepository _horseRacingRepository;
        public RaceDayService(IHorseRacingRepository horseRacingRepository)
        {
            _horseRacingRepository = horseRacingRepository;
        }

        public DTO.RaceDay Add(DTO.RaceDay raceDayDto)
        {
            var result = _horseRacingRepository.HorseRacingDatabase.RaceDays.Where(r => r.RaceDate == raceDayDto.RaceDate && r.Track.Id == raceDayDto.TrackId).FirstOrDefault();
            if (result == null)
            {
                var data = GetDataObject(raceDayDto);
                _horseRacingRepository.HorseRacingDatabase.RaceDays.Add(data);
                _horseRacingRepository.SaveChanges();
                raceDayDto.Id = data.Id;
            }
            return raceDayDto;
        }

        public DTO.RaceDay GetById(int id)
        {
            var raceDay = _horseRacingRepository.HorseRacingDatabase.RaceDays.Find(id);
            var raceDayDto = GetDTOObject(raceDay);
            return raceDayDto;
        }

        public IEnumerable<DTO.RaceDay> GetByRaceDate(DateTime raceDate)
        {
            return _horseRacingRepository.HorseRacingDatabase.RaceDays.Where(r=>r.RaceDate == raceDate).OrderBy(s => s.RaceDate).Select(t => GetDTOObject(t));
        }

        public IEnumerable<DTO.RaceDay> GetByTrackId(string trackId)
        {
            return _horseRacingRepository.HorseRacingDatabase.RaceDays.Where(r => r.Track.Id == trackId).OrderBy(s => s.RaceDate).Select(t => GetDTOObject(t));
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
                    RaceDateString = data.RaceDateString,
                    RaceDate = (DateTime)data.RaceDate
                };
            }

            return dto;
        }

        private RaceDay GetDataObject(DTO.RaceDay dto)
        {
            RaceDay raceDay = null;
            if (dto != null)
            {
                var trackService = new TrackService(_horseRacingRepository);
                raceDay = new RaceDay
                {
                    Id = dto.Id,
                    RaceDate = dto.RaceDate,
                    RaceDateString = dto.RaceDateString,
                    TrackCode = dto.TrackCode
                };
                var track = trackService.GetById(dto.TrackId);
                raceDay.Track = GetTrackDataObject(track);
            }
            return raceDay;
        }

        private Track GetTrackDataObject(DTO.Track dto)
        {
            Track track = null;
            if (dto != null)
            {
                track = new Track
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
