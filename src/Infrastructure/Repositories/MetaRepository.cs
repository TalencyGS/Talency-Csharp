using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class MetaRepository : IMetaRepository
    {
        private readonly OracleDbContext _context;

        public MetaRepository(OracleDbContext context)
        {
            _context = context;
        }

        public async Task<List<Meta>> GetAllAsync()
        {
            return await _context.Metas.ToListAsync();
        }

        public async Task<Meta?> GetByIdAsync(int id)
        {
            return await _context.Metas.FindAsync(id);
        }

        public async Task<List<Meta>> GetByRoadmapIdAsync(int roadmapId)
        {
            return await _context.Metas
                .Where(meta => meta.IdRoadmap == roadmapId)
                .ToListAsync();
        }

        public async Task CreateAsync(Meta meta)
        {
            await _context.Metas.AddAsync(meta);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id, Meta meta)
        {
            var existingMeta = await _context.Metas.FindAsync(id);
            if (existingMeta != null)
            {
                existingMeta.Descricao = meta.Descricao;
                existingMeta.Status = meta.Status;
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            var meta = await _context.Metas.FindAsync(id);
            if (meta != null)
            {
                _context.Metas.Remove(meta);
                await _context.SaveChangesAsync();
            }
        }
    }
}
