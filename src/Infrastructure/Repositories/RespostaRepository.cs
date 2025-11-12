using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class RespostaRepository : IRespostaRepository
    {
        private readonly OracleDbContext _context;

        public RespostaRepository(OracleDbContext context)
        {
            _context = context;
        }

        public async Task<List<Resposta>> GetAllAsync()
        {
            return await _context.Respostas.ToListAsync();
        }

        public async Task<Resposta?> GetByIdAsync(int id)
        {
            return await _context.Respostas.FindAsync(id);
        }

        public async Task<List<Resposta>> GetByUsuarioIdAsync(int usuarioId)
        {
            return await _context.Respostas
                .Where(resposta => resposta.IdUsuario == usuarioId)
                .ToListAsync();
        }

        public async Task CreateAsync(Resposta resposta)
        {
            await _context.Respostas.AddAsync(resposta);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id, Resposta resposta)
        {
            var existingResposta = await _context.Respostas.FindAsync(id);
            if (existingResposta != null)
            {
                existingResposta.ConteudoResposta = resposta.ConteudoResposta;
                existingResposta.Pontuacao = resposta.Pontuacao;
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            var resposta = await _context.Respostas.FindAsync(id);
            if (resposta != null)
            {
                _context.Respostas.Remove(resposta);
                await _context.SaveChangesAsync();
            }
        }
    }
}
