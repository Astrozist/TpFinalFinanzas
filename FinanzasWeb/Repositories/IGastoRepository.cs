using FinanzasWeb.Models;

namespace FinanzasWeb.Repositories
{
    public interface IGastoRepository
    {
        Task<IEnumerable<Gasto>> GetAllAsync();
        Task<Gasto> GetByIdAsync(int id);
        Task AddAsync(Gasto gasto);
        Task UpdateAsync(Gasto gasto);
        Task DeleteAsync(int id);
    }
}