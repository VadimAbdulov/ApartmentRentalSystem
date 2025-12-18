using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Rent
    {
        public int Id { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        public int ApartmentId { get; set; }
        public Apartment Apartment { get; set; }

        public int ClientId { get; set; }
        public Client Client { get; set; }
    }
}
