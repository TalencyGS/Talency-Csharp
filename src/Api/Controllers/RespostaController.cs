using Application.DTOs.Resposta;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RespostaController : ControllerBase
    {
        private readonly IRespostaService _respostaService;

        public RespostaController(IRespostaService respostaService)
        {
            _respostaService = respostaService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRespostaById(int id)
        {
            try
            {
                var resposta = await _respostaService.GetRespostaByIdAsync(id);
                return Ok(resposta);
            }
            catch (KeyNotFoundException)
            {
                return NotFound(new { message = "Resposta não encontrada." });
            }
        }

        [HttpGet("usuario/{usuarioId}")]
        public async Task<IActionResult> GetRespostasByUsuarioId(int usuarioId)
        {
            var respostas = await _respostaService.GetRespostasByUsuarioIdAsync(usuarioId);
            return Ok(respostas);
        }

        [HttpPost]
        public async Task<IActionResult> CreateResposta([FromBody] RespostaRequest request)
        {
            try
            {
                var resposta = await _respostaService.CreateRespostaAsync(request);
                return CreatedAtAction(nameof(GetRespostaById), new { id = resposta.IdResposta }, resposta);
            }
            catch (KeyNotFoundException)
            {
                return NotFound(new { message = "Usuário ou Teste não encontrado." });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateResposta(int id, [FromBody] RespostaRequest request)
        {
            try
            {
                var resposta = await _respostaService.UpdateRespostaAsync(id, request);
                return Ok(resposta);
            }
            catch (KeyNotFoundException)
            {
                return NotFound(new { message = "Resposta não encontrada." });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteResposta(int id)
        {
            try
            {
                await _respostaService.DeleteRespostaAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound(new { message = "Resposta não encontrada." });
            }
        }
    }
}
