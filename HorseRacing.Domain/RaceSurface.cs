using System.ComponentModel.DataAnnotations;

namespace HorseRacing.Domain
{
    public class RaceSurface
    {
        [Required]
        [StringLength(1)] 
        public string Id { get; set; }// case insensitive

        [Required]
        [StringLength(12)]
        public string Name { get; set; }

        [Required]
        [StringLength(1)]
        public string BRISCode { get; set; }

        public class Constants
        {
            public const string TableName = "RaceSurface";
        }
    }
}
