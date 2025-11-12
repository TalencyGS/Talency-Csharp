using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class TrilhaRepository : ITrilhaRepository
    {
        private readonly OracleDbContext _context;

        public TrilhaRepository(OracleDbContext context)
        {
            _context = context;
        }

        public async Task<List<Trilha>> GetAllAsync()
        {
            return await _context.Trilhas.ToListAsync();
        }

        public async Task<Trilha?> GetByIdAsync(int id)
        {
            return await _context.Trilhas.FindAsync(id);
        }

        public async Task CreateAsync(Trilha trilha)
        {
            await _context.Trilhas.AddAsync(trilha);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id, Trilha trilha)
        {
            var existingTrilha = await _context.Trilhas.FindAsync(id);
            if (existingTrilha != null)
            {
                existingTrilha.NomeTrilha = trilha.NomeTrilha;
                existingTrilha.Descricao = trilha.Descricao;
                existingTrilha.Area = trilha.Area;
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            var trilha = await _context.Trilhas.FindAsync(id);
            if (trilha != null)
            {
                _context.Trilhas.Remove(trilha);
                await _context.SaveChangesAsync();
            }
        }
    }
}
