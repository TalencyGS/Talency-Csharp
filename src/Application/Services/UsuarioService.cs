using Application.DTOs.Usuario;
using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Security;

namespace Application.Services
{

    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly ITokenService _tokenService;
        private readonly IPasswordHasher _passwordHasher; 

        public UsuarioService(IUsuarioRepository usuarioRepository, ITokenService tokenService, IPasswordHasher passwordHasher)
        {
            _usuarioRepository = usuarioRepository;
            _tokenService = tokenService;
            _passwordHasher = passwordHasher;
        }

        public async Task<UsuarioAuthResponse> LoginAsync(UsuarioLoginRequest request)
        {
            var usuario = await _usuarioRepository.GetByEmailAsync(request.Email);

            if (usuario == null || !_passwordHasher.VerifyPassword(request.Senha, usuario.SenhaHash))
            {
                throw new UnauthorizedAccessException("Credenciais inválidas.");
            }

            var token = _tokenService.GenerateToken(usuario);

            return new UsuarioAuthResponse
            {
                Usuario = new UsuarioResponse
                {
                    IdUsuario = usuario.IdUsuario,
                    Nome = usuario.Nome,
                    Email = usuario.Email,
                    AreaInteresse = usuario.AreaInteresse,
                    DataCadastro = usuario.DataCadastro
                },
                Token = token
            };
        }

        public async Task<UsuarioAuthResponse> RegisterAsync(UsuarioRegisterRequest request)
        {
            if (await _usuarioRepository.GetByEmailAsync(request.Email) != null)
            {
                throw new InvalidOperationException("Email já está em uso.");
            }

            var senhaHash = _passwordHasher.HashPassword(request.Senha);

            var usuario = Usuario.Create(request.Nome, request.Email, senhaHash, request.AreaInteresse);

            await _usuarioRepository.CreateAsync(usuario);

            var token = _tokenService.GenerateToken(usuario);

            return new UsuarioAuthResponse
            {
                Usuario = new UsuarioResponse
                {
                    IdUsuario = usuario.IdUsuario,
                    Nome = usuario.Nome,
                    Email = usuario.Email,
                    AreaInteresse = usuario.AreaInteresse,
                    DataCadastro = usuario.DataCadastro
                },
                Token = token
            };
        }

        public async Task<UsuarioResponse> GetUsuarioByIdAsync(int id)
        {
            var usuario = await _usuarioRepository.GetByIdAsync(id);
            if (usuario == null)
            {
                throw new KeyNotFoundException("Usuário não encontrado.");
            }

            return new UsuarioResponse
            {
                IdUsuario = usuario.IdUsuario,
                Nome = usuario.Nome,
                Email = usuario.Email,
                AreaInteresse = usuario.AreaInteresse,
                DataCadastro = usuario.DataCadastro
            };
        }

        public async Task<UsuarioResponse> UpdateUsuarioAsync(int id, UsuarioUpdateRequest request)
        {
            var usuario = await _usuarioRepository.GetByIdAsync(id);
            if (usuario == null)
            {
                throw new KeyNotFoundException("Usuário não encontrado.");
            }

            if (!string.IsNullOrEmpty(request.Senha))
            {
                usuario.SenhaHash = _passwordHasher.HashPassword(request.Senha);
            }

            usuario.Nome = request.Nome;
            usuario.Email = request.Email;
            usuario.AreaInteresse = request.AreaInteresse;

            await _usuarioRepository.UpdateAsync(id, usuario);

            return new UsuarioResponse
            {
                IdUsuario = usuario.IdUsuario,
                Nome = usuario.Nome,
                Email = usuario.Email,
                AreaInteresse = usuario.AreaInteresse,
                DataCadastro = usuario.DataCadastro
            };
        }

        public async Task DeleteUsuarioAsync(int id)
        {
            var usuario = await _usuarioRepository.GetByIdAsync(id);
            if (usuario == null)
            {
                throw new KeyNotFoundException("Usuário não encontrado.");
            }

            await _usuarioRepository.DeleteAsync(id);
        }
    }

}
