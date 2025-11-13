using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Context;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class RespostaRepository : IRespostaRepository
    {
        private readonly IMongoCollection<Resposta> _respostas;

        public RespostaRepository(MongoDbContext context)
        {
            _respostas = context.Respostas;
        }

        public async Task<List<Resposta>> GetAllAsync()
        {
            return await _respostas
                .Find(Builders<Resposta>.Filter.Empty)
                .ToListAsync();
        }

        public async Task<Resposta?> GetByIdAsync(int id)
        {
            var filter = Builders<Resposta>.Filter.Eq(r => r.IdResposta, id);

            return await _respostas
                .Find(filter)
                .FirstOrDefaultAsync();
        }

        public async Task<List<Resposta>> GetByUsuarioIdAsync(int usuarioId)
        {
            var filter = Builders<Resposta>.Filter.Eq(r => r.IdUsuario, usuarioId);

            return await _respostas
                .Find(filter)
                .ToListAsync();
        }

        public async Task CreateAsync(Resposta resposta)
        {
            await _respostas.InsertOneAsync(resposta);
        }

        public async Task UpdateAsync(int id, Resposta resposta)
        {
            var filter = Builders<Resposta>.Filter.Eq(r => r.IdResposta, id);

            var update = Builders<Resposta>.Update
                .Set(r => r.ConteudoResposta, resposta.ConteudoResposta)
                .Set(r => r.Pontuacao, resposta.Pontuacao);

            await _respostas.UpdateOneAsync(filter, update);
        }

        public async Task DeleteAsync(int id)
        {
            var filter = Builders<Resposta>.Filter.Eq(r => r.IdResposta, id);
            await _respostas.DeleteOneAsync(filter);
        }
    }
}
