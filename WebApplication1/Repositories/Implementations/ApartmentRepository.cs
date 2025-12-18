using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.Repositories.Interfaces;

namespace WebApplication1.Repositories.Implementations
{
    public class ApartmentRepository : IApartmentRepository
    {
        private readonly ApplicationDbContext _context;

        public ApartmentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Apartment>> GetAllAsync()
        {
            return await _context.Apartments.ToListAsync();
        }

        public async Task<Apartment?> GetByIdAsync(int id)
        {
            return await _context.Apartments.FindAsync(id);
        }

        public async Task AddAsync(Apartment entity)
        {
            await _context.Apartments.AddAsync(entity);
        }

        public void Update(Apartment entity)
        {
            _context.Apartments.Update(entity);
        }

        public void Delete(Apartment entity)
        {
            _context.Apartments.Remove(entity);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
