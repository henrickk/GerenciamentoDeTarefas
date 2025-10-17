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

            CreateMap<UsuarioRegistroDto, Usuario>()
                .ForMember(dest => dest.SenhaHash, opt => opt.Ignore())
                .ForMember(dest => dest.DataCadastro, opt => opt.MapFrom(_ => DateTime.Now));

            CreateMap<UsuarioAtualizarDto, Usuario>()
                .ForMember(dest => dest.SenhaHash, opt => opt.Ignore())
                .ForMember(dest => dest.DataCadastro, opt => opt.Ignore());

            CreateMap<CadastroProjetoDto, Projeto>()
                .ForMember(dest => dest.DataConclusao, opt => opt.Ignore());

            CreateMap<Projeto, CadastroProjetoDto>()
                .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Nome));

            CreateMap<CadastroTarefaDto, Tarefa>()
                .ForMember(dest => dest.DataConclusao, opt => opt.Ignore());
        }
    }
}
