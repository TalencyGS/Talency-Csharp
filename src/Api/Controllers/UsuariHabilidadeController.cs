using Application.DTOs.UsuarioHabilidade;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioHabilidadeController : ControllerBase
    {
        private readonly IUsuarioHabilidadeService _usuarioHabilidadeService;

        public UsuarioHabilidadeController(IUsuarioHabilidadeService usuarioHabilidadeService)
        {
            _usuarioHabilidadeService = usuarioHabilidadeService;
        }

        [HttpGet("{usuarioId}/{habilidadeId}")]
        public async Task<IActionResult> GetUsuarioHabilidadeByIds(int usuarioId, int habilidadeId)
        {
            try
            {
                var usuarioHabilidade = await _usuarioHabilidadeService.GetUsuarioHabilidadeByIdsAsync(usuarioId, habilidadeId);
                return Ok(usuarioHabilidade);
            }
            catch (KeyNotFoundException)
            {
                return NotFound(new { message = "Usuário ou Habilidade não encontrados." });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsuarioHabilidades()
        {
            var usuarioHabilidades = await _usuarioHabilidadeService.GetAllUsuarioHabilidadesAsync();
            return Ok(usuarioHabilidades);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUsuarioHabilidade([FromBody] UsuarioHabilidadeRequest request)
        {
            var usuarioHabilidade = await _usuarioHabilidadeService.CreateUsuarioHabilidadeAsync(request);
            return CreatedAtAction(nameof(GetUsuarioHabilidadeByIds), new { usuarioId = usuarioHabilidade.IdUsuario, habilidadeId = usuarioHabilidade.IdHabilidade }, usuarioHabilidade);
        }

        [HttpPut("{usuarioId}/{habilidadeId}")]
        public async Task<IActionResult> UpdateUsuarioHabilidade(int usuarioId, int habilidadeId, [FromBody] UsuarioHabilidadeRequest request)
        {
            try
            {
                var usuarioHabilidade = await _usuarioHabilidadeService.UpdateUsuarioHabilidadeAsync(usuarioId, habilidadeId, request);
                return Ok(usuarioHabilidade);
            }
            catch (KeyNotFoundException)
            {
                return NotFound(new { message = "Usuário ou Habilidade não encontrados." });
            }
        }

        [HttpDelete("{usuarioId}/{habilidadeId}")]
        public async Task<IActionResult> DeleteUsuarioHabilidade(int usuarioId, int habilidadeId)
        {
            try
            {
                await _usuarioHabilidadeService.DeleteUsuarioHabilidadeAsync(usuarioId, habilidadeId);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound(new { message = "Usuário ou Habilidade não encontrados." });
            }
        }
    }
}
