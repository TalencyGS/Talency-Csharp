using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class EtapaTrilhaRepository : IEtapaTrilhaRepository
    {
        private readonly OracleDbContext _context;

        public EtapaTrilhaRepository(OracleDbContext context)
        {
            _context = context;
        }

        public async Task<List<EtapaTrilha>> GetAllAsync()
        {
            return await _context.EtapasTrilha.ToListAsync();
        }

        public async Task<EtapaTrilha?> GetByIdAsync(int id)
        {
            return await _context.EtapasTrilha.FindAsync(id);
        }

        public async Task<List<EtapaTrilha>> GetByTrilhaIdAsync(int trilhaId)
        {
            return await _context.EtapasTrilha
                .Where(etapa => etapa.IdTrilha == trilhaId)
                .ToListAsync();
        }

        public async Task CreateAsync(EtapaTrilha etapaTrilha)
        {
            await _context.EtapasTrilha.AddAsync(etapaTrilha);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id, EtapaTrilha etapaTrilha)
        {
            var existingEtapa = await _context.EtapasTrilha.FindAsync(id);
            if (existingEtapa != null)
            {
                existingEtapa.Titulo = etapaTrilha.Titulo;
                existingEtapa.Descricao = etapaTrilha.Descricao;
                existingEtapa.Ordem = etapaTrilha.Ordem;
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            var etapa = await _context.EtapasTrilha.FindAsync(id);
            if (etapa != null)
            {
                _context.EtapasTrilha.Remove(etapa);
                await _context.SaveChangesAsync();
            }
        }
    }
}
