using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Context;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class TrilhaRepository : ITrilhaRepository
    {
        private readonly IMongoCollection<Trilha> _trilhas;

        public TrilhaRepository(MongoDbContext context)
        {
            _trilhas = context.Trilhas;
        }

        public async Task<List<Trilha>> GetAllAsync()
        {
            return await _trilhas
                .Find(Builders<Trilha>.Filter.Empty)
                .ToListAsync();
        }

        public async Task<Trilha?> GetByIdAsync(int id)
        {
            var filter = Builders<Trilha>.Filter.Eq(t => t.IdTrilha, id);

            return await _trilhas
                .Find(filter)
                .FirstOrDefaultAsync();
        }

        public async Task CreateAsync(Trilha trilha)
        {
            await _trilhas.InsertOneAsync(trilha);
        }

        public async Task UpdateAsync(int id, Trilha trilha)
        {
            var filter = Builders<Trilha>.Filter.Eq(t => t.IdTrilha, id);

            var update = Builders<Trilha>.Update
                .Set(t => t.NomeTrilha, trilha.NomeTrilha)
                .Set(t => t.Descricao, trilha.Descricao)
                .Set(t => t.Area, trilha.Area);

            await _trilhas.UpdateOneAsync(filter, update);
        }

        public async Task DeleteAsync(int id)
        {
            var filter = Builders<Trilha>.Filter.Eq(t => t.IdTrilha, id);
            await _trilhas.DeleteOneAsync(filter);
        }
    }
}
