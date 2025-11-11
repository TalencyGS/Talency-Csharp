using System.Collections.Generic;

namespace Domain.Entities;

public class UsuarioHabilidade
{
    public int IdUsuario { get; set; }
    public Usuario Usuario { get; set; }
    public int IdHabilidade { get; set; }
    public Habilidade Habilidade { get; set; }
    public string Nivel { get; set; }

    public UsuarioHabilidade(Usuario usuario, Habilidade habilidade, string nivel)
    {
        Usuario = usuario;
        Habilidade = habilidade;
        Nivel = nivel;
    }

    public static UsuarioHabilidade Create(Usuario usuario, Habilidade habilidade, string nivel)
    {
        return new UsuarioHabilidade(usuario, habilidade, nivel);
    }
}