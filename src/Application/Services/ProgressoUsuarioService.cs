using Application.DTOs.ProgressoUsuario;
using Application.Interfaces;
using Domain.Entities;
using Domain.Repositories;

namespace Application.Services
{
    public class ProgressoUsuarioService : IProgressoUsuarioService
    {
        private readonly IProgressoUsuarioRepository _progressoUsuarioRepository;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly ITrilhaRepository _trilhaRepository;

        public ProgressoUsuarioService(
            IProgressoUsuarioRepository progressoUsuarioRepository,
            IUsuarioRepository usuarioRepository,
            ITrilhaRepository trilhaRepository)
        {
            _progressoUsuarioRepository = progressoUsuarioRepository;
            _usuarioRepository = usuarioRepository;
            _trilhaRepository = trilhaRepository;
        }

        public async Task<ProgressoUsuarioResponse> GetProgressoUsuarioByIdAsync(int id)
        {
            var progresso = await _progressoUsuarioRepository.GetByIdAsync(id);
            if (progresso == null)
            {
                throw new KeyNotFoundException("Progresso do usuário não encontrado.");
            }

            return new ProgressoUsuarioResponse
            {
                IdProgresso = progresso.IdProgresso,
                IdUsuario = progresso.IdUsuario,
                IdTrilha = progresso.IdTrilha,
                Percentual = progresso.Percentual
            };
        }

        public async Task<List<ProgressoUsuarioResponse>> GetProgressoUsuarioByUsuarioIdAsync(int usuarioId)
        {
            var progressoUsuarios = await _progressoUsuarioRepository.GetByUsuarioIdAsync(usuarioId);

            return progressoUsuarios.Select(p => new ProgressoUsuarioResponse
            {
                IdProgresso = p.IdProgresso,
                IdUsuario = p.IdUsuario,
                IdTrilha = p.IdTrilha,
                Percentual = p.Percentual
            }).ToList();
        }

        public async Task<ProgressoUsuarioResponse> CreateProgressoUsuarioAsync(ProgressoUsuarioRequest request)
        {
            var usuario = await _usuarioRepository.GetByIdAsync(request.IdUsuario);
            if (usuario == null)
            {
                throw new KeyNotFoundException("Usuário não encontrado.");
            }

            var trilha = await _trilhaRepository.GetByIdAsync(request.IdTrilha);
            if (trilha == null)
            {
                throw new KeyNotFoundException("Trilha não encontrada.");
            }

            var progressoUsuario = ProgressoUsuario.Create(usuario, trilha, request.Percentual);

            await _progressoUsuarioRepository.CreateAsync(progressoUsuario);

            return new ProgressoUsuarioResponse
            {
                IdProgresso = progressoUsuario.IdProgresso,
                IdUsuario = progressoUsuario.IdUsuario,
                IdTrilha = progressoUsuario.IdTrilha,
                Percentual = progressoUsuario.Percentual
            };
        }

        public async Task<ProgressoUsuarioResponse> UpdateProgressoUsuarioAsync(int id, ProgressoUsuarioRequest request)
        {
            var progressoUsuario = await _progressoUsuarioRepository.GetByIdAsync(id);
            if (progressoUsuario == null)
            {
                throw new KeyNotFoundException("Progresso do usuário não encontrado.");
            }

            var trilha = await _trilhaRepository.GetByIdAsync(request.IdTrilha);
            if (trilha == null)
            {
                throw new KeyNotFoundException("Trilha não encontrada.");
            }

            progressoUsuario.Percentual = request.Percentual;

            await _progressoUsuarioRepository.UpdateAsync(id, progressoUsuario);

            return new ProgressoUsuarioResponse
            {
                IdProgresso = progressoUsuario.IdProgresso,
                IdUsuario = progressoUsuario.IdUsuario,
                IdTrilha = progressoUsuario.IdTrilha,
                Percentual = progressoUsuario.Percentual
            };
        }

        public async Task DeleteProgressoUsuarioAsync(int id)
        {
            var progressoUsuario = await _progressoUsuarioRepository.GetByIdAsync(id);
            if (progressoUsuario == null)
            {
                throw new KeyNotFoundException("Progresso do usuário não encontrado.");
            }

            await _progressoUsuarioRepository.DeleteAsync(id);
        }
    }
}
