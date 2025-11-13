using Application.DTOs.Habilidade;
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

    public class HabilidadeService : IHabilidadeService
    {
        private readonly IHabilidadeRepository _habilidadeRepository;

        public HabilidadeService(IHabilidadeRepository habilidadeRepository)
        {
            _habilidadeRepository = habilidadeRepository;
        }

        public async Task<HabilidadeResponse> GetHabilidadeByIdAsync(int id)
        {
            var habilidade = await _habilidadeRepository.GetByIdAsync(id);
            if (habilidade == null)
            {
                throw new KeyNotFoundException("Habilidade não encontrada.");
            }

            return new HabilidadeResponse
            {
                IdHabilidade = habilidade.IdHabilidade,
                NomeHabilidade = habilidade.NomeHabilidade,
                Tipo = habilidade.Tipo
            };
        }

        public async Task<List<HabilidadeResponse>> GetAllHabilidadesAsync()
        {
            var habilidades = await _habilidadeRepository.GetAllAsync();

            return habilidades.Select(habilidade => new HabilidadeResponse
            {
                IdHabilidade = habilidade.IdHabilidade,
                NomeHabilidade = habilidade.NomeHabilidade,
                Tipo = habilidade.Tipo
            }).ToList();
        }

        public async Task<HabilidadeResponse> CreateHabilidadeAsync(HabilidadeRequest request)
        {
            var habilidade = Habilidade.Create(request.NomeHabilidade, request.Tipo);

            await _habilidadeRepository.CreateAsync(habilidade);

            return new HabilidadeResponse
            {
                IdHabilidade = habilidade.IdHabilidade,
                NomeHabilidade = habilidade.NomeHabilidade,
                Tipo = habilidade.Tipo
            };
        }

        public async Task<HabilidadeResponse> UpdateHabilidadeAsync(int id, HabilidadeRequest request)
        {
            var habilidade = await _habilidadeRepository.GetByIdAsync(id);
            if (habilidade == null)
            {
                throw new KeyNotFoundException("Habilidade não encontrada.");
            }

            habilidade.NomeHabilidade = request.NomeHabilidade;
            habilidade.Tipo = request.Tipo;

            await _habilidadeRepository.UpdateAsync(id, habilidade);

            return new HabilidadeResponse
            {
                IdHabilidade = habilidade.IdHabilidade,
                NomeHabilidade = habilidade.NomeHabilidade,
                Tipo = habilidade.Tipo
            };
        }

        public async Task DeleteHabilidadeAsync(int id)
        {
            var habilidade = await _habilidadeRepository.GetByIdAsync(id);
            if (habilidade == null)
            {
                throw new KeyNotFoundException("Habilidade não encontrada.");
            }

            await _habilidadeRepository.DeleteAsync(id);
        }
    }
}
