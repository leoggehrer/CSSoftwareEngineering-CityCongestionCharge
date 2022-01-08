using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace CityCongestionCharge.Logic.Entities
{
    public partial class Payment : VersionObject
    {
        public int CarId { get; set; }

        public DateTime PaidForDate { get; set; }

        [Precision(8, 2)]
        public decimal PaidAmount { get; set; }

        [MaxLength(100)]
        public string PayingPerson { get; set; }

        // Navigation properties
        public Car Car { get; set; }
    }
}
