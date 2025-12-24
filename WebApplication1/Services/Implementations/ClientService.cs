using AutoMapper;
using WebApplication1.DTOs;
using WebApplication1.Models;
using WebApplication1.Repositories.Interfaces;
using WebApplication1.Services.Interfaces;

namespace WebApplication1.Services.Implementations
{
    /// <summary>
    /// Реализация сервиса бизнес-логики для клиентов
    /// </summary>
    public class ClientService : IClientService
    {
        private readonly IClientRepository _repository;
        private readonly IMapper _mapper;

        public ClientService(IClientRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        /// <summary>
        /// Получить список всех клиентов
        /// </summary>
        public async Task<IEnumerable<ClientDto>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<ClientDto>>(entities);
        }

        /// <summary>
        /// Получить клиента по идентификатору
        /// </summary>
        public async Task<ClientDto?> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return entity == null ? null : _mapper.Map<ClientDto>(entity);
        }

        /// <summary>
        /// Создать нового клиента
        /// </summary>
        public async Task<ClientDto> CreateAsync(ClientDto dto)
        {
            var entity = _mapper.Map<Client>(dto);

            await _repository.AddAsync(entity);
            await _repository.SaveAsync();

            return _mapper.Map<ClientDto>(entity);
        }

        /// <summary>
        /// Обновить данные клиента
        /// </summary>
        public async Task UpdateAsync(int id, ClientDto dto)
        {
            var entity = await _repository.GetByIdAsync(id)
                ?? throw new Exception("Client not found");

            _mapper.Map(dto, entity);

            _repository.Update(entity);
            await _repository.SaveAsync();
        }

        /// <summary>
        /// Удалить клиента
        /// </summary>
        public async Task DeleteAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id)
                ?? throw new Exception("Client not found");

            _repository.Delete(entity);
            await _repository.SaveAsync();
        }
    }
}
