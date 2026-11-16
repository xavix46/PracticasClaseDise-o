using Practica_web_api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Practica_web_api.Data
{
    public class UsuarioDbContext : IdentityDbContext<ApplicationUser>
    {
        public UsuarioDbContext(DbContextOptions<UsuarioDbContext> options)
        : base(options)
        {
        }
        public DbSet<Usuario> Usuarios => Set<Usuario>();
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Usuario>(entity =>
            {

            });
        }
    }
}
