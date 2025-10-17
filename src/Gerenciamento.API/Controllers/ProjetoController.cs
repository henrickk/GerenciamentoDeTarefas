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

        //[HttpGet]
        //[Route("consultar-projeto"]
        //public async Task<IEnumerable<Projeto>> ObterTodos()
        //{
        //    var projeto = await _projetoRepository.ObterProjetos();

        //    return _mapper.Map<IEnumerable<Projeto>>(projeto);
        //}

        [HttpGet]
        [Route("consultar-projeto")]
        public async Task<ActionResult<IEnumerable<ProjetoDto>>> ObterTodos()
        {
            var projetos = await _projetoRepository.ObterProjetos();
            var projetosDto = _mapper.Map<IEnumerable<ProjetoDto>>(projetos);

            return Ok(projetosDto);
            
        }


        [HttpGet]
        [Route("consultar-projeto/{id:guid}")]
        public async Task<ActionResult<ProjetoDto>> ObterPorId(Guid id)
        {
            var projetoDto = await ObterProjeto(id);

            if (projetoDto == null) return NotFound();

            return projetoDto;
        }

        [HttpPost]
        [Route("cadastrar-projeto")]
        public async Task<ActionResult<ProjetoDto>> Adicionar(CadastroProjetoDto cadastroProjetoDto)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _projetoService.Adicionar(_mapper.Map<Projeto>(cadastroProjetoDto));

            return CustomResponse(HttpStatusCode.Created, cadastroProjetoDto);
        }

        [HttpPut]
        [Route("atualizar-projeto/{id:guid}")]
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
            atualizacaoProjeto.NomeProjeto = projetoDto.NomeProjeto;
            atualizacaoProjeto.Descricao = projetoDto.Descricao;
            atualizacaoProjeto.DataConclusao = projetoDto.DataConclusao;

            await _projetoService.Atualizar(_mapper.Map<Projeto>(atualizacaoProjeto));

            return CustomResponse();
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
            return _mapper.Map<ProjetoDto>(await _projetoRepository.ObterProjetoUsuario(id));
        }
    }
}