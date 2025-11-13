
namespace Application.DTOs.ProgressoUsuario
{
    public class ProgressoUsuarioRequest
    {
        public int IdUsuario { get; set; }
        public int IdTrilha { get; set; }
        public double Percentual { get; set; }
    }
}
