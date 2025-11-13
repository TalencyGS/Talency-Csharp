using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Context;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class HabilidadeRepository : IHabilidadeRepository
    {
        private readonly IMongoCollection<Habilidade> _habilidades;

        public HabilidadeRepository(MongoDbContext context)
        {
            _habilidades = context.Habilidades;
        }

        public async Task<List<Habilidade>> GetAllAsync()
        {
            return await _habilidades
                .Find(Builders<Habilidade>.Filter.Empty)
                .ToListAsync();
        }

        public async Task<Habilidade?> GetByIdAsync(int id)
        {
            var filter = Builders<Habilidade>.Filter.Eq(h => h.IdHabilidade, id);

            return await _habilidades
                .Find(filter)
                .FirstOrDefaultAsync();
        }

        public async Task CreateAsync(Habilidade habilidade)
        {
            await _habilidades.InsertOneAsync(habilidade);
        }

        public async Task UpdateAsync(int id, Habilidade habilidade)
        {
            var filter = Builders<Habilidade>.Filter.Eq(h => h.IdHabilidade, id);

            var update = Builders<Habilidade>.Update
                .Set(h => h.NomeHabilidade, habilidade.NomeHabilidade)
                .Set(h => h.Tipo, habilidade.Tipo);

            await _habilidades.UpdateOneAsync(filter, update);
        }

        public async Task DeleteAsync(int id)
        {
            var filter = Builders<Habilidade>.Filter.Eq(h => h.IdHabilidade, id);
            await _habilidades.DeleteOneAsync(filter);
        }
    }
}
