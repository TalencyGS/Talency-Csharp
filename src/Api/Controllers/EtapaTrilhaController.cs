using Application.Dtos.EtapaTrilha;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EtapaTrilhaController : ControllerBase
    {
        private readonly IEtapaTrilhaService _etapaTrilhaService;

        public EtapaTrilhaController(IEtapaTrilhaService etapaTrilhaService)
        {
            _etapaTrilhaService = etapaTrilhaService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEtapaTrilhaById(int id)
        {
            try
            {
                var etapaTrilha = await _etapaTrilhaService.GetEtapaTrilhaByIdAsync(id);
                return Ok(etapaTrilha);
            }
            catch (KeyNotFoundException)
            {
                return NotFound(new { message = "Etapa da trilha não encontrada." });
            }
        }

        [HttpGet("trilha/{trilhaId}")]
        public async Task<IActionResult> GetEtapasByTrilhaId(int trilhaId)
        {
            var etapasTrilha = await _etapaTrilhaService.GetEtapasByTrilhaIdAsync(trilhaId);
            return Ok(etapasTrilha);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEtapaTrilha([FromBody] EtapaTrilhaRequest request)
        {
            try
            {
                var etapaTrilha = await _etapaTrilhaService.CreateEtapaTrilhaAsync(request);
                return CreatedAtAction(nameof(GetEtapaTrilhaById), new { id = etapaTrilha.IdEtapa }, etapaTrilha);
            }
            catch (KeyNotFoundException)
            {
                return NotFound(new { message = "Trilha não encontrada." });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEtapaTrilha(int id, [FromBody] EtapaTrilhaRequest request)
        {
            try
            {
                var etapaTrilha = await _etapaTrilhaService.UpdateEtapaTrilhaAsync(id, request);
                return Ok(etapaTrilha);
            }
            catch (KeyNotFoundException)
            {
                return NotFound(new { message = "Etapa da trilha não encontrada." });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEtapaTrilha(int id)
        {
            try
            {
                await _etapaTrilhaService.DeleteEtapaTrilhaAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound(new { message = "Etapa da trilha não encontrada." });
            }
        }
    }
}
