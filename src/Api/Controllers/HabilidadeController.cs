using Application.DTOs.Habilidade;
using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class HabilidadeController : ControllerBase
    {
        private readonly IHabilidadeService _habilidadeService;

        public HabilidadeController(IHabilidadeService habilidadeService)
        {
            _habilidadeService = habilidadeService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetHabilidadeById(int id)
        {
            try
            {
                var habilidade = await _habilidadeService.GetHabilidadeByIdAsync(id);
                return Ok(habilidade);
            }
            catch (KeyNotFoundException)
            {
                return NotFound(new { message = "Habilidade não encontrada." });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllHabilidades()
        {
            var habilidades = await _habilidadeService.GetAllHabilidadesAsync();
            return Ok(habilidades);
        }

        [HttpPost]
        public async Task<IActionResult> CreateHabilidade([FromBody] HabilidadeRequest request)
        {
            var habilidade = await _habilidadeService.CreateHabilidadeAsync(request);
            return CreatedAtAction(nameof(GetHabilidadeById), new { id = habilidade.IdHabilidade }, habilidade);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateHabilidade(int id, [FromBody] HabilidadeRequest request)
        {
            try
            {
                var habilidade = await _habilidadeService.UpdateHabilidadeAsync(id, request);
                return Ok(habilidade);
            }
            catch (KeyNotFoundException)
            {
                return NotFound(new { message = "Habilidade não encontrada." });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHabilidade(int id)
        {
            try
            {
                await _habilidadeService.DeleteHabilidadeAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound(new { message = "Habilidade não encontrada." });
            }
        }
    }
}
