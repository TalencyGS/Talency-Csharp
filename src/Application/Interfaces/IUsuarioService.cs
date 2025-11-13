
using Application.DTOs.Usuario;

namespace Application.Interfaces
{
    public interface IUsuarioService
    {
        Task<List<UsuarioResponse>> GetAllAsync();
        Task<UsuarioResponse?> GetByIdAsync(int id);
        Task<UsuarioResponse> CreateAsync(UsuarioRegisterRequest request);
        Task<UsuarioResponse?> UpdateAsync(int id, UsuarioUpdateRequest request);
        Task<bool> DeleteAsync(int id);
        Task<UsuarioResponse?> GetByEmailAsync(string email);
    }
}
