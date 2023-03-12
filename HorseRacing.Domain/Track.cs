using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HorseRacing.Domain
{
    public class Track
    {

        [Required]
        [StringLength(3)]
        public string Id { get; set; }

        [Required]
        [StringLength(35)]
        public string Name { get; set; }

        [Required]
        [StringLength(3)]
        public string BRISCode { get; set; }

        public class Constants
        {
            public const string TableName = "Track";
        }
    }
}
