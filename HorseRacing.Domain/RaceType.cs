using System.ComponentModel.DataAnnotations;

namespace HorseRacing.Domain
{
    public class RaceType
    {
        [Required]
        [StringLength(2)]
        public string Id { get; set; }

        [Required]
        [StringLength(35)]
        public string Name { get; set; }

        [Required]
        [StringLength(2)]
        public string BRISCode { get; set; }

        public class Constants
        {
            public const string TableName = "RaceType";
        }
    }
}
