using AutoMapper;
using Gerenciamento.API.DTO;
using Gerenciamento.Business.Interfaces;
using Gerenciamento.Business.Models;
using Gerenciamento.Business.Services;
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
        [Route("consultar-projeto")]
        public async Task<ActionResult<IEnumerable<ProjetoDto>>> ObterTodos()
        {
            var projetosDto = _mapper.Map<IEnumerable<ProjetoDto>>(await _projetoRepository.ObterProjetos());

            return Ok(projetosDto);
        }

        [HttpGet]
        [Route("consultar-projeto/{id:guid}")]
        public async Task<ActionResult<ProjetoDto>> ObterPorId(Guid id)
        {
            var projetoDto = await _projetoRepository.ObterPorId(id);

            if (projetoDto == null) return NotFound();

            return CustomResponse(HttpStatusCode.OK, projetoDto);
        }

        [HttpPost]
        [Route("cadastrar-projeto")]
        public async Task<ActionResult<ProjetoDto>> Adicionar(ProjetoCadastroDto projetoCadastroDto)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _projetoService.Adicionar(_mapper.Map<Projeto>(projetoCadastroDto));

            return CustomResponse(HttpStatusCode.Created, projetoCadastroDto);
        }

        [HttpPut]
        [Route("atualizar-projeto/{id:guid}")]
        public async Task<ActionResult<ProjetoAtualizarDto>> Atualizar(Guid id, ProjetoAtualizarDto projetoAtualizarDto)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var atualizacaoProjeto = await ObterProjeto(id);
            if (atualizacaoProjeto == null)
            {
                NotificarErro("Projeto não encontrado!");
                return CustomResponse();
            }
            atualizacaoProjeto.UsuarioId = projetoAtualizarDto.UsuarioId;
            atualizacaoProjeto.NomeProjeto = projetoAtualizarDto.NomeProjeto;
            atualizacaoProjeto.Descricao = projetoAtualizarDto.Descricao;
            atualizacaoProjeto.DataFim = projetoAtualizarDto.DataFim;
            atualizacaoProjeto.DataConclusao = projetoAtualizarDto.DataConclusao;

            await _projetoService.Atualizar(_mapper.Map<Projeto>(atualizacaoProjeto));

            return CustomResponse(HttpStatusCode.NoContent);
        }

        [HttpPut]
        [Route("atualizar-data-conclusao/{id:guid}")]
        public async Task<ActionResult<ProjetoAtualizarDataConclusaoDto>> AtualizarDataConclusao(Guid id, ProjetoAtualizarDataConclusaoDto projetoAtualizarDataConclusaoDto)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);
            var atualizacaoProjeto = await ObterProjeto(id);
            if (atualizacaoProjeto == null)
            {
                NotificarErro("Projeto não encontrado!");
                return CustomResponse();
            }
            atualizacaoProjeto.DataConclusao = projetoAtualizarDataConclusaoDto.DataConclusao;
            await _projetoService.Atualizar(_mapper.Map<Projeto>(atualizacaoProjeto));
            return CustomResponse(HttpStatusCode.NoContent);
        }

        [HttpDelete]
        [Route("Excluir-projeto/{id:guid}")]
        public async Task<ActionResult<ProjetoDto>> Excluir(Guid id)
        {
            var projeto = await ObterProjeto(id);

            if (projeto != null) return NotFound();

            await _projetoService.Remover(id);

            return CustomResponse(HttpStatusCode.NoContent);
        }

        private async Task<ProjetoDto> ObterProjeto(Guid id)
        {
            return _mapper.Map<ProjetoDto>(await _projetoRepository.ObterPorId(id));
        }
    }
}