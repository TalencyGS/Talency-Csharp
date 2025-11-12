using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class HabilidadeRepository : IHabilidadeRepository
    {
        private readonly OracleDbContext _context;

        public HabilidadeRepository(OracleDbContext context)
        {
            _context = context;
        }

        public async Task<List<Habilidade>> GetAllAsync()
        {
            return await _context.Habilidades.ToListAsync();
        }

        public async Task<Habilidade?> GetByIdAsync(int id)
        {
            return await _context.Habilidades.FindAsync(id);
        }

        public async Task CreateAsync(Habilidade habilidade)
        {
            await _context.Habilidades.AddAsync(habilidade);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id, Habilidade habilidade)
        {
            var existingHabilidade = await _context.Habilidades.FindAsync(id);
            if (existingHabilidade != null)
            {
                existingHabilidade.NomeHabilidade = habilidade.NomeHabilidade;
                existingHabilidade.Tipo = habilidade.Tipo;
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            var habilidade = await _context.Habilidades.FindAsync(id);
            if (habilidade != null)
            {
                _context.Habilidades.Remove(habilidade);
                await _context.SaveChangesAsync();
            }
        }
    }
}
