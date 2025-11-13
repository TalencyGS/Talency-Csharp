using Application.DTOs.Trilha;
using Domain.Entities;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class TrilhaService : ITrilhaService
    {
        private readonly ITrilhaRepository _trilhaRepository;

        public TrilhaService(ITrilhaRepository trilhaRepository)
        {
            _trilhaRepository = trilhaRepository;
        }

        public async Task<TrilhaResponse> GetTrilhaByIdAsync(int id)
        {
            var trilha = await _trilhaRepository.GetByIdAsync(id);
            if (trilha == null)
            {
                throw new KeyNotFoundException("Trilha não encontrada.");
            }

            return new TrilhaResponse
            {
                IdTrilha = trilha.IdTrilha,
                NomeTrilha = trilha.NomeTrilha,
                Descricao = trilha.Descricao,
                Area = trilha.Area
            };
        }

        public async Task<List<TrilhaResponse>> GetAllTrilhasAsync()
        {
            var trilhas = await _trilhaRepository.GetAllAsync();

            return trilhas.Select(trilha => new TrilhaResponse
            {
                IdTrilha = trilha.IdTrilha,
                NomeTrilha = trilha.NomeTrilha,
                Descricao = trilha.Descricao,
                Area = trilha.Area
            }).ToList();
        }

        public async Task<TrilhaResponse> CreateTrilhaAsync(TrilhaRequest request)
        {
            var trilha = Trilha.Create(request.NomeTrilha, request.Descricao, request.Area);

            await _trilhaRepository.CreateAsync(trilha);

            return new TrilhaResponse
            {
                IdTrilha = trilha.IdTrilha,
                NomeTrilha = trilha.NomeTrilha,
                Descricao = trilha.Descricao,
                Area = trilha.Area
            };
        }

        public async Task<TrilhaResponse> UpdateTrilhaAsync(int id, TrilhaRequest request)
        {
            var trilha = await _trilhaRepository.GetByIdAsync(id);
            if (trilha == null)
            {
                throw new KeyNotFoundException("Trilha não encontrada.");
            }

            trilha.NomeTrilha = request.NomeTrilha;
            trilha.Descricao = request.Descricao;
            trilha.Area = request.Area;

            await _trilhaRepository.UpdateAsync(id, trilha);

            return new TrilhaResponse
            {
                IdTrilha = trilha.IdTrilha,
                NomeTrilha = trilha.NomeTrilha,
                Descricao = trilha.Descricao,
                Area = trilha.Area
            };
        }

        public async Task DeleteTrilhaAsync(int id)
        {
            var trilha = await _trilhaRepository.GetByIdAsync(id);
            if (trilha == null)
            {
                throw new KeyNotFoundException("Trilha não encontrada.");
            }

            await _trilhaRepository.DeleteAsync(id);
        }
    }
}
