using Domain.Entities;

namespace Domain.Repositories
{
    public interface IHabilidadeRepository
    {
        Task<List<Habilidade>> GetAllAsync();
        Task<Habilidade?> GetByIdAsync(int id);
        Task CreateAsync(Habilidade habilidade);
        Task UpdateAsync(int id, Habilidade habilidade);
        Task DeleteAsync(int id);
    }
}