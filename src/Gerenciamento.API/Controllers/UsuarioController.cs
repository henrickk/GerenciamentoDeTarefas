using Gerenciamento.API.DTO;
using Gerenciamento.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Gerenciamento.API.Controllers
{
    [Route("api/usuarios")]
    public class UsuarioController : MainController
    {
        public UsuarioController(INotificador notificador) : base(notificador)
        {
        }

        //[HttpGet]
        //public async Task<ActionResult<UsuarioDto>> Login()
        //{

        //}

        //[HttpGet("{id:guid}")]
        //public async Task<ActionResult<UsuarioDto>> Senha()
        //{

        //}
    }
}
