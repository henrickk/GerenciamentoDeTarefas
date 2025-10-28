using AutoMapper;
using Gerenciamento.API.DTO;
using Gerenciamento.Business.Models;

namespace Gerenciamento.API.Configurations
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {
            // Usuário
            CreateMap<Usuario, UsuarioDto>().ReverseMap();

            CreateMap<UsuarioRegistroDto, Usuario>()
                .ForMember(dest => dest.SenhaHash, opt => opt.Ignore())
                .ForMember(dest => dest.DataCadastro, opt => opt.MapFrom(_ => DateTime.Now));

            // Tarefa (listagem geral)
            CreateMap<Tarefa, TarefaDto>()
                .ForMember(dest => dest.NomeUsuario,
                    opt => opt.MapFrom(src => src.Usuario != null ? src.Usuario.Nome : string.Empty))
                .ReverseMap();

            // Cadastro de tarefa
            CreateMap<TarefaCadastroDto, Tarefa>()
                .ForMember(dest => dest.DataConclusao, opt => opt.Ignore())
                .ForMember(dest => dest.NomeUsuario, opt => opt.Ignore());

            // Retorno detalhado de tarefa (por ID)
            CreateMap<Tarefa, TarefaRetornoDto>()
                .ForMember(dest => dest.NomeUsuario,
                    opt => opt.MapFrom(src => src.Usuario != null ? src.Usuario.Nome : string.Empty))
                .ForMember(dest => dest.NomeProjeto,
                    opt => opt.MapFrom(src => src.Projeto != null ? src.Projeto.Nome : string.Empty))
                .ReverseMap();

            // Projeto
            CreateMap<Projeto, ProjetoDto>()
                .ForMember(dest => dest.NomeProjeto, opt => opt.MapFrom(src => src.Nome))
                .ForMember(dest => dest.NomeUsuario,
                    opt => opt.MapFrom(src => src.Usuario != null ? src.Usuario.Nome : string.Empty))
                .ForMember(dest => dest.Tarefas, opt => opt.MapFrom(src => src.Tarefas))
                .ReverseMap();

            // Cadastro de projeto
            CreateMap<ProjetoCadastroDto, Projeto>()
                .ForMember(dest => dest.DataConclusao, opt => opt.Ignore());
        }
    }
}