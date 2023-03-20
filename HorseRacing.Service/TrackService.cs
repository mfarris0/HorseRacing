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
    public class TrackService : ITrackService
    {
        private readonly IHorseRacingRepository _horseRacingRepository;
        
        public TrackService(IHorseRacingRepository horseRacingRepository)
        {
            _horseRacingRepository = horseRacingRepository;
        }

        public DTO.Track Add(DTO.Track trackDto)
        {
            var result = _horseRacingRepository.HorseRacingDatabase.Tracks.Where(r => r.BRISCode == trackDto.BRISCode).FirstOrDefault();
            if (result == null)
            {
                var data = GetDataObject(trackDto);
                _horseRacingRepository.HorseRacingDatabase.Tracks.Add(data);
                _horseRacingRepository.SaveChanges();
                trackDto.Id = data.Id;
            }
            else
                trackDto = GetDTOObject(result);

            return trackDto;
        }

        public IEnumerable<DTO.Track> GetList()
        {
            return _horseRacingRepository.HorseRacingDatabase.Tracks.OrderBy(r => r.Name).Select(r => GetDTOObject(r));
        }

        public DTO.Track GetById(string id)
        {
            var track = _horseRacingRepository.HorseRacingDatabase.Tracks.Find(id);
            var trackDto = GetDTOObject(track);
            return trackDto;
        }

        private DTO.Track GetDTOObject(Track data)
        {
            DTO.Track dto = null;
            if (data != null)
            {
                dto = new DTO.Track
                {
                    Id = data.Id,
                    BRISCode = data.BRISCode,
                    Name = data.Name
                };
            }

            return dto;
        }
        
        private Track GetDataObject(DTO.Track dto)
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
