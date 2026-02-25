using Microsoft.EntityFrameworkCore;
using FinanzasWeb.Models;

namespace FinanzasWeb.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        
        // Tabla de base de datos
        public DbSet<Gasto> Gastos { get; set; }
    }
}