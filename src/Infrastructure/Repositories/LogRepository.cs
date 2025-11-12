using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class LogRepository : ILogRepository
    {
        private readonly OracleDbContext _context;

        public LogRepository(OracleDbContext context)
        {
            _context = context;
        }

        public async Task<List<Log>> GetAllAsync()
        {
            return await _context.Logs.ToListAsync();
        }

        public async Task<Log?> GetByIdAsync(int id)
        {
            return await _context.Logs.FindAsync(id);
        }

        public async Task<List<Log>> GetByTabelaAsync(string tabela)
        {
            return await _context.Logs
                .Where(log => log.Tabela == tabela)
                .ToListAsync();
        }

        public async Task CreateAsync(Log log)
        {
            await _context.Logs.AddAsync(log);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var log = await _context.Logs.FindAsync(id);
            if (log != null)
            {
                _context.Logs.Remove(log);
                await _context.SaveChangesAsync();
            }
        }
    }
}
