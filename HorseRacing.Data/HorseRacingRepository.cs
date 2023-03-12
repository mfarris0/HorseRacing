using System;

namespace HorseRacing.Data
{
    public class HorseRacingRepository : IHorseRacingRepository, IDisposable
    {
        public HorseRacingRepository(HorseRacingDbContext horseRacingDatabase)
        {
            HorseRacingDatabase = horseRacingDatabase;
        }

        public HorseRacingDbContext HorseRacingDatabase { get; private set; }

        public void Dispose()
        {
            HorseRacingDatabase.Dispose();
            GC.SuppressFinalize(this);
        }

        public void SaveChanges()
        {
            HorseRacingDatabase.SaveChanges();
        }
    }

}
