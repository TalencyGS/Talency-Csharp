using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Context;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class TesteRepository : ITesteRepository
    {
        private readonly IMongoCollection<Teste> _testes;

        public TesteRepository(MongoDbContext context)
        {
            _testes = context.Testes;
        }

        public async Task<List<Teste>> GetAllAsync()
        {
            return await _testes
                .Find(Builders<Teste>.Filter.Empty)
                .ToListAsync();
        }

        public async Task<Teste?> GetByIdAsync(int id)
        {
            var filter = Builders<Teste>.Filter.Eq(t => t.IdTeste, id);

            return await _testes
                .Find(filter)
                .FirstOrDefaultAsync();
        }

        public async Task<List<Teste>> GetByEtapaIdAsync(int etapaId)
        {
            var filter = Builders<Teste>.Filter.Eq(t => t.IdEtapa, etapaId);

            return await _testes
                .Find(filter)
                .ToListAsync();
        }

        public async Task CreateAsync(Teste teste)
        {
            await _testes.InsertOneAsync(teste);
        }

        public async Task UpdateAsync(int id, Teste teste)
        {
            var filter = Builders<Teste>.Filter.Eq(t => t.IdTeste, id);

            var update = Builders<Teste>.Update
                .Set(t => t.Titulo, teste.Titulo);

            await _testes.UpdateOneAsync(filter, update);
        }

        public async Task DeleteAsync(int id)
        {
            var filter = Builders<Teste>.Filter.Eq(t => t.IdTeste, id);
            await _testes.DeleteOneAsync(filter);
        }
    }
}
