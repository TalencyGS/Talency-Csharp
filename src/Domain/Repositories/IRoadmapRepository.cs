using Domain.Entities;

namespace Domain.Repositories
{
    public interface IRoadmapRepository
    {
        Task<List<Roadmap>> GetAllAsync();
        Task<Roadmap?> GetByIdAsync(int id);
        Task<List<Roadmap>> GetByUsuarioIdAsync(int usuarioId);
        Task CreateAsync(Roadmap roadmap);
        Task UpdateAsync(int id, Roadmap roadmap);
        Task DeleteAsync(int id);
    }
}
