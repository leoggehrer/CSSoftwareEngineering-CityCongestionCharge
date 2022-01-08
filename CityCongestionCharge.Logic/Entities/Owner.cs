using System.ComponentModel.DataAnnotations;

namespace CityCongestionCharge.Logic.Entities
{
    public partial class Owner : VersionObject
    {
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; } = string.Empty;

        [MaxLength(100)]
        public string Address { get; set; } = string.Empty;

        // Navigation properties
        public List<Car> Cars { get; set; } = new();
    }
}
