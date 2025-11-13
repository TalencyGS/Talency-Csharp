using Application.DTOs.Teste;
using Application.Interfaces;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class TesteService : ITesteService
    {
        private readonly ITesteRepository _testeRepository;

        public TesteService(ITesteRepository testeRepository)
        {
            _testeRepository = testeRepository;
        }

        public async Task<TesteResponse> GetTesteByIdAsync(int id)
        {
            var teste = await _testeRepository.GetByIdAsync(id);
            if (teste == null)
            {
                throw new KeyNotFoundException("Teste não encontrado.");
            }

            return new TesteResponse
            {
                IdTeste = teste.IdTeste,
                IdEtapa = teste.IdEtapa,
                Titulo = teste.Titulo
            };
        }

        public async Task<List<TesteResponse>> GetTestesByEtapaIdAsync(int etapaId)
        {
            var testes = await _testeRepository.GetByEtapaIdAsync(etapaId);

            return testes.Select(t => new TesteResponse
            {
                IdTeste = t.IdTeste,
                IdEtapa = t.IdEtapa,
                Titulo = t.Titulo
            }).ToList();
        }
    }
}
