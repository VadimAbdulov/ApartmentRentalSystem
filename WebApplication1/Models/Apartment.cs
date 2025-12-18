using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Apartment
    {
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Address { get; set; }

        [Required]
        [Range(1, 1000000)]
        public decimal PricePerMonth { get; set; }

        [Required]
        [Range(1, 20)]
        public int Rooms { get; set; }

        public bool IsAvailable { get; set; }

        public ICollection<Rent> Rents { get; set; }
    }
}
