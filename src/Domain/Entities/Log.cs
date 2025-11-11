using System.Collections.Generic;

namespace Domain.Entities;
public class Log
{
    public int IdLog { get; set; }
    public string Tabela { get; set; }
    public string Acao { get; set; }
    public int IdRegistro { get; set; }
    public DateTime DataAcao { get; set; }

    public Log(string tabela, string acao, int idRegistro)
    {
        Tabela = tabela;
        Acao = acao;
        IdRegistro = idRegistro;
        DataAcao = DateTime.Now;
    }

    public static Log Create(string tabela, string acao, int idRegistro)
    {
        return new Log(tabela, acao, idRegistro);
    }
}
