using Application.DTOs.Meta;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MetaController : ControllerBase
    {
        private readonly IMetaService _metaService;

        public MetaController(IMetaService metaService)
        {
            _metaService = metaService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMetaById(int id)
        {
            try
            {
                var meta = await _metaService.GetMetaByIdAsync(id);
                return Ok(meta);
            }
            catch (KeyNotFoundException)
            {
                return NotFound(new { message = "Meta não encontrada." });
            }
        }

        [HttpGet("roadmap/{roadmapId}")]
        public async Task<IActionResult> GetMetasByRoadmapId(int roadmapId)
        {
            var metas = await _metaService.GetMetasByRoadmapIdAsync(roadmapId);
            return Ok(metas);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMeta([FromBody] MetaRequest request)
        {
            try
            {
                var meta = await _metaService.CreateMetaAsync(request);
                return CreatedAtAction(nameof(GetMetaById), new { id = meta.IdMeta }, meta);
            }
            catch (KeyNotFoundException)
            {
                return NotFound(new { message = "Roadmap não encontrado." });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMeta(int id, [FromBody] MetaRequest request)
        {
            try
            {
                var meta = await _metaService.UpdateMetaAsync(id, request);
                return Ok(meta);
            }
            catch (KeyNotFoundException)
            {
                return NotFound(new { message = "Meta não encontrada." });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMeta(int id)
        {
            try
            {
                await _metaService.DeleteMetaAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound(new { message = "Meta não encontrada." });
            }
        }
    }
}
