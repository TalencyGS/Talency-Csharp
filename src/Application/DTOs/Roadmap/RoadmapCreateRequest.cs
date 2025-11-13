using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Roadmap
{
    public class RoadmapCreateRequest
    {
        public int IdUsuario { get; set; }
        public int IdTrilha { get; set; }
        public string Status { get; set; }
    }
}
