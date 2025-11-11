using Domain.Entities;

namespace Domain.Repositories
{
    public interface ILogRepository
    {
        Task<List<Log>> GetAllAsync();
        Task<Log?> GetByIdAsync(int id);
        Task<List<Log>> GetByTabelaAsync(string tabela);
        Task CreateAsync(Log log);
        Task DeleteAsync(int id);
    }
}
