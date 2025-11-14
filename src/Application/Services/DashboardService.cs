using Application.DTOs.Dashboard;
using Application.Interfaces;
using Domain.Repositories;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services
{
    public class DashboardService : IDashboardService
    {
        private readonly ITrilhaRepository _trilhaRepository;
        private readonly IMetaRepository _metaRepository;
        private readonly IProgressoUsuarioRepository _progressoUsuarioRepository;

        public DashboardService(
            ITrilhaRepository trilhaRepository,
            IMetaRepository metaRepository,
            IProgressoUsuarioRepository progressoUsuarioRepository)
        {
            _trilhaRepository = trilhaRepository;
            _metaRepository = metaRepository;
            _progressoUsuarioRepository = progressoUsuarioRepository;
        }

        public async Task<DashboardResumoResponse> GetDashboardResumoAsync(int usuarioId)
        {
            var progressoUsuario = await _progressoUsuarioRepository.GetByUsuarioIdAsync(usuarioId);
            if (progressoUsuario == null)
            {
                throw new KeyNotFoundException("Progresso do usuário não encontrado.");
            }

            var trilhasConcluidas = await _trilhaRepository.GetAllAsync();
            var trilhasConcluidasPorUsuario = trilhasConcluidas.Where(t => t.ProgressoUsuarios.Any(p => p.IdUsuario == usuarioId && p.Percentual == 100)).ToList();
            var totalTrilhasConcluidas = trilhasConcluidasPorUsuario.Count();

            var metasConcluidas = await _metaRepository.GetAllAsync();
            var metasConcluidasPorUsuario = metasConcluidas.Where(m => m.Roadmap.Usuario.IdUsuario == usuarioId && m.Status == "Concluída").ToList();
            var totalMetasConcluidas = metasConcluidasPorUsuario.Count();

            var habilidadesEvoluidasCount = progressoUsuario.Count(p => p.Percentual > 50);

            var trilhasProgresso = trilhasConcluidasPorUsuario.Select(trilha => new TrilhaProgressoResumo
            {
                IdTrilha = trilha.IdTrilha,
                NomeTrilha = trilha.NomeTrilha,
                Percentual = trilha.ProgressoUsuarios.FirstOrDefault(p => p.IdUsuario == usuarioId)?.Percentual ?? 0
            }).ToList();

            var dashboardResumo = new DashboardResumoResponse
            {
                TotalTrilhasConcluidas = totalTrilhasConcluidas,
                TotalMetasConcluidas = totalMetasConcluidas,
                HabilidadesEvoluidas = habilidadesEvoluidasCount,
                Trilhas = trilhasProgresso,
                Badges = new List<BadgeResumoResponse>()
            };

            return dashboardResumo;
        }
    }
}
