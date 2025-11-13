using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Context;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class UsuarioHabilidadeRepository : IUsuarioHabilidadeRepository
    {
        private readonly IMongoCollection<UsuarioHabilidade> _usuarioHabilidades;

        public UsuarioHabilidadeRepository(MongoDbContext context)
        {
            _usuarioHabilidades = context.UsuarioHabilidades;
        }

        public async Task<List<UsuarioHabilidade>> GetAllAsync()
        {
            return await _usuarioHabilidades
                .Find(Builders<UsuarioHabilidade>.Filter.Empty)
                .ToListAsync();
        }

        public async Task<UsuarioHabilidade?> GetByIdsAsync(int usuarioId, int habilidadeId)
        {
            var filter = Builders<UsuarioHabilidade>.Filter.And(
                Builders<UsuarioHabilidade>.Filter.Eq(uh => uh.IdUsuario, usuarioId),
                Builders<UsuarioHabilidade>.Filter.Eq(uh => uh.IdHabilidade, habilidadeId)
            );

            return await _usuarioHabilidades
                .Find(filter)
                .FirstOrDefaultAsync();
        }

        public async Task CreateAsync(UsuarioHabilidade usuarioHabilidade)
        {
            await _usuarioHabilidades.InsertOneAsync(usuarioHabilidade);
        }

        public async Task UpdateAsync(int usuarioId, int habilidadeId, UsuarioHabilidade usuarioHabilidade)
        {
            var filter = Builders<UsuarioHabilidade>.Filter.And(
                Builders<UsuarioHabilidade>.Filter.Eq(uh => uh.IdUsuario, usuarioId),
                Builders<UsuarioHabilidade>.Filter.Eq(uh => uh.IdHabilidade, habilidadeId)
            );

            var update = Builders<UsuarioHabilidade>.Update
                .Set(uh => uh.Nivel, usuarioHabilidade.Nivel);

            await _usuarioHabilidades.UpdateOneAsync(filter, update);
        }

        public async Task DeleteAsync(int usuarioId, int habilidadeId)
        {
            var filter = Builders<UsuarioHabilidade>.Filter.And(
                Builders<UsuarioHabilidade>.Filter.Eq(uh => uh.IdUsuario, usuarioId),
                Builders<UsuarioHabilidade>.Filter.Eq(uh => uh.IdHabilidade, habilidadeId)
            );

            await _usuarioHabilidades.DeleteOneAsync(filter);
        }
    }
}
