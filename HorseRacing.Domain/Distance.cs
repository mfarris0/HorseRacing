using System.ComponentModel.DataAnnotations;

namespace HorseRacing.Domain
{
    public class Distance
    {
        [Required]
        [StringLength(6)]
        public string Id { get; set; }

        [Required]
        [StringLength(25)]
        public string Name { get; set; }

        [Required]
        [StringLength(6)]
        public string BRISCode { get; set; }

        public class Constants
        {
            public const string TableName = "Distance";
        }
    }
}
