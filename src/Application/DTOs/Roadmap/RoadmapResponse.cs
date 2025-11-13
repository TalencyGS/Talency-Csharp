using Application.DTOs.Paginacao;

namespace Application.DTOs.Roadmap
{
    public class RoadmapResponse
    {
        public int IdRoadmap { get; set; }
        public int IdUsuario { get; set; }
        public int IdTrilha { get; set; }
        public string Status { get; set; }

        public List<MetaResponse> Metas { get; set; }
        public List<LinkDto> Links { get; set; }
    }

}
