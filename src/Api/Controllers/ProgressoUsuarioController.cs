using Application.DTOs.ProgressoUsuario;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgressoUsuarioController : ControllerBase
    {
        private readonly IProgressoUsuarioService _progressoUsuarioService;

        public ProgressoUsuarioController(IProgressoUsuarioService progressoUsuarioService)
        {
            _progressoUsuarioService = progressoUsuarioService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProgressoUsuarioById(int id)
        {
            try
            {
                var progresso = await _progressoUsuarioService.GetProgressoUsuarioByIdAsync(id);
                return Ok(progresso);
            }
            catch (KeyNotFoundException)
            {
                return NotFound(new { message = "Progresso do usuário não encontrado." });
            }
        }

        [HttpGet("usuario/{usuarioId}")]
        public async Task<IActionResult> GetProgressoUsuarioByUsuarioId(int usuarioId)
        {
            var progressoUsuarios = await _progressoUsuarioService.GetProgressoUsuarioByUsuarioIdAsync(usuarioId);
            return Ok(progressoUsuarios);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProgressoUsuario([FromBody] ProgressoUsuarioRequest request)
        {
            try
            {
                var progresso = await _progressoUsuarioService.CreateProgressoUsuarioAsync(request);
                return CreatedAtAction(nameof(GetProgressoUsuarioById), new { id = progresso.IdProgresso }, progresso);
            }
            catch (KeyNotFoundException)
            {
                return NotFound(new { message = "Usuário ou Trilha não encontrados." });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProgressoUsuario(int id, [FromBody] ProgressoUsuarioRequest request)
        {
            try
            {
                var progresso = await _progressoUsuarioService.UpdateProgressoUsuarioAsync(id, request);
                return Ok(progresso);
            }
            catch (KeyNotFoundException)
            {
                return NotFound(new { message = "Progresso do usuário não encontrado." });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProgressoUsuario(int id)
        {
            try
            {
                await _progressoUsuarioService.DeleteProgressoUsuarioAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound(new { message = "Progresso do usuário não encontrado." });
            }
        }
    }
}
