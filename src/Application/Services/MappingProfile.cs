using Application.DTOs.Dashboard;
using Application.DTOs.Habilidade;
using Application.DTOs.Meta;
using Application.DTOs.ProgressoUsuario;
using Application.DTOs.Resposta;
using Application.DTOs.Roadmap;
using Application.DTOs.Teste;
using Application.DTOs.Trilha;
using Application.DTOs.Usuario;
using Application.DTOs.UsuarioHabilidade;
using AutoMapper;
using Domain.Entities;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Application.Services
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Trilha, TrilhaResponse>();
            CreateMap<TrilhaRequest, Trilha>();

            CreateMap<Meta, MetaResponse>();
            CreateMap<MetaRequest, Meta>();

            CreateMap<ProgressoUsuario, ProgressoUsuarioResponse>();
            CreateMap<ProgressoUsuarioRequest, ProgressoUsuario>();

            CreateMap<Resposta, RespostaResponse>();
            CreateMap<RespostaRequest, Resposta>();

            CreateMap<Roadmap, RoadmapResponse>();
            CreateMap<RoadmapCreateRequest, Roadmap>();

            CreateMap<Teste, TesteResponse>();

            CreateMap<Habilidade, HabilidadeResponse>();
            CreateMap<HabilidadeRequest, Habilidade>();

            CreateMap<UsuarioHabilidade, UsuarioHabilidadeResponse>();
            CreateMap<UsuarioHabilidadeRequest, UsuarioHabilidade>();

            CreateMap<Usuario, UsuarioResponse>();
            CreateMap<UsuarioLoginRequest, Usuario>();
            CreateMap<UsuarioRegisterRequest, Usuario>();
            CreateMap<UsuarioUpdateRequest, Usuario>();

            CreateMap<DashboardResumoResponse, DashboardResumoResponse>();
        }
    }
}
