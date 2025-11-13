using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Context;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly IMongoCollection<Usuario> _usuarios;

        public UsuarioRepository(MongoDbContext context)
        {
            _usuarios = context.Usuarios;
        }

        public async Task<List<Usuario>> GetAllAsync()
        {
            return await _usuarios
                .Find(Builders<Usuario>.Filter.Empty)
                .ToListAsync();
        }

        public async Task<Usuario?> GetByIdAsync(int id)
        {
            var filter = Builders<Usuario>.Filter.Eq(u => u.IdUsuario, id);

            return await _usuarios
                .Find(filter)
                .FirstOrDefaultAsync();
        }

        public async Task CreateAsync(Usuario usuario)
        {
            await _usuarios.InsertOneAsync(usuario);
        }

        public async Task UpdateAsync(int id, Usuario usuario)
        {
            var filter = Builders<Usuario>.Filter.Eq(u => u.IdUsuario, id);

            var update = Builders<Usuario>.Update
                .Set(u => u.Nome, usuario.Nome)
                .Set(u => u.Email, usuario.Email)
                .Set(u => u.SenhaHash, usuario.SenhaHash)
                .Set(u => u.AreaInteresse, usuario.AreaInteresse);

            await _usuarios.UpdateOneAsync(filter, update);
        }

        public async Task DeleteAsync(int id)
        {
            var filter = Builders<Usuario>.Filter.Eq(u => u.IdUsuario, id);
            await _usuarios.DeleteOneAsync(filter);
        }

        public async Task<Usuario?> GetByEmailAsync(string email)
        {
            var filter = Builders<Usuario>.Filter.Eq(u => u.Email, email);

            return await _usuarios
                .Find(filter)
                .FirstOrDefaultAsync();
        }
    }
}
