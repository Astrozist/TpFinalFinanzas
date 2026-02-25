using FinanzasWeb.Data;
using FinanzasWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace FinanzasWeb.Repositories
{
    public class GastoRepository : IGastoRepository
    {
        private readonly ApplicationDbContext _context;

        public GastoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Gasto>> GetAllAsync()
        {
            return await _context.Gastos.ToListAsync();
        }

        public async Task<Gasto> GetByIdAsync(int id)
        {
            return await _context.Gastos.FindAsync(id);
        }

        public async Task AddAsync(Gasto gasto)
        {
            _context.Gastos.Add(gasto);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Gasto gasto)
        {
            _context.Gastos.Update(gasto);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var gasto = await _context.Gastos.FindAsync(id);
            if (gasto != null)
            {
                _context.Gastos.Remove(gasto);
                await _context.SaveChangesAsync();
            }
        }
    }
}