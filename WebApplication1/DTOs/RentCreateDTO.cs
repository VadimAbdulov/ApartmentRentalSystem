namespace WebApplication1.DTOs
{
    namespace WebApplication1.DTOs
    {
        /// <summary>
        /// DTO для создания или обновления аренды
        /// </summary>
        public class RentCreateDto
        {
            public DateTime StartDate { get; set; }
            public DateTime EndDate { get; set; }

            public int ApartmentId { get; set; }
            public int ClientId { get; set; }
        }
    }

}
