using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class RoadmapRepository : IRoadmapRepository
    {
        private readonly OracleDbContext _context;

        public RoadmapRepository(OracleDbContext context)
        {
            _context = context;
        }

        public async Task<List<Roadmap>> GetAllAsync()
        {
            return await _context.Roadmaps.ToListAsync();
        }

        public async Task<Roadmap?> GetByIdAsync(int id)
        {
            return await _context.Roadmaps.FindAsync(id);
        }

        public async Task<List<Roadmap>> GetByUsuarioIdAsync(int usuarioId)
        {
            return await _context.Roadmaps
                .Where(roadmap => roadmap.IdUsuario == usuarioId)
                .ToListAsync();
        }

        public async Task CreateAsync(Roadmap roadmap)
        {
            await _context.Roadmaps.AddAsync(roadmap);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id, Roadmap roadmap)
        {
            var existingRoadmap = await _context.Roadmaps.FindAsync(id);
            if (existingRoadmap != null)
            {
                existingRoadmap.Status = roadmap.Status;
                existingRoadmap.Trilha = roadmap.Trilha;
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            var roadmap = await _context.Roadmaps.FindAsync(id);
            if (roadmap != null)
            {
                _context.Roadmaps.Remove(roadmap);
                await _context.SaveChangesAsync();
            }
        }
    }
}
