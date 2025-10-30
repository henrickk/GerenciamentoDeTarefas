using AutoMapper;
using Gerenciamento.API.DTO;
using Gerenciamento.Business.Interfaces;
using Gerenciamento.Business.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Gerenciamento.API.Controllers
{
    [Route("api/tarefa")]
    public class TarefaController : MainController
    {
        private readonly ITarefaRepository _tarefaRepository;
        private readonly ITarefaService _tarefaService;
        private readonly IMapper _mapper;
        private readonly IUsuarioRepository _usarioRepository;
        private readonly IUsuarioService _usuarioService;

        public TarefaController(ITarefaRepository tarefaRepository,
                                 ITarefaService tarefaService,
                                 IMapper mapper,
                                 IUsuarioRepository usarioRepository,
                                 IUsuarioService usuarioService,
                                 INotificador notificador) : base(notificador)
        {
            _tarefaRepository = tarefaRepository;
            _tarefaService = tarefaService;
            _mapper = mapper;
            _usarioRepository = usarioRepository;
            _usuarioService = usuarioService;
        }

        [HttpGet]
        [Route("consultar-tarefa")]
        public async Task<IEnumerable<TarefaRetornoDto>> ObterTodos()
        {
            return _mapper.Map<IEnumerable<TarefaRetornoDto>>(await _tarefaRepository.ObterTarefas());
        }

        [HttpGet]
        [Route("consultar-tarefa-por-id/{id:guid}")]
        public async Task<ActionResult<TarefaRetornoDto>> ObterPorId(Guid id)
        {
            var tarefas = await _tarefaRepository.ObterPorId(id);

            if (tarefas == null) return NotFound();

            var tarefasDto = _mapper.Map<TarefaRetornoDto>(tarefas);

            return CustomResponse(HttpStatusCode.OK, tarefasDto);
        }

        [HttpPost]
        [Route("adicionar-tarefa")]
        public async Task<ActionResult<TarefaDto>> Adicionar(TarefaCadastroDto tarefaCadastroDto)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var usuario = await _usarioRepository.ObterPorId(tarefaCadastroDto.UsuarioId);

            if (usuario == null)
            {
                NotificarErro("Usuário não encontrado!");
                return CustomResponse();
            }

            tarefaCadastroDto.NomeUsuario = usuario.Nome;

            await _tarefaService.Adicionar(_mapper.Map<Tarefa>(tarefaCadastroDto));

            return CustomResponse(HttpStatusCode.Created, tarefaCadastroDto);
        }


        [HttpPut]
        [Route("atualizar-tarefa/{id:guid}")]
        public async Task<ActionResult<TarefaAtualizarDto>> Atualizar(Guid id, TarefaAtualizarDto tarefaAtualizarDto)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var tarefaDb = await _tarefaRepository.ObterPorId(id);
            if (tarefaDb == null) return NotFound();

            _mapper.Map(tarefaAtualizarDto, tarefaDb);

            tarefaDb.Id = id;

            await _tarefaService.Atualizar(tarefaDb);
            return CustomResponse(HttpStatusCode.NoContent);
        }

        [HttpDelete]
        [Route("excluir-tarefa/{id:guid}")]
        public async Task<ActionResult<TarefaDto>> Excluir(Guid id)
        {
            var tarefa = await ObterTarefaProjeto(id);

            if (tarefa == null) return NotFound();

            await _tarefaService.Remover(id);

            return CustomResponse(HttpStatusCode.NoContent);
        }

        private async Task<TarefaDto> ObterTarefaProjeto(Guid id)
        {
            return _mapper.Map<TarefaDto>(await _tarefaRepository.ObterTarefaProjetoUsuario(id));
        }
    }
}
