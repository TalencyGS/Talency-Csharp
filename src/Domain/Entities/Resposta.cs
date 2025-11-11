using System.Collections.Generic;

namespace Domain.Entities;
public class Resposta
{
    public int IdResposta { get; set; }
    public int IdTeste { get; set; }
    public Teste Teste { get; set; }
    public int IdUsuario { get; set; }
    public Usuario Usuario { get; set; }
    public string ConteudoResposta { get; set; }
    public double Pontuacao { get; set; }

    public Resposta(Teste teste, Usuario usuario, string conteudoResposta, double pontuacao)
    {
        Teste = teste;
        Usuario = usuario;
        ConteudoResposta = conteudoResposta;
        Pontuacao = pontuacao;
    }

    public static Resposta Create(Teste teste, Usuario usuario, string conteudoResposta, double pontuacao)
    {
        return new Resposta(teste, usuario, conteudoResposta, pontuacao);
    }
}