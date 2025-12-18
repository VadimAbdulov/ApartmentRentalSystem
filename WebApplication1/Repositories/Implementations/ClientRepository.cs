using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.Repositories.Interfaces;

namespace WebApplication1.Repositories.Implementations
{
    public class ClientRepository : IClientRepository
    {
        private readonly ApplicationDbContext _context;

        public ClientRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Client>> GetAllAsync()
        {
            return await _context.Clients.ToListAsync();
        }

        public async Task<Client?> GetByIdAsync(int id)
        {
            return await _context.Clients.FindAsync(id);
        }

        public async Task AddAsync(Client entity)
        {
            await _context.Clients.AddAsync(entity);
        }

        public void Update(Client entity)
        {
            _context.Clients.Update(entity);
        }

        public void Delete(Client entity)
        {
            _context.Clients.Remove(entity);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
