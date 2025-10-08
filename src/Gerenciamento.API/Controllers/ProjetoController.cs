using AutoMapper;
using Gerenciamento.API.DTO;
using Gerenciamento.Business.Interfaces;
using Gerenciamento.Business.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Gerenciamento.API.Controllers
{
    [Route("api/projeto")]
    public class ProjetoController : MainController
    {
        private readonly IProjetoRepository _projetoRepository;
        private readonly IProjetoService _projetoService;
        private readonly IMapper _mapper;

        public ProjetoController(IProjetoRepository projetoRepository,
                                 IProjetoService projetoService,
                                 IMapper mapper,
                                 INotificador notificador) : base(notificador)
        {
            _projetoRepository = projetoRepository;
            _projetoService = projetoService;
            _mapper = mapper;
        }

        [HttpGet] 
        public async Task<IEnumerable<ProjetoDto>> ObterTodos()
        {
            return _mapper.Map<IEnumerable<ProjetoDto>>(await _projetoRepository.ObterProjetos());
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<ProjetoDto>> ObterPorId(Guid id)
        {
            var produtoDto = await ObterProjeto(id);

            if (produtoDto == null) return NotFound();

            return produtoDto;
        }

        [HttpPost]
        public async Task<ActionResult<ProjetoDto>> Adicionar(ProjetoDto projetoDto)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _projetoService.Adicionar(_mapper.Map<Projeto>(projetoDto));

            return CustomResponse(HttpStatusCode.Created, projetoDto);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<ProjetoDto>> Atualizar(Guid id, ProjetoDto projetoDto)
        {
            if (id != projetoDto.Id)
            {
                NotificarErro("Os IDs não são iguais!");
                return CustomResponse(HttpStatusCode.NoContent);
            }

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var atualizacaoProjeto = await ObterProjeto(id);

            atualizacaoProjeto.UsuarioId = projetoDto.UsuarioId;
            atualizacaoProjeto.Nome = projetoDto.Nome;
            atualizacaoProjeto.Descricao = projetoDto.Descricao;
            atualizacaoProjeto.DataConclusao = projetoDto.DataConclusao;

            await _projetoService.Atualizar(_mapper.Map<Projeto>(atualizacaoProjeto));

            return CustomResponse();
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<ProjetoDto>> Excluir(Guid id)
        {
            var projeto = await ObterProjeto(id);

            if (projeto != null) return NotFound(); 

            await _projetoService.Remover(id);

            return CustomResponse(HttpStatusCode.NoContent);
        }

        private async Task<ProjetoDto> ObterProjeto(Guid id)
        {
            return _mapper.Map<ProjetoDto>(await _projetoRepository.ObterProjetoUsuario(id));
        }
    }
}