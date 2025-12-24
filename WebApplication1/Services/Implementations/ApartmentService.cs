using AutoMapper;
using WebApplication1.DTOs;
using WebApplication1.Models;
using WebApplication1.Repositories.Interfaces;
using WebApplication1.Services.Interfaces;

namespace WebApplication1.Services.Implementations
{
    /// <summary>
    /// Реализация сервиса бизнес-логики для квартир
    /// </summary>
    public class ApartmentService : IApartmentService
    {
        private readonly IApartmentRepository _repository;
        private readonly IMapper _mapper;

        public ApartmentService(
            IApartmentRepository repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        /// <summary>
        /// Получить список всех квартир
        /// </summary>
        public async Task<IEnumerable<ApartmentDto>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<ApartmentDto>>(entities);
        }



        /// <summary>
        /// Получить квартиру по идентификатору
        /// </summary>
        public async Task<ApartmentDto?> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return entity == null ? null : _mapper.Map<ApartmentDto>(entity);
        }

        /// <summary>
        /// Создать новую квартиру
        /// </summary>
        public async Task<ApartmentDto> CreateAsync(ApartmentDto dto)
        {
            var entity = _mapper.Map<Apartment>(dto);

            await _repository.AddAsync(entity);
            await _repository.SaveAsync();

            return _mapper.Map<ApartmentDto>(entity);
        }

        /// <summary>
        /// Обновить данные квартиры
        /// </summary>
        public async Task UpdateAsync(int id, ApartmentDto dto)
        {
            var entity = await _repository.GetByIdAsync(id)
                ?? throw new Exception("Apartment not found");

            _mapper.Map(dto, entity);

            _repository.Update(entity);
            await _repository.SaveAsync();
        }

        /// <summary>
        /// Удалить квартиру
        /// </summary>
        public async Task DeleteAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id)
                ?? throw new Exception("Apartment not found");

            _repository.Delete(entity);
            await _repository.SaveAsync();
        }
    }
}
