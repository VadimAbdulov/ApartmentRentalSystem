using WebApplication1.DTOs;

namespace WebApplication1.Services.Interfaces
{
    /// <summary>
    /// Сервис бизнес-логики для работы с клиентами
    /// </summary>
    public interface IClientService
    {
        Task<IEnumerable<ClientDto>> GetAllAsync();
        Task<ClientDto?> GetByIdAsync(int id);
        Task<ClientDto> CreateAsync(ClientDto dto);
        Task UpdateAsync(int id, ClientDto dto);
        Task DeleteAsync(int id);
    }
}
