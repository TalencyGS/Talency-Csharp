using Application.Dtos.EtapaTrilha;
using Application.DTOs.EtapaTrilha;
using Application.Interfaces;
using Domain.Entities;
using Domain.Repositories;

namespace Application.Services
{
    public class EtapaTrilhaService : IEtapaTrilhaService
    {
        private readonly IEtapaTrilhaRepository _etapaTrilhaRepository;

        public EtapaTrilhaService(IEtapaTrilhaRepository etapaTrilhaRepository)
        {
            _etapaTrilhaRepository = etapaTrilhaRepository;
        }

        public async Task<EtapaTrilhaResponse> GetEtapaTrilhaByIdAsync(int id)
        {
            var etapaTrilha = await _etapaTrilhaRepository.GetByIdAsync(id);

            if (etapaTrilha == null)
            {
                throw new KeyNotFoundException("Etapa da trilha não encontrada.");
            }

            return new EtapaTrilhaResponse
            {
                IdEtapa = etapaTrilha.IdEtapa,
                IdTrilha = etapaTrilha.IdTrilha,
                Titulo = etapaTrilha.Titulo,
                Descricao = etapaTrilha.Descricao,
                Ordem = etapaTrilha.Ordem
            };
        }

        public async Task<List<EtapaTrilhaResponse>> GetEtapasByTrilhaIdAsync(int trilhaId)
        {
            var etapasTrilha = await _etapaTrilhaRepository.GetByTrilhaIdAsync(trilhaId);

            return etapasTrilha.Select(etapa => new EtapaTrilhaResponse
            {
                IdEtapa = etapa.IdEtapa,
                IdTrilha = etapa.IdTrilha,
                Titulo = etapa.Titulo,
                Descricao = etapa.Descricao,
                Ordem = etapa.Ordem
            }).ToList();
        }

        public async Task<EtapaTrilhaResponse> CreateEtapaTrilhaAsync(EtapaTrilhaRequest request)
        {

            var trilha = await _etapaTrilhaRepository.GetTrilhaByIdAsync(request.IdTrilha);

            if (trilha == null)
            {
                throw new KeyNotFoundException("Trilha não encontrada.");
            }

            var etapaTrilha = EtapaTrilha.Create(
                trilha,
                request.Titulo,
                request.Descricao,
                request.Ordem
            );

            await _etapaTrilhaRepository.CreateAsync(etapaTrilha);

            return new EtapaTrilhaResponse
            {
                IdEtapa = etapaTrilha.IdEtapa,
                IdTrilha = etapaTrilha.IdTrilha,
                Titulo = etapaTrilha.Titulo,
                Descricao = etapaTrilha.Descricao,
                Ordem = etapaTrilha.Ordem
            };
        }

        public async Task<EtapaTrilhaResponse> UpdateEtapaTrilhaAsync(int id, EtapaTrilhaRequest request)
        {
            var etapaTrilha = await _etapaTrilhaRepository.GetByIdAsync(id);
            if (etapaTrilha == null)
            {
                throw new KeyNotFoundException("Etapa da trilha não encontrada.");
            }

            etapaTrilha.Titulo = request.Titulo;
            etapaTrilha.Descricao = request.Descricao;
            etapaTrilha.Ordem = request.Ordem;

            await _etapaTrilhaRepository.UpdateAsync(id, etapaTrilha);

            return new EtapaTrilhaResponse
            {
                IdEtapa = etapaTrilha.IdEtapa,
                IdTrilha = etapaTrilha.IdTrilha,
                Titulo = etapaTrilha.Titulo,
                Descricao = etapaTrilha.Descricao,
                Ordem = etapaTrilha.Ordem
            };
        }

        public async Task DeleteEtapaTrilhaAsync(int id)
        {
            var etapaTrilha = await _etapaTrilhaRepository.GetByIdAsync(id);
            if (etapaTrilha == null)
            {
                throw new KeyNotFoundException("Etapa da trilha não encontrada.");
            }

            await _etapaTrilhaRepository.DeleteAsync(id);
        }
    }
}
