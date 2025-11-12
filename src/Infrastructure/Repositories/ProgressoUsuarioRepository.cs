using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class ProgressoUsuarioRepository : IProgressoUsuarioRepository
    {
        private readonly OracleDbContext _context;

        public ProgressoUsuarioRepository(OracleDbContext context)
        {
            _context = context;
        }

        public async Task<List<ProgressoUsuario>> GetAllAsync()
        {
            return await _context.ProgressoUsuarios.ToListAsync();
        }

        public async Task<ProgressoUsuario?> GetByIdAsync(int id)
        {
            return await _context.ProgressoUsuarios.FindAsync(id);
        }

        public async Task<List<ProgressoUsuario>> GetByUsuarioIdAsync(int usuarioId)
        {
            return await _context.ProgressoUsuarios
                .Where(p => p.IdUsuario == usuarioId)
                .ToListAsync();
        }

        public async Task CreateAsync(ProgressoUsuario progressoUsuario)
        {
            await _context.ProgressoUsuarios.AddAsync(progressoUsuario);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id, ProgressoUsuario progressoUsuario)
        {
            var existingProgresso = await _context.ProgressoUsuarios.FindAsync(id);
            if (existingProgresso != null)
            {
                existingProgresso.Percentual = progressoUsuario.Percentual;
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            var progresso = await _context.ProgressoUsuarios.FindAsync(id);
            if (progresso != null)
            {
                _context.ProgressoUsuarios.Remove(progresso);
                await _context.SaveChangesAsync();
            }
        }
    }
}
