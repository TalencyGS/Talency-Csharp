using Application.DTOs.Roadmap;
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
    public class RoadmapController : ControllerBase
    {
        private readonly IRoadmapService _roadmapService;

        public RoadmapController(IRoadmapService roadmapService)
        {
            _roadmapService = roadmapService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRoadmapById(int id)
        {
            try
            {
                var roadmap = await _roadmapService.GetRoadmapByIdAsync(id);
                return Ok(roadmap);
            }
            catch (KeyNotFoundException)
            {
                return NotFound(new { message = "Roadmap não encontrado." });
            }
        }

        [HttpGet("usuario/{usuarioId}")]
        public async Task<IActionResult> GetRoadmapsByUsuarioId(int usuarioId)
        {
            var roadmaps = await _roadmapService.GetRoadmapsByUsuarioIdAsync(usuarioId);
            return Ok(roadmaps);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRoadmap([FromBody] RoadmapCreateRequest request)
        {
            try
            {
                var roadmap = await _roadmapService.CreateRoadmapAsync(request);
                return CreatedAtAction(nameof(GetRoadmapById), new { id = roadmap.IdRoadmap }, roadmap);
            }
            catch (KeyNotFoundException)
            {
                return NotFound(new { message = "Usuário ou Trilha não encontrada." });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRoadmap(int id, [FromBody] RoadmapCreateRequest request)
        {
            try
            {
                var roadmap = await _roadmapService.UpdateRoadmapAsync(id, request);
                return Ok(roadmap);
            }
            catch (KeyNotFoundException)
            {
                return NotFound(new { message = "Roadmap não encontrado." });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoadmap(int id)
        {
            try
            {
                await _roadmapService.DeleteRoadmapAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound(new { message = "Roadmap não encontrado." });
            }
        }
    }
}
