using Application.DTOs.Usuario;
using Application.Interfaces;
using Application.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UsuarioLoginRequest request)
        {
            try
            {
                var authResponse = await _usuarioService.LoginAsync(request);
                return Ok(authResponse);
            }
            catch (UnauthorizedAccessException)
            {
                return Unauthorized(new { message = "Credenciais inválidas." });
            }
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UsuarioRegisterRequest request)
        {
            try
            {
                var authResponse = await _usuarioService.RegisterAsync(request);
                return CreatedAtAction(nameof(Login), new { email = authResponse.Usuario.Email }, authResponse);
            }
            catch (InvalidOperationException)
            {
                return Conflict(new { message = "Email já está em uso." });
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUsuarioById(int id)
        {
            try
            {
                var usuario = await _usuarioService.GetUsuarioByIdAsync(id);
                return Ok(usuario);
            }
            catch (KeyNotFoundException)
            {
                return NotFound(new { message = "Usuário não encontrado." });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUsuario(int id, [FromBody] UsuarioUpdateRequest request)
        {
            try
            {
                var usuario = await _usuarioService.UpdateUsuarioAsync(id, request);
                return Ok(usuario);
            }
            catch (KeyNotFoundException)
            {
                return NotFound(new { message = "Usuário não encontrado." });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuario(int id)
        {
            try
            {
                await _usuarioService.DeleteUsuarioAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound(new { message = "Usuário não encontrado." });
            }
        }
    }
}
