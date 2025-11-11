using System.Collections.Generic;
using static System.Net.Mime.MediaTypeNames;

namespace Domain.Entities;

public class EtapaTrilha
{
    public int IdEtapa { get; set; }
    public int IdTrilha { get; set; }
    public Trilha Trilha { get; set; }
    public string Titulo { get; set; }
    public string Descricao { get; set; }
    public int Ordem { get; set; }

    public ICollection<Teste> Testes { get; set; }

    public EtapaTrilha(Trilha trilha, string titulo, string descricao, int ordem)
    {
        Trilha = trilha;
        Titulo = titulo;
        Descricao = descricao;
        Ordem = ordem;
        Testes = new List<Teste>();
    }

    public static EtapaTrilha Create(Trilha trilha, string titulo, string descricao, int ordem)
    {
        return new EtapaTrilha(trilha, titulo, descricao, ordem);
    }
}