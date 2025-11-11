using System.Collections.Generic;

namespace Domain.Entities;
public class Usuario
{
    public int IdUsuario { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public string SenhaHash { get; set; }
    public string AreaInteresse { get; set; }
    public DateTime DataCadastro { get; set; }

    public ICollection<UsuarioHabilidade> UsuarioHabilidades { get; set; }
    public ICollection<ProgressoUsuario> ProgressoUsuarios { get; set; }
    public ICollection<Roadmap> Roadmaps { get; set; }
    public ICollection<Resposta> Respostas { get; set; }

    public Usuario(string nome, string email, string senhaHash, string areaInteresse)
    {
        Nome = nome;
        Email = email;
        SenhaHash = senhaHash;
        AreaInteresse = areaInteresse;
        DataCadastro = DateTime.Now;
        UsuarioHabilidades = new List<UsuarioHabilidade>();
        ProgressoUsuarios = new List<ProgressoUsuario>();
        Roadmaps = new List<Roadmap>();
        Respostas = new List<Resposta>();
    }

    public static Usuario Create(string nome, string email, string senhaHash, string areaInteresse)
    {
        return new Usuario(nome, email, senhaHash, areaInteresse);
    }
}