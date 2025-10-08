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

        public TarefaController(ITarefaRepository tarefaRepository,
                                 ITarefaService tarefaService,
                                 IMapper mapper,
                                 INotificador notificador) : base(notificador) 
        {
            _tarefaRepository = tarefaRepository;
            _tarefaService = tarefaService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<TarefaDto>> ObterTodos()
        {
            return _mapper.Map<IEnumerable<TarefaDto>>(await _tarefaRepository.ObterTarefas());
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<TarefaDto>> ObterPorId(Guid id)
        {
            var tarefasDto = await ObterPorId(id);

            if (tarefasDto == null) return NotFound();

            return tarefasDto;
        }

        [HttpPost]
        public async Task<ActionResult<TarefaDto>> Adicionar(TarefaDto tarefaDto)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _tarefaService.Adicionar(_mapper.Map<Tarefa>(tarefaDto));

            return CustomResponse(HttpStatusCode.Created, tarefaDto);
        }

        [HttpPut("{id:guid}")]
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

        [HttpDelete("{id:guid}")]
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
