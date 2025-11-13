using Application.DTOs.Paginacao;

namespace Application.DTOs.Trilha
{
    public class TrilhaDetalheResponse
    {
        public int IdTrilha { get; set; }
        public string NomeTrilha { get; set; }
        public string Descricao { get; set; }
        public string Area { get; set; }

        public List<EtapaResumoResponse> Etapas { get; set; }
        public List<LinkDto> Links { get; set; }
    }
}
