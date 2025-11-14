using Domain.Entities;

namespace Domain.Repositories
{
    public interface IEtapaTrilhaRepository
    {
        Task<List<EtapaTrilha>> GetAllAsync();
        Task<EtapaTrilha?> GetByIdAsync(int id);
        Task<Trilha?> GetTrilhaByIdAsync(int id);
        Task<List<EtapaTrilha>> GetByTrilhaIdAsync(int trilhaId);
        Task CreateAsync(EtapaTrilha etapaTrilha);
        Task UpdateAsync(int id, EtapaTrilha etapaTrilha);
        Task DeleteAsync(int id);
    }
}