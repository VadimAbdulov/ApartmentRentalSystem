using AutoMapper;
using WebApplication1.DTOs;
using WebApplication1.DTOs.WebApplication1.DTOs;
using WebApplication1.Models;
using WebApplication1.Repositories.Interfaces;
using WebApplication1.Services.Interfaces;

namespace WebApplication1.Services.Implementations
{
    /// <summary>
    /// Реализация сервиса бизнес-логики для аренды
    /// </summary>
    public class RentService : IRentService
    {
        private readonly IRentRepository _rentRepository;
        private readonly IApartmentRepository _apartmentRepository;
        private readonly IMapper _mapper;

        public RentService(
            IRentRepository rentRepository,
            IApartmentRepository apartmentRepository,
            IMapper mapper)
        {
            _rentRepository = rentRepository;
            _apartmentRepository = apartmentRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Получить список всех аренд
        /// </summary>
        public async Task<IEnumerable<RentDto>> GetAllAsync()
        {
            var rents = await _rentRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<RentDto>>(rents);
        }

        /// <summary>
        /// Получить аренду по идентификатору
        /// </summary>
        public async Task<RentDto?> GetByIdAsync(int id)
        {
            var rent = await _rentRepository.GetByIdAsync(id);
            return rent == null ? null : _mapper.Map<RentDto>(rent);
        }

        /// <summary>
        /// Создать новую аренду с проверкой бизнес-правил
        /// </summary>
        public async Task<RentDto> CreateAsync(RentCreateDto dto)
        {
            if (dto.EndDate <= dto.StartDate)
                throw new Exception("EndDate must be greater than StartDate");

            var apartment = await _apartmentRepository.GetByIdAsync(dto.ApartmentId)
                ?? throw new Exception("Apartment not found");

            if (!apartment.IsAvailable)
                throw new Exception("Apartment is not available");

            apartment.IsAvailable = false;

            var rent = _mapper.Map<Rent>(dto);

            await _rentRepository.AddAsync(rent);
            _apartmentRepository.Update(apartment);

            await _rentRepository.SaveAsync();

            return _mapper.Map<RentDto>(rent);
        }

        /// <summary>
        /// Удалить аренду
        /// </summary>
        public async Task DeleteAsync(int id)
        {
            var rent = await _rentRepository.GetByIdAsync(id)
                ?? throw new Exception("Rent not found");

            _rentRepository.Delete(rent);
            await _rentRepository.SaveAsync();
        }
    }
}
