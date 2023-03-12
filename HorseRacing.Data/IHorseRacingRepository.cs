namespace HorseRacing.Data
{
    public interface IHorseRacingRepository
    {
        HorseRacingDbContext HorseRacingDatabase { get; }
        void SaveChanges();
    }

}
