using System.Collections.Generic;

namespace Domain.Entities;

public class Trilha
{
    public int IdTrilha { get; set; }
    public string NomeTrilha { get; set; }
    public string Descricao { get; set; }
    public string Area { get; set; }

    public ICollection<EtapaTrilha> Etapas { get; set; }
    public ICollection<ProgressoUsuario> ProgressoUsuarios { get; set; }
    public ICollection<Roadmap> Roadmaps { get; set; }

    public Trilha(string nomeTrilha, string descricao, string area)
    {
        NomeTrilha = nomeTrilha;
        Descricao = descricao;
        Area = area;
        Etapas = new List<EtapaTrilha>();
        ProgressoUsuarios = new List<ProgressoUsuario>();
        Roadmaps = new List<Roadmap>();
    }

    public static Trilha Create(string nomeTrilha, string descricao, string area)
    {
        return new Trilha(nomeTrilha, descricao, area);
    }
}