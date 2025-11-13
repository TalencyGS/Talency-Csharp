namespace Application.DTOs.Resposta
{
    public class RespostaResponse
    {
        public int IdResposta { get; set; }
        public int IdTeste { get; set; }
        public int IdUsuario { get; set; }
        public string ConteudoResposta { get; set; }
        public double Pontuacao { get; set; }
    }
}
