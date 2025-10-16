using AutoMapper;
using Gerenciamento.API.DTO;
using Gerenciamento.Business.Interfaces;
using Gerenciamento.Business.Models;
using Gerenciamento.Data.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Gerenciamento.API.Controllers
{
    [Route("api/usuarios")]
    public class UsuarioController : MainController
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IUsuarioService _usuarioService;
        private readonly IMapper _mapper;
        
        public UsuarioController(IUsuarioRepository usuarioRepository,
                                 IUsuarioService usuarioService,
                                 IMapper mapper,
                                 INotificador notificador) : base(notificador)
        {
            _usuarioRepository = usuarioRepository;
            _usuarioService = usuarioService;
            _mapper = mapper;
        }


        [HttpGet]
        [Route("consultar-usuario")]
        public async Task<ActionResult<IEnumerable<UsuarioDto>>> ObterTodos()
        {
            var usuarios = await _usuarioRepository.ObterTodosUsuarios();

            if (usuarios == null || !usuarios.Any())
                return NoContent();

            var usuariosDto = _mapper.Map<IEnumerable<UsuarioDto>>(usuarios);
            return Ok(usuariosDto);
        }



        [HttpPost]
        [Route("cadastro-usuario")]
        public async Task<ActionResult<Usuario>> CadastroUsuario(UsuarioDto usuarioDto)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _usuarioRepository.Adicionar(_mapper.Map<Usuario>(usuarioDto));

            return CustomResponse(HttpStatusCode.Created, usuarioDto);
        }
    }
}
