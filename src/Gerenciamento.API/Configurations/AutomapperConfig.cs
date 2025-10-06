using AutoMapper;
using Gerenciamento.API.DTO;
using Gerenciamento.Business.Models;

namespace Gerenciamento.API.Configurations
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig() 
        {
            CreateMap<Usuario, UsuarioDto>().ReverseMap();
            CreateMap<Projeto, ProjetoDto>().ReverseMap();
            CreateMap<TarefaDto, Tarefa>().ReverseMap();

            CreateMap<Tarefa, TarefaDto>()
                .ForMember(dest => dest.NomeUsuario, opt => opt.MapFrom(src => src.Usuario.Nome));
        }
    }
}
