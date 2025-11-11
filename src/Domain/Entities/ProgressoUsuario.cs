using System.Collections.Generic;

namespace Domain.Entities;
public class ProgressoUsuario
{
    public int IdProgresso { get; set; }
    public int IdUsuario { get; set; }
    public Usuario Usuario { get; set; }
    public int IdTrilha { get; set; }
    public Trilha Trilha { get; set; }
    public double Percentual { get; set; }

    public ProgressoUsuario(Usuario usuario, Trilha trilha, double percentual)
    {
        Usuario = usuario;
        Trilha = trilha;
        Percentual = percentual;
    }

    public static ProgressoUsuario Create(Usuario usuario, Trilha trilha, double percentual)
    {
        return new ProgressoUsuario(usuario, trilha, percentual);
    }
}