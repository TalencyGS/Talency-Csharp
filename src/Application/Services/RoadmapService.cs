using Application.DTOs.Roadmap;
using Application.DTOs.Meta;
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
    public class RoadmapService : IRoadmapService
    {
        private readonly IRoadmapRepository _roadmapRepository;
        private readonly ITrilhaRepository _trilhaRepository;
        private readonly IUsuarioRepository _usuarioRepository;

        public RoadmapService(IRoadmapRepository roadmapRepository, ITrilhaRepository trilhaRepository, IUsuarioRepository usuarioRepository)
        {
            _roadmapRepository = roadmapRepository;
            _trilhaRepository = trilhaRepository;
            _usuarioRepository = usuarioRepository;
        }

        public async Task<RoadmapResponse> GetRoadmapByIdAsync(int id)
        {
            var roadmap = await _roadmapRepository.GetByIdAsync(id);
            if (roadmap == null)
            {
                throw new KeyNotFoundException("Roadmap não encontrado.");
            }

            return new RoadmapResponse
            {
                IdRoadmap = roadmap.IdRoadmap,
                IdUsuario = roadmap.IdUsuario,
                IdTrilha = roadmap.IdTrilha,
                Status = roadmap.Status,
                Metas = roadmap.Metas.Select(meta => new MetaResponse
                {
                    IdMeta = meta.IdMeta,
                    IdRoadmap = meta.IdRoadmap,
                    Descricao = meta.Descricao,
                    Status = meta.Status
                }).ToList()
            };
        }

        public async Task<List<RoadmapResponse>> GetRoadmapsByUsuarioIdAsync(int usuarioId)
        {
            var roadmaps = await _roadmapRepository.GetByUsuarioIdAsync(usuarioId);

            return roadmaps.Select(roadmap => new RoadmapResponse
            {
                IdRoadmap = roadmap.IdRoadmap,
                IdUsuario = roadmap.IdUsuario,
                IdTrilha = roadmap.IdTrilha,
                Status = roadmap.Status,
                Metas = roadmap.Metas.Select(meta => new MetaResponse
                {
                    IdMeta = meta.IdMeta,
                    IdRoadmap = meta.IdRoadmap,
                    Descricao = meta.Descricao,
                    Status = meta.Status
                }).ToList()
            }).ToList();
        }

        public async Task<RoadmapResponse> CreateRoadmapAsync(RoadmapCreateRequest request)
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

            var roadmap = Roadmap.Create(usuario, trilha, request.Status);

            await _roadmapRepository.CreateAsync(roadmap);

            return new RoadmapResponse
            {
                IdRoadmap = roadmap.IdRoadmap,
                IdUsuario = roadmap.IdUsuario,
                IdTrilha = roadmap.IdTrilha,
                Status = roadmap.Status,
                Metas = roadmap.Metas.Select(meta => new MetaResponse
                {
                    IdMeta = meta.IdMeta,
                    IdRoadmap = meta.IdRoadmap,
                    Descricao = meta.Descricao,
                    Status = meta.Status
                }).ToList()
            };
        }

        public async Task<RoadmapResponse> UpdateRoadmapAsync(int id, RoadmapCreateRequest request)
        {
            var roadmap = await _roadmapRepository.GetByIdAsync(id);
            if (roadmap == null)
            {
                throw new KeyNotFoundException("Roadmap não encontrado.");
            }

            roadmap.Status = request.Status;

            await _roadmapRepository.UpdateAsync(id, roadmap);

            return new RoadmapResponse
            {
                IdRoadmap = roadmap.IdRoadmap,
                IdUsuario = roadmap.IdUsuario,
                IdTrilha = roadmap.IdTrilha,
                Status = roadmap.Status,
                Metas = roadmap.Metas.Select(meta => new MetaResponse
                {
                    IdMeta = meta.IdMeta,
                    IdRoadmap = meta.IdRoadmap,
                    Descricao = meta.Descricao,
                    Status = meta.Status
                }).ToList()
            };
        }

        public async Task DeleteRoadmapAsync(int id)
        {
            var roadmap = await _roadmapRepository.GetByIdAsync(id);
            if (roadmap == null)
            {
                throw new KeyNotFoundException("Roadmap não encontrado.");
            }

            await _roadmapRepository.DeleteAsync(id);
        }
    }
}
