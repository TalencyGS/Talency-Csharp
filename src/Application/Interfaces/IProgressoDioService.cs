using Application.DTOs.ProgressoUsuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IProgressoUsuarioService
    {
        Task<ProgressoUsuarioResponse> GetProgressoUsuarioByIdAsync(int id);
        Task<List<ProgressoUsuarioResponse>> GetProgressoUsuarioByUsuarioIdAsync(int usuarioId);
        Task<ProgressoUsuarioResponse> CreateProgressoUsuarioAsync(ProgressoUsuarioRequest request);
        Task<ProgressoUsuarioResponse> UpdateProgressoUsuarioAsync(int id, ProgressoUsuarioRequest request);
        Task DeleteProgressoUsuarioAsync(int id);
    }
}
