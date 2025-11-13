using Application.DTOs.Trilha;

public interface ITrilhaService
{
    Task<TrilhaResponse> GetTrilhaByIdAsync(int id);
    Task<List<TrilhaResponse>> GetAllTrilhasAsync();
    Task<TrilhaResponse> CreateTrilhaAsync(TrilhaRequest request);
    Task<TrilhaResponse> UpdateTrilhaAsync(int id, TrilhaRequest request);
    Task DeleteTrilhaAsync(int id);
}