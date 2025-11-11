using System.Collections.Generic;
    
namespace Domain.Entities;
public class Habilidade
{
    public int IdHabilidade { get; set; }
    public string NomeHabilidade { get; set; }
    public string Tipo { get; set; }

    public ICollection<UsuarioHabilidade> UsuarioHabilidades { get; set; }

    public Habilidade(string nomeHabilidade, string tipo)
    {
        NomeHabilidade = nomeHabilidade;
        Tipo = tipo;
        UsuarioHabilidades = new List<UsuarioHabilidade>();
    }

    public static Habilidade Create(string nomeHabilidade, string tipo)
    {
        return new Habilidade(nomeHabilidade, tipo);
    }
}