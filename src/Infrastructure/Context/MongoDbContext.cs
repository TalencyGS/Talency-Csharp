using Domain.Entities;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Infrastructure.Context
{
    public class MongoDbContext
    {
        private readonly IMongoDatabase _database;

        public MongoDbContext(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("MongoDbConnection");
            var client = new MongoClient(connectionString);
            _database = client.GetDatabase("TalentRoad");
        }

        public IMongoCollection<Usuario> Usuarios => _database.GetCollection<Usuario>("Usuarios");
        public IMongoCollection<Habilidade> Habilidades => _database.GetCollection<Habilidade>("Habilidades");
        public IMongoCollection<UsuarioHabilidade> UsuarioHabilidades => _database.GetCollection<UsuarioHabilidade>("UsuarioHabilidades");
        public IMongoCollection<Trilha> Trilhas => _database.GetCollection<Trilha>("Trilhas");
        public IMongoCollection<EtapaTrilha> EtapasTrilha => _database.GetCollection<EtapaTrilha>("EtapasTrilha");
        public IMongoCollection<ProgressoUsuario> ProgressoUsuarios => _database.GetCollection<ProgressoUsuario>("ProgressoUsuarios");
        public IMongoCollection<Teste> Testes => _database.GetCollection<Teste>("Testes");
        public IMongoCollection<Resposta> Respostas => _database.GetCollection<Resposta>("Respostas");
        public IMongoCollection<Roadmap> Roadmaps => _database.GetCollection<Roadmap>("Roadmaps");
        public IMongoCollection<Meta> Metas => _database.GetCollection<Meta>("Metas");
        public IMongoCollection<Log> Logs => _database.GetCollection<Log>("Logs");
    }
}
