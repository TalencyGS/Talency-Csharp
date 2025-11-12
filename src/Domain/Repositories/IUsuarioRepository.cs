using Domain.Entities;

namespace Domain.Repositories
{
    public interface IUsuarioRepository
    {
        Task<List<Usuario>> GetAllAsync();
        Task<Usuario?> GetByIdAsync(int id);
        Task CreateAsync(Usuario usuario);
        Task UpdateAsync(int id, Usuario usuario);
        Task DeleteAsync(int id);
        Task <Usuario?> GetByEmailAsync(string email);
    }
}