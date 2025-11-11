using System.Collections.Generic;

namespace Domain.Entities;
public class Teste
{
    public int IdTeste { get; set; }
    public int IdEtapa { get; set; }
    public EtapaTrilha Etapa { get; set; }
    public string Titulo { get; set; }

    public ICollection<Resposta> Respostas { get; set; }

    public Teste(EtapaTrilha etapa, string titulo)
    {
        Etapa = etapa;
        Titulo = titulo;
        Respostas = new List<Resposta>();
    }

    public static Teste Create(EtapaTrilha etapa, string titulo)
    {
        return new Teste(etapa, titulo);
    }
}