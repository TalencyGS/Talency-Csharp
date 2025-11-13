using Application.DTOs.UsuarioHabilidade;
using Application.Interfaces;
using Domain.Entities;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class UsuarioHabilidadeService : IUsuarioHabilidadeService
    {
        private readonly IUsuarioHabilidadeRepository _usuarioHabilidadeRepository;
        private readonly IHabilidadeRepository _habilidadeRepository;
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioHabilidadeService(
            IUsuarioHabilidadeRepository usuarioHabilidadeRepository,
            IHabilidadeRepository habilidadeRepository,
            IUsuarioRepository usuarioRepository)
        {
            _usuarioHabilidadeRepository = usuarioHabilidadeRepository;
            _habilidadeRepository = habilidadeRepository;
            _usuarioRepository = usuarioRepository;
        }

        public async Task<UsuarioHabilidadeResponse> GetUsuarioHabilidadeByIdsAsync(int usuarioId, int habilidadeId)
        {
            var usuarioHabilidade = await _usuarioHabilidadeRepository.GetByIdsAsync(usuarioId, habilidadeId);
            if (usuarioHabilidade == null)
            {
                throw new KeyNotFoundException("Usuário ou Habilidade não encontrados.");
            }

            return new UsuarioHabilidadeResponse
            {
                IdUsuario = usuarioHabilidade.IdUsuario,
                IdHabilidade = usuarioHabilidade.IdHabilidade,
                NomeHabilidade = usuarioHabilidade.Habilidade.NomeHabilidade,
                Tipo = usuarioHabilidade.Habilidade.Tipo,
                Nivel = usuarioHabilidade.Nivel
            };
        }

        public async Task<List<UsuarioHabilidadeResponse>> GetAllUsuarioHabilidadesAsync()
        {
            var usuarioHabilidades = await _usuarioHabilidadeRepository.GetAllAsync();

            return usuarioHabilidades.Select(uh => new UsuarioHabilidadeResponse
            {
                IdUsuario = uh.IdUsuario,
                IdHabilidade = uh.IdHabilidade,
                NomeHabilidade = uh.Habilidade.NomeHabilidade,
                Tipo = uh.Habilidade.Tipo,
                Nivel = uh.Nivel
            }).ToList();
        }

        public async Task<UsuarioHabilidadeResponse> CreateUsuarioHabilidadeAsync(UsuarioHabilidadeRequest request)
        {
            var usuario = await _usuarioRepository.GetByIdAsync(request.IdUsuario);
            if (usuario == null)
            {
                throw new KeyNotFoundException("Usuário não encontrado.");
            }

            var habilidade = await _habilidadeRepository.GetByIdAsync(request.IdHabilidade);
            if (habilidade == null)
            {
                throw new KeyNotFoundException("Habilidade não encontrada.");
            }

            var usuarioHabilidade = UsuarioHabilidade.Create(usuario, habilidade, request.Nivel);

            await _usuarioHabilidadeRepository.CreateAsync(usuarioHabilidade);

            return new UsuarioHabilidadeResponse
            {
                IdUsuario = usuarioHabilidade.IdUsuario,
                IdHabilidade = usuarioHabilidade.IdHabilidade,
                NomeHabilidade = usuarioHabilidade.Habilidade.NomeHabilidade,
                Tipo = usuarioHabilidade.Habilidade.Tipo,
                Nivel = usuarioHabilidade.Nivel
            };
        }

        public async Task<UsuarioHabilidadeResponse> UpdateUsuarioHabilidadeAsync(int usuarioId, int habilidadeId, UsuarioHabilidadeRequest request)
        {
            var usuarioHabilidade = await _usuarioHabilidadeRepository.GetByIdsAsync(usuarioId, habilidadeId);
            if (usuarioHabilidade == null)
            {
                throw new KeyNotFoundException("Usuário ou Habilidade não encontrados.");
            }

            usuarioHabilidade.Nivel = request.Nivel;

            await _usuarioHabilidadeRepository.UpdateAsync(usuarioId, habilidadeId, usuarioHabilidade);

            return new UsuarioHabilidadeResponse
            {
                IdUsuario = usuarioHabilidade.IdUsuario,
                IdHabilidade = usuarioHabilidade.IdHabilidade,
                NomeHabilidade = usuarioHabilidade.Habilidade.NomeHabilidade,
                Tipo = usuarioHabilidade.Habilidade.Tipo,
                Nivel = usuarioHabilidade.Nivel
            };
        }

        public async Task DeleteUsuarioHabilidadeAsync(int usuarioId, int habilidadeId)
        {
            var usuarioHabilidade = await _usuarioHabilidadeRepository.GetByIdsAsync(usuarioId, habilidadeId);
            if (usuarioHabilidade == null)
            {
                throw new KeyNotFoundException("Usuário ou Habilidade não encontrados.");
            }

            await _usuarioHabilidadeRepository.DeleteAsync(usuarioId, habilidadeId);
        }
    }
}
