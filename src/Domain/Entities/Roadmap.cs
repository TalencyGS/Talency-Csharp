using System.Collections.Generic;

namespace Domain.Entities;
public class Roadmap
{
    public int IdRoadmap { get; set; }
    public int IdUsuario { get; set; }
    public Usuario Usuario { get; set; }
    public int IdTrilha { get; set; }
    public Trilha Trilha { get; set; }
    public string Status { get; set; }

    public ICollection<Meta> Metas { get; set; }

    public Roadmap(Usuario usuario, Trilha trilha, string status)
    {
        Usuario = usuario;
        Trilha = trilha;
        Status = status;
        Metas = new List<Meta>();
    }

    public static Roadmap Create(Usuario usuario, Trilha trilha, string status)
    {
        return new Roadmap(usuario, trilha, status);
    }
}