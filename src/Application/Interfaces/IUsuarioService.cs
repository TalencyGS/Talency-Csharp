using Application.DTOs.Usuario;

namespace Application.Services {
    public interface IUsuarioService {
        Task<UsuarioAuthResponse> LoginAsync(UsuarioLoginRequest request);
        Task<UsuarioAuthResponse> RegisterAsync(UsuarioRegisterRequest request);
        Task<UsuarioResponse> GetUsuarioByIdAsync(int id);
        Task<UsuarioResponse> UpdateUsuarioAsync(int id, UsuarioUpdateRequest request);
        Task DeleteUsuarioAsync(int id);
    }
};