using Application.DTOs.Dashboard;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly IDashboardService _dashboardService;

        public DashboardController(IDashboardService dashboardService)
        {
            _dashboardService = dashboardService;
        }

        [HttpGet("{usuarioId}")]
        public async Task<IActionResult> GetDashboardResumo(int usuarioId)
        {
            try
            {
                var dashboardResumo = await _dashboardService.GetDashboardResumoAsync(usuarioId);
                return Ok(dashboardResumo);
            }
            catch (KeyNotFoundException)
            {
                return NotFound(new { message = "Usuário não encontrado." });
            }
        }
    }
}
