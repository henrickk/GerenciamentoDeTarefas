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
        public async Task<IEnumerable<TarefaDto>> ObterTodos()
        {
            return _mapper.Map<IEnumerable<TarefaDto>>(await _tarefaRepository.ObterTarefas());
        }

        [HttpGet]
        [Route("consultar-tarefa-por-id/{id:guid}")]
        public async Task<ActionResult<TarefaDto>> ObterPorId(Guid id)
        {
            var tarefasDto = await ObterPorId(id);

            if (tarefasDto == null) return NotFound();

            return CustomResponse(HttpStatusCode.OK, tarefasDto);
        }

        [HttpPost]
        [Route("adicionar-tarefa")]
        public async Task<ActionResult<TarefaDto>> Adicionar(CadastroTarefaDto cadastroTarefaDto)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var usuario = await _usarioRepository.ObterPorId(cadastroTarefaDto.UsuarioId);

            if (usuario == null)
            {
                NotificarErro("Usuário não encontrado!");
                return CustomResponse();
            }

            cadastroTarefaDto.NomeUsuario = usuario.Nome;

            await _tarefaService.Adicionar(_mapper.Map<Tarefa>(cadastroTarefaDto));

            return CustomResponse(HttpStatusCode.Created, cadastroTarefaDto);
        }

        [HttpPut]
        [Route("atualizar-tarefa/{id:guid}")]
        public async Task<ActionResult<TarefaDto>> Atualizar(Guid id, TarefaDto tarefaDto)
        {
            if (id != tarefaDto.Id)
            {
                NotificarErro("Os IDs não são iguais!");
                return CustomResponse();
            }

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var atualizarTarefaDto = await ObterTarefaProjeto(id);

            atualizarTarefaDto.Titulo = tarefaDto.Titulo;
            atualizarTarefaDto.Descricao = tarefaDto.Descricao;
            atualizarTarefaDto.Status = tarefaDto.Status;
            atualizarTarefaDto.Prioridade = tarefaDto.Prioridade;
            atualizarTarefaDto.DataConclusao = tarefaDto.DataConclusao;

            await _tarefaService.Atualizar(_mapper.Map<Tarefa>(atualizarTarefaDto));

            return CustomResponse(HttpStatusCode.NoContent);
        }

        [HttpDelete]
        [Route("excluir-tarefa/{id:guid}")]
        public async Task<ActionResult<TarefaDto>> Excluir(Guid id)
        {
            var tarefa = await ObterTarefaProjeto(id);

            if (tarefa != null) return NotFound();

            await _tarefaService.Remover(id);

            return CustomResponse(HttpStatusCode.NoContent);
        }

        private async Task<TarefaDto> ObterTarefaProjeto(Guid id)
        {
            return _mapper.Map<TarefaDto>(await _tarefaRepository.ObterTarefaProjetoUsuario(id));
        }
    }
}
