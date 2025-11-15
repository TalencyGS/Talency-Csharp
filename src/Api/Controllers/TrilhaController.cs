using Application.DTOs.Trilha;
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
    public class TrilhaController : ControllerBase
    {
        private readonly ITrilhaService _trilhaService;

        public TrilhaController(ITrilhaService trilhaService)
        {
            _trilhaService = trilhaService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTrilhaById(int id)
        {
            try
            {
                var trilha = await _trilhaService.GetTrilhaByIdAsync(id);
                return Ok(trilha);
            }
            catch (KeyNotFoundException)
            {
                return NotFound(new { message = "Trilha não encontrada." });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTrilhas()
        {
            var trilhas = await _trilhaService.GetAllTrilhasAsync();
            return Ok(trilhas);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTrilha([FromBody] TrilhaRequest request)
        {
            var trilha = await _trilhaService.CreateTrilhaAsync(request);
            return CreatedAtAction(nameof(GetTrilhaById), new { id = trilha.IdTrilha }, trilha);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTrilha(int id, [FromBody] TrilhaRequest request)
        {
            try
            {
                var trilha = await _trilhaService.UpdateTrilhaAsync(id, request);
                return Ok(trilha);
            }
            catch (KeyNotFoundException)
            {
                return NotFound(new { message = "Trilha não encontrada." });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrilha(int id)
        {
            try
            {
                await _trilhaService.DeleteTrilhaAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound(new { message = "Trilha não encontrada." });
            }
        }
    }
}
