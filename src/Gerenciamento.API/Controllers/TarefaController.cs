using Gerenciamento.API.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Gerenciamento.API.Controllers
{
    public class TarefaController
    {

        public TarefaController() { }

        [HttpGet]
        public async Task<IEnumerable<TarefaDto>> ObterTodos()
        {
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<TarefaDto>> ObterPorId(Guid id)
        {
        }

        [HttpPost]
        public async Task<ActionResult<TarefaDto> Adiconar(ProjetoDto projetoDto)
        {
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<TarefaDto>> Atualizar(Guid id, ProjetoDto projetoDto)
        {
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<TarefaDto>> Excluir(Guid id)
        {
        }

        private async Task<TarefaDto> ObterProjeto(Guid id)
        {
        }
    }
}
