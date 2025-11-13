using Application.DTOs.EtapaTrilha;

namespace Application.Interfaces
{
    public interface IEtapaTrilhaService
    {
        Task<List<EtapaTrilhaResponse>> GetAllAsync();
        Task<EtapaTrilhaResponse?> GetByIdAsync(int id);
        Task<List<EtapaTrilhaResponse>> GetByTrilhaIdAsync(int trilhaId);
        Task<EtapaTrilhaResponse> CreateAsync(EtapaTrilhaRequest request);
        Task<EtapaTrilhaResponse?> UpdateAsync(int id, EtapaTrilhaRequest request);
        Task<bool> DeleteAsync(int id);
    }
}
