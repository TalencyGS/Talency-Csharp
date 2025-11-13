using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Context;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class RoadmapRepository : IRoadmapRepository
    {
        private readonly IMongoCollection<Roadmap> _roadmaps;

        public RoadmapRepository(MongoDbContext context)
        {
            _roadmaps = context.Roadmaps;
        }

        public async Task<List<Roadmap>> GetAllAsync()
        {
            return await _roadmaps
                .Find(Builders<Roadmap>.Filter.Empty)
                .ToListAsync();
        }

        public async Task<Roadmap?> GetByIdAsync(int id)
        {
            var filter = Builders<Roadmap>.Filter.Eq(r => r.IdRoadmap, id);

            return await _roadmaps
                .Find(filter)
                .FirstOrDefaultAsync();
        }

        public async Task<List<Roadmap>> GetByUsuarioIdAsync(int usuarioId)
        {
            var filter = Builders<Roadmap>.Filter.Eq(r => r.IdUsuario, usuarioId);

            return await _roadmaps
                .Find(filter)
                .ToListAsync();
        }

        public async Task CreateAsync(Roadmap roadmap)
        {
            await _roadmaps.InsertOneAsync(roadmap);
        }

        public async Task UpdateAsync(int id, Roadmap roadmap)
        {
            var filter = Builders<Roadmap>.Filter.Eq(r => r.IdRoadmap, id);

            var update = Builders<Roadmap>.Update
                .Set(r => r.Status, roadmap.Status)
                .Set(r => r.Trilha, roadmap.Trilha);

            await _roadmaps.UpdateOneAsync(filter, update);
        }

        public async Task DeleteAsync(int id)
        {
            var filter = Builders<Roadmap>.Filter.Eq(r => r.IdRoadmap, id);
            await _roadmaps.DeleteOneAsync(filter);
        }
    }
}
