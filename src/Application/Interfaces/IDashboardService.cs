using Application.DTOs.Dashboard;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IDashboardService
    {
        Task<DashboardResumoResponse> GetDashboardResumoAsync(int usuarioId);
    }
}
