using HorseRacing.Data;
using HorseRacing.Domain;
using HorseRacing.Service.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace HorseRacing.Service
{
    public class RaceTypeService : IRaceTypeService
    {
        private readonly IHorseRacingRepository _horseRacingRepository;
        public RaceTypeService(IHorseRacingRepository horseRacingRepository)
        {
            _horseRacingRepository = horseRacingRepository;
        }

        public RaceType Add(RaceType RaceType)
        {
            _horseRacingRepository.HorseRacingDatabase.RaceTypes.Add(RaceType);
            _horseRacingRepository.SaveChanges();
            return RaceType;
        }

        public IEnumerable<RaceType> GetList()
        {
            return _horseRacingRepository.HorseRacingDatabase.RaceTypes.OrderBy(r => r.Name);
        }

        public IEnumerable<RaceType> GetLookup()
        {
            return GetList().Select(r => new RaceType { Id = r.Id, Name = r.Name });
        }
    }
}
