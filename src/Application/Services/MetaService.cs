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
    public class MetaService : IMetaService
    {
        private readonly IMetaRepository _metaRepository;
        private readonly IRoadmapRepository _roadmapRepository;

        public MetaService(IMetaRepository metaRepository, IRoadmapRepository roadmapRepository)
        {
            _metaRepository = metaRepository;
            _roadmapRepository = roadmapRepository;
        }

        public async Task<MetaResponse> GetMetaByIdAsync(int id)
        {
            var meta = await _metaRepository.GetByIdAsync(id);
            if (meta == null)
            {
                throw new KeyNotFoundException("Meta não encontrada.");
            }

            return new MetaResponse
            {
                IdMeta = meta.IdMeta,
                IdRoadmap = meta.IdRoadmap,
                Descricao = meta.Descricao,
                Status = meta.Status
            };
        }

        public async Task<List<MetaResponse>> GetMetasByRoadmapIdAsync(int roadmapId)
        {
            var metas = await _metaRepository.GetByRoadmapIdAsync(roadmapId);

            return metas.Select(meta => new MetaResponse
            {
                IdMeta = meta.IdMeta,
                IdRoadmap = meta.IdRoadmap,
                Descricao = meta.Descricao,
                Status = meta.Status
            }).ToList();
        }

        public async Task<MetaResponse> CreateMetaAsync(MetaRequest request)
        {
            var roadmap = await _roadmapRepository.GetByIdAsync(request.IdRoadmap);
            if (roadmap == null)
            {
                throw new KeyNotFoundException("Roadmap não encontrado.");
            }

            var meta = Meta.Create(roadmap, request.Descricao, request.Status);

            await _metaRepository.CreateAsync(meta);

            return new MetaResponse
            {
                IdMeta = meta.IdMeta,
                IdRoadmap = meta.IdRoadmap,
                Descricao = meta.Descricao,
                Status = meta.Status
            };
        }

        public async Task<MetaResponse> UpdateMetaAsync(int id, MetaRequest request)
        {
            var meta = await _metaRepository.GetByIdAsync(id);
            if (meta == null)
            {
                throw new KeyNotFoundException("Meta não encontrada.");
            }

            meta.Descricao = request.Descricao;
            meta.Status = request.Status;

            await _metaRepository.UpdateAsync(id, meta);

            return new MetaResponse
            {
                IdMeta = meta.IdMeta,
                IdRoadmap = meta.IdRoadmap,
                Descricao = meta.Descricao,
                Status = meta.Status
            };
        }

        public async Task DeleteMetaAsync(int id)
        {
            var meta = await _metaRepository.GetByIdAsync(id);
            if (meta == null)
            {
                throw new KeyNotFoundException("Meta não encontrada.");
            }

            await _metaRepository.DeleteAsync(id);
        }
}
