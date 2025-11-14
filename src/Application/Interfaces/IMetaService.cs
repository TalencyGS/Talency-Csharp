using Application.DTOs.Meta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IMetaService
    {
        Task<MetaResponse> GetMetaByIdAsync(int id);
        Task<List<MetaResponse>> GetMetasByRoadmapIdAsync(int roadmapId);
        Task<MetaResponse> CreateMetaAsync(MetaRequest request);
        Task<MetaResponse> UpdateMetaAsync(int id, MetaRequest request);
        Task DeleteMetaAsync(int id);
    }
}
