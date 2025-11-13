using Application.DTOs.Habilidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IHabilidadeService
    {
        Task<HabilidadeResponse> GetHabilidadeByIdAsync(int id);
        Task<List<HabilidadeResponse>> GetAllHabilidadesAsync();
        Task<HabilidadeResponse> CreateHabilidadeAsync(HabilidadeRequest request);
        Task<HabilidadeResponse> UpdateHabilidadeAsync(int id, HabilidadeRequest request);
        Task DeleteHabilidadeAsync(int id);
    }
}
