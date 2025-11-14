using Application.DTOs.Teste;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TesteController : ControllerBase
    {
        private readonly ITesteService _testeService;

        public TesteController(ITesteService testeService)
        {
            _testeService = testeService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTesteById(int id)
        {
            try
            {
                var teste = await _testeService.GetTesteByIdAsync(id);
                return Ok(teste);
            }
            catch (KeyNotFoundException)
            {
                return NotFound(new { message = "Teste não encontrado." });
            }
        }

        [HttpGet("etapa/{etapaId}")]
        public async Task<IActionResult> GetTestesByEtapaId(int etapaId)
        {
            var testes = await _testeService.GetTestesByEtapaIdAsync(etapaId);
            return Ok(testes);
        }
    }
}
