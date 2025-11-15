using Domain.Entities;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using MongoDB.Bson.Serialization;

namespace Infrastructure.Context
{
    public class MongoDbContext
    {
        private readonly IMongoDatabase _database;

        static MongoDbContext()
        {
            if (!BsonClassMap.IsClassMapRegistered(typeof(Usuario)))
            {
                BsonClassMap.RegisterClassMap<Usuario>(cm =>
                {
                    cm.AutoMap();
                    cm.SetIgnoreExtraElements(true);
                });
            }
        }

        public MongoDbContext(IConfiguration configuration)
        {
            var connectionString = configuration["MongoDb:ConnectionString"];
            var databaseName = configuration["MongoDb:Database"];

            if (string.IsNullOrWhiteSpace(connectionString))
                throw new ArgumentNullException(nameof(connectionString), "MongoDb:ConnectionString não está configurada.");

            if (string.IsNullOrWhiteSpace(databaseName))
                throw new ArgumentNullException(nameof(databaseName), "MongoDb:Database não está configurada.");

            var client = new MongoClient(connectionString);
            _database = client.GetDatabase(databaseName);
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
