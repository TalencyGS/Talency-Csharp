using Domain.Entities;

namespace Domain.Repositories
{
    public interface IUsuarioHabilidadeRepository
    {
        Task<List<UsuarioHabilidade>> GetAllAsync();
        Task<UsuarioHabilidade?> GetByIdsAsync(int usuarioId, int habilidadeId);
        Task CreateAsync(UsuarioHabilidade usuarioHabilidade);
        Task UpdateAsync(int usuarioId, int habilidadeId, UsuarioHabilidade usuarioHabilidade);
        Task DeleteAsync(int usuarioId, int habilidadeId);
    }
}