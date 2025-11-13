
namespace Application.DTOs.UsuarioHabilidade
{
    public class UsuarioHabilidadeResponse
    {
        public int IdUsuario { get; set; }
        public int IdHabilidade { get; set; }
        public string NomeHabilidade { get; set; }
        public string Tipo { get; set; }
        public string Nivel { get; set; }
    }
}
