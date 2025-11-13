using Application.DTOs.Roadmap;
using Application.DTOs.Trilha;
using Domain.Entities;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IRoadmapService
    {
        Task<RoadmapResponse> GetRoadmapByIdAsync(int id);
        Task<List<RoadmapResponse>> GetRoadmapsByUsuarioIdAsync(int usuarioId);
        Task<RoadmapResponse> CreateRoadmapAsync(RoadmapCreateRequest request);
        Task<RoadmapResponse> UpdateRoadmapAsync(int id, RoadmapCreateRequest request);
        Task DeleteRoadmapAsync(int id);
    }
}
