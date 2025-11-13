using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Context;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class MetaRepository : IMetaRepository
    {
        private readonly IMongoCollection<Meta> _metas;

        public MetaRepository(MongoDbContext context)
        {
            _metas = context.Metas;
        }

        public async Task<List<Meta>> GetAllAsync()
        {
            return await _metas
                .Find(Builders<Meta>.Filter.Empty)
                .ToListAsync();
        }

        public async Task<Meta?> GetByIdAsync(int id)
        {
            var filter = Builders<Meta>.Filter.Eq(m => m.IdMeta, id);

            return await _metas
                .Find(filter)
                .FirstOrDefaultAsync();
        }

        public async Task<List<Meta>> GetByRoadmapIdAsync(int roadmapId)
        {
            var filter = Builders<Meta>.Filter.Eq(m => m.IdRoadmap, roadmapId);

            return await _metas
                .Find(filter)
                .ToListAsync();
        }

        public async Task CreateAsync(Meta meta)
        {
            await _metas.InsertOneAsync(meta);
        }

        public async Task UpdateAsync(int id, Meta meta)
        {
            var filter = Builders<Meta>.Filter.Eq(m => m.IdMeta, id);

            var update = Builders<Meta>.Update
                .Set(m => m.Descricao, meta.Descricao)
                .Set(m => m.Status, meta.Status);

            await _metas.UpdateOneAsync(filter, update);
        }

        public async Task DeleteAsync(int id)
        {
            var filter = Builders<Meta>.Filter.Eq(m => m.IdMeta, id);
            await _metas.DeleteOneAsync(filter);
        }
    }
}
