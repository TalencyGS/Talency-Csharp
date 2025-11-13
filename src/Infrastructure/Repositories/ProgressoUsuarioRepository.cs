using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Context;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class ProgressoUsuarioRepository : IProgressoUsuarioRepository
    {
        private readonly IMongoCollection<ProgressoUsuario> _progressoUsuarios;

        public ProgressoUsuarioRepository(MongoDbContext context)
        {
            _progressoUsuarios = context.ProgressoUsuarios;
        }

        public async Task<List<ProgressoUsuario>> GetAllAsync()
        {
            return await _progressoUsuarios
                .Find(Builders<ProgressoUsuario>.Filter.Empty)
                .ToListAsync();
        }

        public async Task<ProgressoUsuario?> GetByIdAsync(int id)
        {
            var filter = Builders<ProgressoUsuario>.Filter.Eq(p => p.IdProgresso, id);

            return await _progressoUsuarios
                .Find(filter)
                .FirstOrDefaultAsync();
        }

        public async Task<List<ProgressoUsuario>> GetByUsuarioIdAsync(int usuarioId)
        {
            var filter = Builders<ProgressoUsuario>.Filter.Eq(p => p.IdUsuario, usuarioId);

            return await _progressoUsuarios
                .Find(filter)
                .ToListAsync();
        }

        public async Task CreateAsync(ProgressoUsuario progressoUsuario)
        {
            await _progressoUsuarios.InsertOneAsync(progressoUsuario);
        }

        public async Task UpdateAsync(int id, ProgressoUsuario progressoUsuario)
        {
            var filter = Builders<ProgressoUsuario>.Filter.Eq(p => p.IdProgresso, id);

            var update = Builders<ProgressoUsuario>.Update
                .Set(p => p.Percentual, progressoUsuario.Percentual);

            await _progressoUsuarios.UpdateOneAsync(filter, update);
        }

        public async Task DeleteAsync(int id)
        {
            var filter = Builders<ProgressoUsuario>.Filter.Eq(p => p.IdProgresso, id);
            await _progressoUsuarios.DeleteOneAsync(filter);
        }
    }
}
