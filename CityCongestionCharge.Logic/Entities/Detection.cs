using System.ComponentModel.DataAnnotations;

namespace CityCongestionCharge.Logic.Entities
{
    public partial class Detection :VersionObject
    {
        public DateTime Taken { get; set; }

        [Required]
        [MinLength(10)]
        [MaxLength(200)]
        public string PhotoUrl { get; set; } = string.Empty;

        public MovementType MovementType { get; set; }

        // Navigation properties
        public List<Car> DetectedCars { get; set; } = new();
    }
}
