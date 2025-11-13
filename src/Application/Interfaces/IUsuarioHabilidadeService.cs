using Application.DTOs.UsuarioHabilidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IUsuarioHabilidadeService
    {
        Task<UsuarioHabilidadeResponse> GetUsuarioHabilidadeByIdsAsync(int usuarioId, int habilidadeId);
        Task<List<UsuarioHabilidadeResponse>> GetAllUsuarioHabilidadesAsync();
        Task<UsuarioHabilidadeResponse> CreateUsuarioHabilidadeAsync(UsuarioHabilidadeRequest request);
        Task<UsuarioHabilidadeResponse> UpdateUsuarioHabilidadeAsync(int usuarioId, int habilidadeId, UsuarioHabilidadeRequest request);
        Task DeleteUsuarioHabilidadeAsync(int usuarioId, int habilidadeId);
    }
}
