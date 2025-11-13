using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Context;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class LogRepository : ILogRepository
    {
        private readonly IMongoCollection<Log> _logs;

        public LogRepository(MongoDbContext context)
        {
            _logs = context.Logs;
        }

        public async Task<List<Log>> GetAllAsync()
        {
            return await _logs
                .Find(Builders<Log>.Filter.Empty)
                .ToListAsync();
        }

        public async Task<Log?> GetByIdAsync(int id)
        {
            var filter = Builders<Log>.Filter.Eq(l => l.IdLog, id);

            return await _logs
                .Find(filter)
                .FirstOrDefaultAsync();
        }

        public async Task<List<Log>> GetByTabelaAsync(string tabela)
        {
            var filter = Builders<Log>.Filter.Eq(l => l.Tabela, tabela);

            return await _logs
                .Find(filter)
                .ToListAsync();
        }

        public async Task CreateAsync(Log log)
        {
            await _logs.InsertOneAsync(log);
        }

        public async Task DeleteAsync(int id)
        {
            var filter = Builders<Log>.Filter.Eq(l => l.IdLog, id);
            await _logs.DeleteOneAsync(filter);
        }
    }
}
