namespace WebApplication1.DTOs
{
    /// <summary>
    /// DTO для передачи данных о клиенте
    /// </summary>
    public class ClientDto
    {
        public int Id { get; set; }
        public string FullName { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string Email { get; set; } = null!;
    }
}
