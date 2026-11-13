using Practica_web_api.Models;
using Microsoft.EntityFrameworkCore;

namespace Practica_web_api.Data
{
    public class UsuarioDbContext : DbContext
    {
        public UsuarioDbContext(DbContextOptions<UsuarioDbContext> options)
 : base(options)
        {
        }
        public DbSet<Usuario> Usuarios => Set<Usuario>();
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>(entity =>
            {

            });
        }
    }
}
