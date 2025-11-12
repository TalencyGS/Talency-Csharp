using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class TesteRepository : ITesteRepository
    {
        private readonly OracleDbContext _context;

        public TesteRepository(OracleDbContext context)
        {
            _context = context;
        }

        public async Task<List<Teste>> GetAllAsync()
        {
            return await _context.Testes.ToListAsync();
        }

        public async Task<Teste?> GetByIdAsync(int id)
        {
            return await _context.Testes.FindAsync(id);
        }

        public async Task<List<Teste>> GetByEtapaIdAsync(int etapaId)
        {
            return await _context.Testes
                .Where(t => t.IdEtapa == etapaId)
                .ToListAsync();
        }

        public async Task CreateAsync(Teste teste)
        {
            await _context.Testes.AddAsync(teste);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id, Teste teste)
        {
            var existingTeste = await _context.Testes.FindAsync(id);
            if (existingTeste != null)
            {
                existingTeste.Titulo = teste.Titulo;
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            var teste = await _context.Testes.FindAsync(id);
            if (teste != null)
            {
                _context.Testes.Remove(teste);
                await _context.SaveChangesAsync();
            }
        }
    }
}
