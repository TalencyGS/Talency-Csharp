using Domain.Entities;

namespace Domain.Repositories
{
    public interface IRespostaRepository
    {
        Task<List<Resposta>> GetAllAsync();
        Task<Resposta?> GetByIdAsync(int id);
        Task<List<Resposta>> GetByUsuarioIdAsync(int usuarioId);
        Task CreateAsync(Resposta resposta);
        Task UpdateAsync(int id, Resposta resposta);
        Task DeleteAsync(int id);
    }
}
