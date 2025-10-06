using Gerenciamento.API.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Gerenciamento.API.Controllers
{
    [Route("api/usuarios")]
    public class UsuarioController : MainController
    {
        [HttpGet]
        public async Task<ActionResult<UsuarioDto>> Login()
        {

        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<UsuarioDto>> Senha()
        {

        }
    }
}
