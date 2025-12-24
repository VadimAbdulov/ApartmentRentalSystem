using WebApplication1.DTOs;
using WebApplication1.DTOs.WebApplication1.DTOs;

namespace WebApplication1.Services.Interfaces
{
    /// <summary>
    /// Сервис бизнес-логики для аренды
    /// </summary>
    public interface IRentService
    {
        Task<IEnumerable<RentDto>> GetAllAsync();
        Task<RentDto?> GetByIdAsync(int id);
        Task<RentDto> CreateAsync(RentCreateDto dto);
        Task DeleteAsync(int id);
    }
}
