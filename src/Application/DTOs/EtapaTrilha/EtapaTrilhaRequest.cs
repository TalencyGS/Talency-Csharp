namespace Application.Dtos.EtapaTrilha;

public class EtapaTrilhaRequest
{
    public int IdTrilha { get; set; }
    public string Titulo { get; set; }
    public string Descricao { get; set; }
    public int Ordem { get; set; }
}