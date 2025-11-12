using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class UsuarioHabilidadeRepository : IUsuarioHabilidadeRepository
    {
        private readonly OracleDbContext _context;

        public UsuarioHabilidadeRepository(OracleDbContext context)
        {
            _context = context;
        }

        public async Task<List<UsuarioHabilidade>> GetAllAsync()
        {
            return await _context.UsuarioHabilidades.ToListAsync();
        }

        public async Task<UsuarioHabilidade?> GetByIdsAsync(int usuarioId, int habilidadeId)
        {
            return await _context.UsuarioHabilidades
                .FirstOrDefaultAsync(uh => uh.IdUsuario == usuarioId && uh.IdHabilidade == habilidadeId);
        }

        public async Task CreateAsync(UsuarioHabilidade usuarioHabilidade)
        {
            await _context.UsuarioHabilidades.AddAsync(usuarioHabilidade);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(int usuarioId, int habilidadeId, UsuarioHabilidade usuarioHabilidade)
        {
            var existingUsuarioHabilidade = await _context.UsuarioHabilidades
                .FirstOrDefaultAsync(uh => uh.IdUsuario == usuarioId && uh.IdHabilidade == habilidadeId);

            if (existingUsuarioHabilidade != null)
            {
                existingUsuarioHabilidade.Nivel = usuarioHabilidade.Nivel;
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int usuarioId, int habilidadeId)
        {
            var usuarioHabilidade = await _context.UsuarioHabilidades
                .FirstOrDefaultAsync(uh => uh.IdUsuario == usuarioId && uh.IdHabilidade == habilidadeId);

            if (usuarioHabilidade != null)
            {
                _context.UsuarioHabilidades.Remove(usuarioHabilidade);
                await _context.SaveChangesAsync();
            }
        }
    }
}
