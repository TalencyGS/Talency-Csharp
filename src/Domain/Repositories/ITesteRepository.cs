using Domain.Entities;

namespace Domain.Repositories
{
    public interface ITesteRepository
    {
        Task<List<Teste>> GetAllAsync();
        Task<Teste?> GetByIdAsync(int id);
        Task<List<Teste>> GetByEtapaIdAsync(int etapaId);
        Task CreateAsync(Teste teste);
        Task UpdateAsync(int id, Teste teste);
        Task DeleteAsync(int id);
    }
}
