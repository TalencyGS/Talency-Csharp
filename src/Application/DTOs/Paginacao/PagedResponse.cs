namespace Application.DTOs.Paginacao
{
    public class PagedResponse<T>
    {
        public IEnumerable<T> Items { get; set; }
        public int PaginaAtual { get; set; }
        public int TamanhoPagina { get; set; }
        public int TotalRegistros { get; set; }
        public int TotalPaginas { get; set; }
        public List<LinkDto> Links { get; set; }
    }
}
