namespace WebApplication1.DTOs
{
    namespace WebApplication1.DTOs
    {
        /// <summary>
        /// DTO для передачи данных об аренде
        /// </summary>
        public class RentDto
        {
            public int Id { get; set; }

            public DateTime StartDate { get; set; }
            public DateTime EndDate { get; set; }

            public int ApartmentId { get; set; }
            public int ClientId { get; set; }
        }
    }

}
