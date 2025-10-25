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

            // Tarefa
            CreateMap<Tarefa, TarefaDto>()
                .ForMember(dest => dest.NomeUsuario,
                    opt => opt.MapFrom(src => src.Usuario != null ? src.Usuario.Nome : string.Empty))
                .ReverseMap();

            CreateMap<CadastroTarefaDto, Tarefa>()
                .ForMember(dest => dest.DataConclusao, opt => opt.Ignore())
                .ForMember(dest => dest.NomeUsuario, opt => opt.Ignore());

            // Projeto
            CreateMap<Projeto, ProjetoDto>()
                .ForMember(dest => dest.NomeProjeto, opt => opt.MapFrom(src => src.Nome))
                .ForMember(dest => dest.NomeUsuario, opt => opt.MapFrom(src => src.Usuario != null ? src.Usuario.Nome : string.Empty))
                .ForMember(dest => dest.Tarefas, opt => opt.MapFrom(src => src.Tarefas))
                .ReverseMap();

            CreateMap<CadastroProjetoDto, Projeto>()
                .ForMember(dest => dest.DataConclusao, opt => opt.Ignore());
        }

        //    // Map from domain Projeto to ProjetoDto (leitura)
        //    CreateMap<Projeto, ProjetoDto>()
        //        .ForMember(dest => dest.NomeProjeto, opt => opt.MapFrom(src => src.Nome))
        //        .ForMember(dest => dest.NomeUsuario, opt => opt.MapFrom(src => src.Usuario != null ? src.Usuario.Nome : null))
        //        .ForMember(dest => dest.Tarefas, opt => opt.MapFrom(src => src.Tarefas));

        //    // Map from domain Tarefa to TarefaDto (leitura)
        //    CreateMap<Tarefa, TarefaDto>()
        //        .ForMember(dest => dest.NomeUsuario, opt => opt.MapFrom(src => src.Usuario != null ? src.Usuario.Nome : null));

        //    // Map para criação de Projeto (DTO -> domain)
        //    CreateMap<CadastroProjetoDto, Projeto>()
        //        .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Nome))
        //        .ForMember(dest => dest.DataInicio, opt => opt.MapFrom(src => src.DataInicio))
        //        .ForMember(dest => dest.DataFim, opt => opt.MapFrom(src => src.DataFim))
        //        .ForMember(dest => dest.Descricao, opt => opt.MapFrom(src => src.Descricao))
        //        .ForMember(dest => dest.UsuarioId, opt => opt.MapFrom(src => src.UsuarioId));

        //    // Map para atualização/uso interno (ProjetoDto -> Projeto)
        //    CreateMap<ProjetoDto, Projeto>()
        //        .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.NomeProjeto))
        //        .ForMember(dest => dest.Descricao, opt => opt.MapFrom(src => src.Descricao))
        //        .ForMember(dest => dest.DataInicio, opt => opt.MapFrom(src => src.DataInicio))
        //        .ForMember(dest => dest.DataFim, opt => opt.MapFrom(src => src.DataFim))
        //        .ForMember(dest => dest.DataConclusao, opt => opt.MapFrom(src => src.DataConclusao))
        //        .ForMember(dest => dest.UsuarioId, opt => opt.MapFrom(src => src.UsuarioId));

        //    // Map opcional para TarefaDto -> Tarefa (se necessário)
        //    CreateMap<TarefaDto, Tarefa>()
        //        .ForMember(dest => dest.Titulo, opt => opt.MapFrom(src => src.Titulo))
        //        .ForMember(dest => dest.Descricao, opt => opt.MapFrom(src => src.Descricao))
        //        .ForMember(dest => dest.UsuarioId, opt => opt.MapFrom(src => src.UsuarioId))
        //        .ForMember(dest => dest.DataConclusao, opt => opt.MapFrom(src => src.DataConclusao));
        //}
        //{
        //    CreateMap<Usuario, UsuarioDto>().ReverseMap();
        //    CreateMap<Projeto, ProjetoDto>().ReverseMap();
        //    CreateMap<TarefaDto, Tarefa>().ReverseMap();

        //    CreateMap<Tarefa, TarefaDto>()
        //        .ForMember(dest => dest.NomeUsuario, opt => opt.MapFrom(src => src.Usuario.Nome));

        //    CreateMap<UsuarioRegistroDto, Usuario>()
        //        .ForMember(dest => dest.SenhaHash, opt => opt.Ignore())
        //        .ForMember(dest => dest.DataCadastro, opt => opt.MapFrom(_ => DateTime.Now));

        //    CreateMap<UsuarioAtualizarDto, Usuario>()
        //        .ForMember(dest => dest.SenhaHash, opt => opt.Ignore())
        //        .ForMember(dest => dest.DataCadastro, opt => opt.Ignore());

        //    CreateMap<CadastroProjetoDto, Projeto>()
        //        .ForMember(dest => dest.DataConclusao, opt => opt.Ignore());

        //    CreateMap<Projeto, CadastroProjetoDto>()
        //        .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Nome));

        //    CreateMap<CadastroTarefaDto, Tarefa>()
        //        .ForMember(dest => dest.DataConclusao, opt => opt.Ignore());

        //    CreateMap<Projeto, ProjetoDto>()
        //    .ForMember(dest => dest.NomeProjeto, opt => opt.MapFrom(src => src.Nome))
        //    .ForMember(dest => dest.NomeUsuario, opt => opt.MapFrom(src => src.Usuario != null ? src.Usuario.Nome : null));
        //}
    }
}
