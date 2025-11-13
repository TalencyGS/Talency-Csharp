using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Context;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class EtapaTrilhaRepository : IEtapaTrilhaRepository
    {
        private readonly IMongoCollection<EtapaTrilha> _etapasTrilha;

        public EtapaTrilhaRepository(MongoDbContext context)
        {
            _etapasTrilha = context.EtapasTrilha;
        }

        public async Task<List<EtapaTrilha>> GetAllAsync()
        {
            return await _etapasTrilha
                .Find(Builders<EtapaTrilha>.Filter.Empty)
                .ToListAsync();
        }

        public async Task<EtapaTrilha?> GetByIdAsync(int id)
        {
            var filter = Builders<EtapaTrilha>.Filter.Eq(e => e.IdEtapa, id);

            return await _etapasTrilha
                .Find(filter)
                .FirstOrDefaultAsync();
        }

        public async Task<List<EtapaTrilha>> GetByTrilhaIdAsync(int trilhaId)
        {
            var filter = Builders<EtapaTrilha>.Filter.Eq(e => e.IdTrilha, trilhaId);

            return await _etapasTrilha
                .Find(filter)
                .ToListAsync();
        }

        public async Task CreateAsync(EtapaTrilha etapaTrilha)
        {
            await _etapasTrilha.InsertOneAsync(etapaTrilha);
        }

        public async Task UpdateAsync(int id, EtapaTrilha etapaTrilha)
        {
            var filter = Builders<EtapaTrilha>.Filter.Eq(e => e.IdEtapa, id);

            var update = Builders<EtapaTrilha>.Update
                .Set(e => e.Titulo, etapaTrilha.Titulo)
                .Set(e => e.Descricao, etapaTrilha.Descricao)
                .Set(e => e.Ordem, etapaTrilha.Ordem);

            await _etapasTrilha.UpdateOneAsync(filter, update);
        }

        public async Task DeleteAsync(int id)
        {
            var filter = Builders<EtapaTrilha>.Filter.Eq(e => e.IdEtapa, id);
            await _etapasTrilha.DeleteOneAsync(filter);
        }
    }
}
