using WebApplication1.DTOs;

namespace WebApplication1.Services.Interfaces
{
    /// <summary>
    /// Сервис бизнес-логики для работы с квартирами
    /// </summary>
    public interface IApartmentService
    {
        Task<IEnumerable<ApartmentDto>> GetAllAsync();
        Task<ApartmentDto?> GetByIdAsync(int id);
        Task<ApartmentDto> CreateAsync(ApartmentDto dto);

        Task UpdateAsync(int id, ApartmentDto dto);
        Task DeleteAsync(int id);
    }
}
