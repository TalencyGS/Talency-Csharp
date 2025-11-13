using Application.DTOs.Trilha;

namespace Application.Interfaces
{
    public interface ITrilhaService
    {
        Task<List<TrilhaResponse>> GetAllAsync();
        Task<TrilhaDetalheResponse?> GetByIdAsync(int id);
        Task<TrilhaResponse> CreateAsync(TrilhaRequest request);
        Task<TrilhaResponse?> UpdateAsync(int id, TrilhaRequest request);
        Task<bool> DeleteAsync(int id);
    }
}
