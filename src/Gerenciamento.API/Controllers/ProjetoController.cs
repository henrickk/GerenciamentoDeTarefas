using Gerenciamento.API.DTO;
using Gerenciamento.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Gerenciamento.API.Controllers
{
    [ApiController]
    public class ProjetoController : MainController
    {
        private readonly IProjetoRepository _projetoRepository;
        private readonly IProjetoService _projetoService;

        public ProjetoController() { }

        [HttpGet]
        public async Task<IEnumerable<ProjetoDto>> ObterTodos()
        {
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<ProjetoDto>> ObterPorId(Guid id)
        {
        }

        [HttpPost]
        public async Task<ActionResult<ProjetoDto> Adiconar(ProjetoDto projetoDto)
        {
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<ProjetoDto>> Atualizar(Guid id, ProjetoDto projetoDto)
        {
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<ProjetoDto>> Excluir(Guid id)
        {
        }

        private async Task<ProjetoDto> ObterProjeto(Guid id)
        {
        }
    }
}