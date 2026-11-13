using Practica_web_api.Data;
using Practica_web_api.Models;
using Microsoft.EntityFrameworkCore;

namespace Practica_web_api.Repositories
{
    /* public class UsuarioRepository
     {
         private readonly List<Usuario> _usuarios;

         public UsuarioRepository() {

             _usuarios = new List<Usuario>
             {
                 new Usuario { Id = 1, Nombre = "Xavier", Email = "xavier.anatoa@epn.edu.ec", Contra = "123456" },
                 new Usuario { Id = 2, Nombre = "Steven", Email = "steven.tintin@epn.edu.ec", Contra = "123456" },
                 new Usuario { Id = 3, Nombre = "Mariano", Email = "mariano.zambrano@epn.edu.ec", Contra = "123456"}
             };
         }

         public List<Usuario> GetUsuarios() { 
             return _usuarios;
         }

         public void setUsuario(Usuario usuario) {
             usuario.Id = _usuarios.Any() ? _usuarios.Max(u => u.Id) +1 : 1;
             _usuarios.Add(usuario);
         }

         public Usuario? buscarPorId(int id) {
             return _usuarios.FirstOrDefault(u => u.Id == id);
         }

         /*public eliminarPorId(int id) {
             Usuario? usuario = buscarPorId(id);
             if (usuario != null) {
                 _usuarios.Remove(usuario);
                 return true;
             }

         }

     }*/






    public class UsuarioRepository
    {
        private readonly UsuarioDbContext _context;

        public UsuarioRepository(UsuarioDbContext context)
        {
            _context = context;
        }

        public async Task<List<Usuario>> ObtenerTodosAsync()
        {
            return await _context.Usuarios
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Usuario?> BuscarPorIdAsync(int id)
        {
            return await _context.Usuarios
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Usuario> AgregarAsync(Usuario producto)
        {
            _context.Usuarios.Add(producto);

            await _context.SaveChangesAsync();

            return producto;
        }

        public async Task<bool> ActualizarAsync(Usuario producto)
        {
            var existente = await _context.Usuarios.FindAsync(producto.Id);

            if (existente == null)
            {
                return false;
            }

            existente.Nombre = producto.Nombre;
            existente.Email = producto.Email;
            existente.Contra = producto.Contra;

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> EliminarPorIdAsync(int id)
        {
            var existente = await _context.Usuarios.FindAsync(id);

            if (existente == null)
            {
                return false;
            }

            _context.Usuarios.Remove(existente);

            await _context.SaveChangesAsync();

            return true;
        }

    }
}
