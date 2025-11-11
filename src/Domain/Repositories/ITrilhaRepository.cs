using Domain.Entities;

namespace Domain.Repositories
{
    public interface ITrilhaRepository
    {
        Task<List<Trilha>> GetAllAsync();
        Task<Trilha?> GetByIdAsync(int id);
        Task CreateAsync(Trilha trilha);
        Task UpdateAsync(int id, Trilha trilha);
        Task DeleteAsync(int id);
    }
}