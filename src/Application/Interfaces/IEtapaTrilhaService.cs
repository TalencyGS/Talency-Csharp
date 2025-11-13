using Application.Dtos.EtapaTrilha;
using Application.DTOs.EtapaTrilha;

namespace Application.Interfaces
{
    public interface IEtapaTrilhaService
    {
        Task<EtapaTrilhaResponse> GetEtapaTrilhaByIdAsync(int id);
        Task<List<EtapaTrilhaResponse>> GetEtapasByTrilhaIdAsync(int trilhaId);
        Task<EtapaTrilhaResponse> CreateEtapaTrilhaAsync(EtapaTrilhaRequest request);
        Task<EtapaTrilhaResponse> UpdateEtapaTrilhaAsync(int id, EtapaTrilhaRequest request);
        Task DeleteEtapaTrilhaAsync(int id);
    }
}
