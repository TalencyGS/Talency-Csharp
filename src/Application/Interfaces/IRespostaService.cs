using Application.DTOs.Resposta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IRespostaService
    {
        Task<RespostaResponse> GetRespostaByIdAsync(int id);
        Task<List<RespostaResponse>> GetRespostasByUsuarioIdAsync(int usuarioId);
        Task<RespostaResponse> CreateRespostaAsync(RespostaRequest request);
        Task<RespostaResponse> UpdateRespostaAsync(int id, RespostaRequest request);
        Task DeleteRespostaAsync(int id);
    }
}
