using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.Repositories.Interfaces;

namespace WebApplication1.Repositories.Implementations
{
    public class RentRepository : IRentRepository
    {
        private readonly ApplicationDbContext _context;

        public RentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Rent>> GetAllAsync()
        {
            return await _context.Rents
                .Include(r => r.Apartment)
                .Include(r => r.Client)
                .ToListAsync();
        }

        public async Task<Rent?> GetByIdAsync(int id)
        {
            return await _context.Rents
                .Include(r => r.Apartment)
                .Include(r => r.Client)
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task AddAsync(Rent entity)
        {
            await _context.Rents.AddAsync(entity);
        }

        public void Update(Rent entity)
        {
            _context.Rents.Update(entity);
        }

        public void Delete(Rent entity)
        {
            _context.Rents.Remove(entity);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
