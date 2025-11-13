using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Trilha
{
    public class TrilhaResponse
    {
        public int IdTrilha { get; set; }
        public string NomeTrilha { get; set; }
        public string Descricao { get; set; }
        public string Area { get; set; }
    }
}
