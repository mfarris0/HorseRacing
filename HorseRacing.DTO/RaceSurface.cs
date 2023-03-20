using System.ComponentModel.DataAnnotations;

namespace HorseRacing.DTO
{
    public class RaceSurface
    {
        public string Id { get; set; }// case insensitive

        public string Name { get; set; }

        public string BRISCode { get; set; }

    }
}
