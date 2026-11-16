using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Practica_web_api.Models;
using Practica_web_api.Repositories;

namespace Practica_web_api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly UsuarioRepository _repo;

        public UsuariosController(UsuarioRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<List<Usuario>>> ObtenerTodos()
        {
            var productos = await _repo.ObtenerTodosAsync();

            return Ok(productos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> ObtenerPorId(int id)
        {
            var usuario = await _repo.BuscarPorIdAsync(id);

            if (usuario == null)
            {
                return NotFound();
            }

            return Ok(usuario);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Agregar([FromBody] Usuario dto)
        {
            var usuario = new Usuario
            {
                Nombre = dto.Nombre,
                Email = dto.Email,
                Contra = dto.Contra
            };

            await _repo.AgregarAsync(usuario);

            return CreatedAtAction(
                nameof(ObtenerPorId),
                new { id = usuario.Id },
                usuario
            );
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Actualizar(
            int id,
            [FromBody] Usuario dto)
        {
            var usuario = new Usuario
            {
                Id = id,
                Nombre = dto.Nombre,
                Email = dto.Email,
                Contra = dto.Contra
            };

            bool actualizado = await _repo.ActualizarAsync(usuario);

            if (!actualizado)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Eliminar(int id)
        {
            bool eliminado = await _repo.EliminarPorIdAsync(id);

            if (!eliminado)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
