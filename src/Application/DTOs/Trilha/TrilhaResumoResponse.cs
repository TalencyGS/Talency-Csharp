using Application.DTOs.Paginacao;

namespace Application.DTOs.Trilha
{
    public class TrilhaResumoResponse
    {
        public int IdTrilha { get; set; }
        public string NomeTrilha { get; set; }
        public string Area { get; set; }
        public List<LinkDto> Links { get; set; }
    }
}
