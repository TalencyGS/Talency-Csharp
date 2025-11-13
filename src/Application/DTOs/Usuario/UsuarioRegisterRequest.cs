namespace Application.DTOs.Usuario
{
    public class UsuarioRegisterRequest
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string AreaInteresse { get; set; }
    }
}