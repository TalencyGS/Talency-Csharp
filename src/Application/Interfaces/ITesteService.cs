using Application.DTOs.Teste;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ITesteService
    {
        Task<TesteResponse> GetTesteByIdAsync(int id);
        Task<List<TesteResponse>> GetTestesByEtapaIdAsync(int etapaId);
    }
}
