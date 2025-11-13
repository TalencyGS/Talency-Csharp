
namespace Application.DTOs.Dashboard
{
    public class DashboardResumoResponse
    {
        public int TotalTrilhasConcluidas { get; set; }
        public int TotalMetasConcluidas { get; set; }
        public double HorasEstudoEstimadas { get; set; }
        public int HabilidadesEvoluidas { get; set; }

        public IEnumerable<TrilhaProgressoResumo> Trilhas { get; set; }
        public IEnumerable<BadgeResumo> Badges { get; set; }
    }

}
