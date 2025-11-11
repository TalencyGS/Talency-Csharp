using Domain.Entities;

namespace Domain.Repositories
{
    public interface IProgressoUsuarioRepository
    {
        Task<List<ProgressoUsuario>> GetAllAsync();
        Task<ProgressoUsuario?> GetByIdAsync(int id);
        Task<List<ProgressoUsuario>> GetByUsuarioIdAsync(int usuarioId);
        Task CreateAsync(ProgressoUsuario progressoUsuario);
        Task UpdateAsync(int id, ProgressoUsuario progressoUsuario);
        Task DeleteAsync(int id);
    }
}
