using System.Collections.Generic;

namespace Domain.Entities;
public class Meta
{
    public int IdMeta { get; set; }
    public int IdRoadmap { get; set; }
    public Roadmap Roadmap { get; set; }
    public string Descricao { get; set; }
    public string Status { get; set; }

    public Meta(Roadmap roadmap, string descricao, string status)
    {
        Roadmap = roadmap;
        Descricao = descricao;
        Status = status;
    }

    public static Meta Create(Roadmap roadmap, string descricao, string status)
    {
        return new Meta(roadmap, descricao, status);
    }
}