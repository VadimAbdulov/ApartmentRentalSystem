namespace WebApplication1.DTOs
{
    /// <summary>
    /// DTO для передачи данных о квартире
    /// </summary>
    public class ApartmentDto
    {
        public int Id { get; set; }
        public string Address { get; set; } = null!;
        public decimal PricePerMonth { get; set; }
        public int Rooms { get; set; }
        public bool IsAvailable { get; set; }
    }
}
