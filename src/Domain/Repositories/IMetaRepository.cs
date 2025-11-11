using Domain.Entities;

namespace Domain.Repositories
{
    public interface IMetaRepository
    {
        Task<List<Meta>> GetAllAsync();
        Task<Meta?> GetByIdAsync(int id);
        Task<List<Meta>> GetByRoadmapIdAsync(int roadmapId);
        Task CreateAsync(Meta meta);
        Task UpdateAsync(int id, Meta meta);
        Task DeleteAsync(int id);
    }
}
